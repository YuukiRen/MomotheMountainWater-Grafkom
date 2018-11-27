using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {
	public float moveSpeed;
	public float jumpHeight;

    private float moveVelocity;
    private Rigidbody2D rb;
    private bool Grounded;
    private bool doubleJumped;
    public LayerMask whatIsGround;
    private Animator anim;

    public Transform firePoint;
    public GameObject ninjaStars;
    //end of tutor
    public Collider2D myCollide;
    // Use this for initialization
	void Start () {
        rb = GetComponent<Rigidbody2D>();   
        myCollide = GetComponent<Collider2D>();
        anim = GetComponent<Animator>();

	}
	
	// Update is called once per frame
	void Update () {
        Grounded = Physics2D.IsTouchingLayers(myCollide, whatIsGround);



        if (Grounded==true)
        {
            doubleJumped = false;
        }
        if (Input.GetKeyDown(KeyCode.Space) && Grounded == true)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpHeight);
        }
        if (Input.GetKeyDown(KeyCode.Space) && doubleJumped==false)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpHeight);
            doubleJumped = true;
        }

        moveVelocity = 0f;
        if (Input.GetKey(KeyCode.D))
        {
            moveVelocity = moveSpeed;
        }
        if (Input.GetKey(KeyCode.A))
        {
            moveVelocity = -moveSpeed;
        }
        rb.velocity = new Vector2(moveVelocity, rb.velocity.y);
        if (rb.velocity.x > 0)
        {
            transform.localScale = new Vector3(1f, 1f, 1f);
        }
        else if (rb.velocity.x < 0)
        {
            transform.localScale = new Vector3(-1f, 1f, 1f);
        }
        anim.SetFloat("Speed", Mathf.Abs(rb.velocity.x));

        if (Input.GetKeyDown(KeyCode.F))
        {
            Instantiate(ninjaStars, firePoint.position, firePoint.rotation);
        }
    }
}
