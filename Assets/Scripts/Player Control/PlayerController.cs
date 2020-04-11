﻿using UnityEngine;
using UnityEngine.AI;

public class PlayerController : MonoBehaviour
{

    public Transform world;

    private float halfWalkDistance;
    private Vector3 destination;
    private NavMeshAgent agent;

    void Start()
    {
        halfWalkDistance = 0.9f * world.lossyScale.x / 2;
        agent = gameObject.GetComponent(typeof(NavMeshAgent)) as NavMeshAgent;
        newDestination();
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown("return"))
        {
            newDestination();
        }

        // Check if we've reached the destination
        if (agent.remainingDistance <= 4f)
        {
            newDestination();
        }
    }

    void newDestination()
    {
        destination = new Vector3(Random.Range(-halfWalkDistance, halfWalkDistance), 0, Random.Range(-halfWalkDistance, halfWalkDistance));
        agent.SetDestination(destination);
    }
}
