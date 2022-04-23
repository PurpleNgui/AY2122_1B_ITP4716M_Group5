using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreCount : MonoBehaviour
{
    public static int score;
    public static Text scoreText;



    // Start is called before the first frame update
    void Start()
    {
        scoreText = GetComponent<Text>();
        UpdateScore(0);
    }

    public static void UpdateScore(int value)
    {
        score += value;
        scoreText.text = "<color=navy><b>" +  score.ToString() + " combo</b></color>";
    }

    public static void ResetScore()
    {
        score = 0;
        scoreText.text = "<color=navy><b>" + score.ToString() + " combo</b></color>";
    }


}


