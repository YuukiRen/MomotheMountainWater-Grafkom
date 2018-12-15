using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NinjaStarController : MonoBehaviour {

    public float speed;
    public PlayerController player;
    public GameObject enemyDeathEffect;
    public GameObject impactEffect;
    public LayerMask whatIsGround;
    public int killPoint;
    public int damageGive;
    public bool Grounded;
    public Collider2D myCollide;
    public float rotationSpeed;
    // Use this for initialization
    void Start () {
        player = FindObjectOfType<PlayerController>();
        myCollide = GetComponent<Collider2D>();
        if (player.transform.localScale.x<0)
        {
            speed = -speed;
            rotationSpeed = -rotationSpeed;
        }
	}
	
	// Update is called once per frame
	void Update () {
        GetComponent<Rigidbody2D>().velocity = new Vector2(speed, GetComponent<Rigidbody2D>().velocity.y);
        GetComponent<Rigidbody2D>().angularVelocity = rotationSpeed;
        Grounded = Physics2D.IsTouchingLayers(myCollide, whatIsGround);
        if (Grounded)
        {
            print("Grounded");
            Instantiate(impactEffect, transform.position, transform.rotation);
            Destroy(gameObject);
        }

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Enemy")
        {
            //(enemyDeathEffect, collision.transform.position, collision.transform.rotation);
            collision.GetComponent<EnemyHealth>().giveDamage(damageGive);
            Instantiate(impactEffect, transform.position, transform.rotation);
            Destroy(gameObject);
            //ScoreManager.AddPoints(killPoint);
        }
    }
}
