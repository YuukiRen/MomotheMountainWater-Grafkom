using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class MainMenu : MonoBehaviour {
    public string startLevel;
    public string helpName;
    public int playerLives;
    public string levelSelection;
	// Use this for initialization
    public void NewGame()
    {
        SceneManager.LoadScene(startLevel);
        PlayerPrefs.SetInt("PlayerCurrentLives", playerLives);
        PlayerPrefs.SetInt("PlayerCurrentScores", 0);
    }
    public void levelSelect()
    {
        PlayerPrefs.SetInt("PlayerCurrentLives", playerLives);
        SceneManager.LoadScene(levelSelection);
    }
    public void help()
    {
        SceneManager.LoadScene(helpName);
    }
    public void option()
    {
        SceneManager.LoadScene("Option");
    }
    public void QuitGame()
    {
        
        Application.Quit();
    }
}
