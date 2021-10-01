using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectPlayer : MonoBehaviour
{
    private bool _playerInZone = false;

    [SerializeField] private float checkDistance = 8f;

    public bool IsPlayerDetected()
    {
        return _playerInZone;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            RaycastHit hit;
            if (Physics.Raycast(this.transform.position + Vector3.up, 
                new Vector3(other.transform.position.x - transform.position.x, 0,other.transform.position.z - transform.position.z), 
                out hit, checkDistance))
            {
                if (hit.transform == other.transform)
                {
                    _playerInZone = true;
                }
            }
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            RaycastHit hit;
            if (Physics.Raycast(this.transform.position + Vector3.up, 
                new Vector3(other.transform.position.x - transform.position.x, 0,other.transform.position.z - transform.position.z), 
                out hit, checkDistance))
            {
                if (hit.transform == other.transform)
                {
                    _playerInZone = true;
                }
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
            _playerInZone = false;
    }
}
