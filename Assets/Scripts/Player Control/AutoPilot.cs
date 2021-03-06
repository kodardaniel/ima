﻿using UnityEngine;


public class AutoPilot : MonoBehaviour
{
    [SerializeField]
    Transform target;
    [SerializeField]
    float speed = 1.0f;
    [SerializeField]
    randomPosition randomPosition;
    [SerializeField]
    LineRenderer line;

    void Awake()
    {

    }


    // Start is called before the first frame update
    void Start()
    {
        // Set line start and target position
        line.SetPosition(1, target.transform.position);
        line.SetPosition(0, transform.position);
    }

    // Update is called once per frame
    void Update()
    {
        // Move our position a step closer to the target.
        float step = speed * Time.deltaTime; // calculate distance to move
        transform.position = Vector3.MoveTowards(transform.position, target.position, step);
        transform.LookAt(target.position);

        // Check if the position of the cube and sphere are approximately equal.
        if (Vector3.Distance(transform.position, target.position) < 0.001f)
        {
            // Swap the position of the cylinder.
            randomPosition.randomizePosition(randomPosition.yMin, randomPosition.yMax);
            // Set line target position
            line.SetPosition(1, target.transform.position);
        }

        // Set line start position
        line.SetPosition(0, transform.position);
    }
}
