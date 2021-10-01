using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameStatus : MonoBehaviour
{
    public enum GameStateEnum
    {
        Home,
        InGame,
        GameOver,
    }

    public static GameStateEnum GameState;

    public void SetToHome()
    {
        GameState = GameStateEnum.Home;
    }

    public void SetToGame()
    {
        GameState = GameStateEnum.InGame;
    }
}
