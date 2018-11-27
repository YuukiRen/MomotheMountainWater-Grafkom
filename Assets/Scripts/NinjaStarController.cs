using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NinjaStarController : MonoBehaviour {

    public float speed;
    public PlayerController player;
    public GameObject enemyDeathEffect;
    public LayerMask whatIsGround;
    public bool Grounded;
    public Collider2D myCollide;
    // Use this for initialization
    void Start () {
        player = FindObjectOfType<PlayerController>();
        myCollide = GetComponent<Collider2D>();
        if (player.transform.localScale.x<0)
        {
            speed = -speed;
        }
	}
	
	// Update is called once per frame
	void Update () {
        GetComponent<Rigidbody2D>().velocity = new Vector2(speed, GetComponent<Rigidbody2D>().velocity.y);
        Grounded = Physics2D.IsTouchingLayers(myCollide, whatIsGround);
        if (Grounded)
        {
            Destroy(gameObject);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Enemy")
        {
            Instantiate(enemyDeathEffect, collision.transform.position, collision.transform.rotation);
            Destroy(collision.gameObject);
            Destroy(gameObject);
        }
    }
}
