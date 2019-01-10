using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour {
    public static int health;
    public int maxPlayerHealth;
    public string afterDeath;
    Text text;

    private LevelManager levelManager;
    // Use this for initialization
    void Start () {
        health = maxPlayerHealth;
        //health = PlayerPrefs.GetInt("PlayerCurrentLives");
        text = GetComponent<Text>();
        levelManager = FindObjectOfType<LevelManager>();
	}
	
	// Update is called once per frame
	void Update () {
        if (health<=0)
        {
            //levelManager.RespawnPlayer();
            HighestScore.checking();
            SceneManager.LoadScene(afterDeath);
        }
        text.text = "" + health + "/" + maxPlayerHealth;
	}
    public static void HurtPlayer(int damage)
    {
        health -= damage;
    }
    public static void AddHealth(int replenish)
    {
        health += replenish;
    }
    public static int GetHealth()
    {
        return health;
    }
    public void FullHealth()
    {
        health = maxPlayerHealth;
    }
}
