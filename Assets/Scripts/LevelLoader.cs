using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour {
    private bool playerInZone;

    public string levelToLoad;
	// Use this for initialization
	void Start () {
        playerInZone = false;

	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.W) && playerInZone)
        {
            PlayerPrefs.SetInt("PlayerCurrentLives", PlayerHealth.health);
            PlayerPrefs.SetInt("PlayerCurrentScores", ScoreManager.score);
            if(levelToLoad == "Won")
            {
                print("check");
                HighestScore.checking();
            }
            SceneManager.LoadScene(levelToLoad);
        } 
	}
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.name == "Player")
        {
            print("entering");
            playerInZone = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.name == "Player")
        {
            print("LEaving");
            playerInZone = false;
        }
    }
}
