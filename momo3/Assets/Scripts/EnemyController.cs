using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour {
    public float moveSpeed;
    public bool moveRight;
    public LayerMask whatIsWall;
    public float wallCheckRadius;
    public Transform WallCheck;

    private bool Walled;
    private Rigidbody2D rb;

    private bool Edged;
    public Transform edgeCheck;
	private Animator anim;

    // Use this for initialization
    void Start () {
        rb = GetComponent<Rigidbody2D>();
		anim = GetComponent<Animator>();
    }
	
	// Update is called once per frame
	void Update () {
        Walled = Physics2D.OverlapCircle(WallCheck.position, wallCheckRadius, whatIsWall);
        Edged = Physics2D.OverlapCircle(edgeCheck.position, wallCheckRadius, whatIsWall);

        if (Walled || !Edged)
        {
            moveRight = !moveRight;
        }
        if (moveRight)
        {
            transform.localScale = new Vector3(-1f, 1f, 1f);
            rb.velocity = new Vector2(moveSpeed, rb.velocity.y);
        }
        else
        {
            transform.localScale = new Vector3(1f, 1f, 1f);
            rb.velocity = new Vector2(-moveSpeed, rb.velocity.y);
        }
         
	}
}
