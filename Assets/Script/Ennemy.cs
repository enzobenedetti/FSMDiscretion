using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Ennemy : MonoBehaviour
{
    public State currentState;

    [SerializeField] private static float minX = -20f;
    [SerializeField] private static float maxX = 20f;
    [SerializeField] private static float minZ = -20f;
    [SerializeField] private static float maxZ = 20f;

    [SerializeField] private NavMeshAgent agent;

    // Update is called once per frame
    void Update()
    {
        switch (currentState)
        { 
            case State.Idle:
                Idle();
                if (playerDetected()) currentState = State.Chase;
                break;
            case State.Chase:
                Chase();
                if (!playerDetected()) currentState = State.Search;
                break;
            case State.Search:
                Search();
                if (playerDetected()) currentState = State.Chase;
                if (playerDetected()) currentState = State.Idle;
                break;
        }
    }

    private bool playerDetected()
    {
        //TODO
        throw new System.NotImplementedException();
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
            agent.SetDestination(WayPoint.DefineWayPoint());
            Debug.Log(agent.destination);
            //new Vector3(Random.Range(minX, maxX), 0, Random.Range(minZ, maxZ))
        }
    }
}
