using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameGUI : Singleton<GameGUI>
{
    public GameObject homeGui;
    public GameObject gameGui;
    public GameObject gameOver;
    public GameObject info;

    public Text ScoreText;

    public override void Awake()
    {
        MakeSingleton(false);

    }

    public void ShowGameGui(bool isShow)
    {
        if(gameGui)
        {
            gameGui.SetActive(isShow);
        }

        if (homeGui)
        {
            homeGui.SetActive(!isShow);
        }
    }

    public void ShowGameover(bool isShow)
    {
        if (gameOver)
            gameOver.SetActive(isShow);
    }

    public void InFo()
    {
        if (info)
            info.SetActive(true);
        ShowGameover(false);
    }


    public void UpdateScore(int score)
    {
        if(ScoreText)
        {
            ScoreText.text = "SCORE: x" + score.ToString("00");
        }
    }

    public void Replay()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }    
}
