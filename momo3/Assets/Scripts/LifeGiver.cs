using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LifeGiver : MonoBehaviour {

    // Use this for initialization
    public int life;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<PlayerController>() == null)
        {
            return;
        }
        PlayerHealth.AddHealth(life);
        Destroy(gameObject);
    }
}
