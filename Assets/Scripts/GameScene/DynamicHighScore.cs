using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DynamicHighScore : MonoBehaviour
{    
    private int highScore;
    [SerializeField] TMP_Text highScoreText;
    [SerializeField] TMP_Text currentScoreText;

    void Start()
    {
        highScore = HighScoreManager.instance.GetHighScore(HighScoreManager.instance.gameMode);
        highScoreText.text = "High score: " + highScore;
    }

    void Update()
    {
        int currentScore = int.Parse(currentScoreText.text);
        if (currentScore > highScore)
        {
            highScore = currentScore;
            highScoreText.text = "High score: " + ExtensionMethods.GetColoredRichText(highScore.ToString(), "00A86B");
        }
    }
}