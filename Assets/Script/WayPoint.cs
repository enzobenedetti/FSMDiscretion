using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WayPoint : MonoBehaviour
{
    [SerializeField] private static List<Transform> Waypoints = new List<Transform>();
    
    public static Vector3 GiveMeWayPoint => Waypoints[Random.Range(0, Waypoints.Count - 1)].position;
    
    void Awake()
    {
        foreach (Transform child in this.transform)
        {
            Waypoints.Add(child);
        }
    }
}
