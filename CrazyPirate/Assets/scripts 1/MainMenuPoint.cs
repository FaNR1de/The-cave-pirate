using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainMenuPoint : MonoBehaviour
{
    public Text ScoreText;

    void Start()
    {
        Main.HighScore = PlayerPrefs.GetInt("HighScore");
        ScoreText.text = Main.HighScore.ToString();
        
            
    }

    
}
