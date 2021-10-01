using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [SerializeField] private GameObject HomeGo;
    [SerializeField] private GameObject InGameGo;
    [SerializeField] private GameObject GameOverGo;
    [SerializeField] private Text scoreTextInGame;
    [SerializeField] private Text scoreTextGameOver;
    [SerializeField] private Text hSTextGameOver;
    [SerializeField] private Text hSTextHome;

    // Update is called once per frame
    void Update()
    {
        switch (GameStatus.GameState)
        {
            case GameStatus.GameStateEnum.Home:
                HomeGo.SetActive(true);
                InGameGo.SetActive(false);
                GameOverGo.SetActive(false);
                hSTextHome.text = ("High Score : " + ScoreManager.highScore);
                break;
            case GameStatus.GameStateEnum.InGame:
                HomeGo.SetActive(false);
                InGameGo.SetActive(true);
                GameOverGo.SetActive(false);
                scoreTextInGame.text = ("Score : " + ScoreManager.score);
                break;
            case GameStatus.GameStateEnum.GameOver:
                HomeGo.SetActive(false);
                InGameGo.SetActive(false);
                GameOverGo.SetActive(true);
                scoreTextGameOver.text = ("Score : " + ScoreManager.score);
                if (ScoreManager.newHS)
                    hSTextGameOver.text = ("New High Score !");
                else hSTextGameOver.text = ("High Score : " + ScoreManager.highScore);
                break;
        }
    }
}
