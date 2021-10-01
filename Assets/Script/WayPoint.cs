using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WayPoint : MonoBehaviour
{
    [SerializeField] private static List<Transform> Waypoints = new List<Transform>();
    
    void Awake()
    {
        foreach (Transform child in this.transform)
        {
            Waypoints.Add(child);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public static Vector3 DefineWayPoint()
    {
        int index = Random.Range(0, Waypoints.Count - 1);
        return Waypoints[index].position;
    }
}
