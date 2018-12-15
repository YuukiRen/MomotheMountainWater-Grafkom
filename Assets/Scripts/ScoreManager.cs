using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class ScoreManager : MonoBehaviour {
    public static int score;
    Text text;
    void Start()
    {
        text = GetComponent<Text>();
        score = PlayerPrefs.GetInt("PlayerCurrentScores");
    }
    void Update()
    {
        if (score < 0)
        {
            score = 0;
        }
        text.text = "" + score;
    }
    public static void AddPoints(int points)
    {
        score += points;
    }
    public static void reset()
    {
        score = 0;
    }
}
