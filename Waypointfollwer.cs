using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Waypointfollwer : MonoBehaviour
{

    [SerializeField] GameObject[] way;

    int currentpointIndex = 0;

    [SerializeField] float speed = 2f;
    
    void Update()
    {
        if (Vector2.Distance(way[currentpointIndex].transform.position,transform.position) < .1f)
        {
            currentpointIndex++;
            if(currentpointIndex >= way.Length)
            {
                currentpointIndex= 0;
            }
            
        }
        transform.position = Vector2.MoveTowards(transform.position, way[currentpointIndex].transform.position,Time.deltaTime*speed);
    }
}
