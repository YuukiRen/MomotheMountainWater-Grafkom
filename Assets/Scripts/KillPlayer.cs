using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillPlayer : MonoBehaviour {
    //declaration
    public LevelManager levelManager;
    public bool killed;
	// Use this for initialization
	void Start () {
        levelManager = FindObjectOfType<LevelManager>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.name == "Player")
        {
            killed = true;
            levelManager.RespawnPlayer();
        }
    }
}
