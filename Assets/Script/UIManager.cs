using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    [SerializeField] private GameObject HomeGo;
    [SerializeField] private GameObject InGameGo;
    [SerializeField] private GameObject GameOverGo;

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
                break;
            case GameStatus.GameStateEnum.GameOver:
                HomeGo.SetActive(false);
                InGameGo.SetActive(false);
                GameOverGo.SetActive(true);
                break;
        }
    }
}
