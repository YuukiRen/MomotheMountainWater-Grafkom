using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class HighestScore : MonoBehaviour
{
    Text text;
    public static int highestScore;
    void Start()
    {
        text = GetComponent<Text>();
        if (PlayerPrefs.HasKey("PlayerHighestScore"))
        {
            highestScore = PlayerPrefs.GetInt("PlayerHighestScore");
        }
        else
        {
            highestScore = 0;
        }
    }
    void Update()
    {
        checking();
        text.text = "" + highestScore;
    }
    public static void checking()
    {
        if (ScoreManager.score > highestScore)
        {
            highestScore = ScoreManager.score;
            PlayerPrefs.SetInt("PlayerHighestScore", highestScore);
        }
    }
}
