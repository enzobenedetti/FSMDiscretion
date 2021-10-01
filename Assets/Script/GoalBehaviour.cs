using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using Random = UnityEngine.Random;

public class GoalBehaviour : MonoBehaviour
{
    private NavMeshAgent agent;
    private bool warpDone = false;

    private void Awake()
    {
        agent = this.GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        switch (GameStatus.GameState)
        {
            case GameStatus.GameStateEnum.Home:
                if (!warpDone)
                {
                    agent.Warp(new Vector3(Random.Range(-20f, 20f), 0, Random.Range(-20f, 20f)));
                    warpDone = true;
                }
                break;
            case GameStatus.GameStateEnum.InGame:
                warpDone = false;
                break;
            case GameStatus.GameStateEnum.GameOver:
                break;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            ScoreManager.score += 100;
            agent.Warp(new Vector3(Random.Range(-20f, 20f), 0, Random.Range(-20f, 20f)));
        }
    }
}
