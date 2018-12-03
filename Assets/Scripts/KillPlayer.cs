using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillPlayer : MonoBehaviour {
    //declaration
    public LevelManager levelManager;
    public static bool killing;
    public int damage;
	// Use this for initialization
	void Start () {
        killing = true;
        levelManager = FindObjectOfType<LevelManager>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.name == "Player" && killing)
        {
            PlayerHealth.HurtPlayer(damage);
            levelManager.RespawnPlayer();
        }
    }
    public static void Killable(bool para)
    {
        killing = para;
    }
}
