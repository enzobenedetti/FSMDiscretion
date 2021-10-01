using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using Random = UnityEngine.Random;

public class Ennemy : MonoBehaviour
{
    public State currentState;
    private bool chaseFailed = false;
    private bool searchFailed = false;

    private float timer = 0f;
    [SerializeField] private float idleStopTime = 1f;
    [SerializeField] private float searchTime = 5f;
    
    private DetectPlayer _detectPlayer;
    [SerializeField] private Transform playerTransform;

    [SerializeField] private NavMeshAgent agent;
    
    private Vector3 _startSpawn;
    private Quaternion _spawnRotation;

    private void Awake()
    {
        _detectPlayer = this.transform.GetComponent<DetectPlayer>();
        _startSpawn = transform.position;
        _spawnRotation = transform.rotation;
    }

    // Update is called once per frame
    void Update()
    {
        switch (GameStatus.GameState)
        {
            case GameStatus.GameStateEnum.Home:
                transform.position = _startSpawn;
                transform.rotation = _spawnRotation;
                currentState = State.Idle;
                break;
            case GameStatus.GameStateEnum.InGame:
                switch (currentState)
                { 
                    case State.Idle:
                        Idle();
                        if (PlayerDetected()) currentState = State.Chase;
                        break;
                    case State.Chase:
                        Chase();
                        if (!PlayerDetected() && chaseFailed) currentState = State.Search;
                        break;
                    case State.Search:
                        Search();
                        if (PlayerDetected()) currentState = State.Chase;
                        if (!PlayerDetected() && searchFailed) currentState = State.Idle;
                        break;
                }
                Debug.Log(currentState);
                break;
            case GameStatus.GameStateEnum.GameOver:
                if (agent.hasPath)
                    agent.ResetPath();
                break;
        }
    }

    private bool PlayerDetected()
    {
        return _detectPlayer.IsPlayerDetected();
    }

    private void Search()
    {
        agent.speed = 2f;
        timer += Time.deltaTime;

        if (!agent.hasPath)
        {
            agent.SetDestination(transform.position + new Vector3(Random.Range(-2f, 2f), 0, Random.Range(-2f, 2f)));
        }
        
        if (timer >= searchTime)
        {
            searchFailed = true;
            timer = 0f;
        }
        else searchFailed = false;
    }

    private void Chase()
    {
        timer = 0f;
        agent.speed = 4f;
        if (PlayerDetected())
        {
            agent.SetDestination(playerTransform.position);
        }

        if (Vector3.Distance(transform.position, playerTransform.position) <= 1.5f)
            GameStatus.GameState = GameStatus.GameStateEnum.GameOver;
        
        if (!agent.hasPath)
            chaseFailed = true;
        else chaseFailed = false;
    }

    private void Idle()
    {
        agent.speed = 2f;
        if (!agent.pathPending && !agent.hasPath)
        {
            timer += Time.deltaTime;
            if (timer >= idleStopTime)
            {
                agent.SetDestination(WayPoint.GiveMeWayPoint);
                timer = 0f;
            }
        }
    }
}
