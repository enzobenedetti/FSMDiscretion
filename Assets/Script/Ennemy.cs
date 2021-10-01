using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Ennemy : MonoBehaviour
{
    public State currentState;
    
    private DetectPlayer _detectPlayer;

    [SerializeField] private NavMeshAgent agent;

    private void Awake()
    {
        _detectPlayer = this.transform.GetComponent<DetectPlayer>();
    }

    // Update is called once per frame
    void Update()
    {
        switch (currentState)
        { 
            case State.Idle:
                Idle();
                if (PlayerDetected()) currentState = State.Chase;
                break;
            case State.Chase:
                Chase();
                if (!PlayerDetected()) currentState = State.Search;
                break;
            case State.Search:
                Search();
                if (PlayerDetected()) currentState = State.Chase;
                if (!PlayerDetected()) currentState = State.Idle;
                break;
        }
        if (PlayerDetected())
            Debug.Log("Find Player");
    }

    private bool PlayerDetected()
    {
        return _detectPlayer.IsPlayerDetected();
    }

    private void Search()
    {
        //TODO
    }

    private void Chase()
    {
        //TODO
    }

    private void Idle()
    {
        if (!agent.pathPending && !agent.hasPath)
        {
            agent.SetDestination(WayPoint.GiveMeWayPoint);
        }
    }
}
