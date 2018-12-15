using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class PauseMenu : MonoBehaviour {
    public string titleScreen;
    public bool isPaused;
    public GameObject pauseMenuCanvas;
    void Update()
    {
        if (isPaused)
        {
            pauseMenuCanvas.SetActive(true);
            Time.timeScale = 0f;
        }
        else
        {
            pauseMenuCanvas.SetActive(false);
            Time.timeScale = 1f;
        }
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            isPaused = !isPaused;
        }
    }
    public void resumeGame()
    {
        isPaused = false;
    }
    public void pauseGame()
    {
        isPaused = true; 
    }
    public void quitGame()
    {
        SceneManager.LoadScene(titleScreen);
    }
}
