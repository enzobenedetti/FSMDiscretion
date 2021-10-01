using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public static int score = 0;

    public static int highScore = 0;
    public static bool newHS = false;

    private float timer = 0f;

    private float timeScore = 1f;
    // Start is called before the first frame update

    // Update is called once per frame
    void Update()
    {
        switch (GameStatus.GameState)
        {
            case GameStatus.GameStateEnum.Home:
                score = 0;
                newHS = false;
                break;
            case GameStatus.GameStateEnum.InGame:
                timer += Time.deltaTime;
                if (timer >= timeScore)
                {
                    timer = 0f;
                    score += 10;
                }
                break;
            case GameStatus.GameStateEnum.GameOver:
                timer = 0f;
                if (score > highScore)
                {
                    highScore = score;
                    newHS = true;
                }
                break;
        }
    }
}
