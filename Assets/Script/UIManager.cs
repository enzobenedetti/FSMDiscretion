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

    // Update is called once per frame
    void Update()
    {
        switch (GameStatus.GameState)
        {
            case GameStatus.GameStateEnum.Home:
                HomeGo.SetActive(true);
                InGameGo.SetActive(false);
                GameOverGo.SetActive(false);
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
                break;
        }
    }
}
