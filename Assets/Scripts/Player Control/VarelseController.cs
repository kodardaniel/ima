using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VarelseController : MonoBehaviour
{
    float speed;

    float x;
    float y;
    float z;
    Vector3 destination;

    void Awake()
    {
        speed = UnityEngine.Random.Range(0.2f, 4f);
    }

    // Start is called before the first frame update
    void Start()
    {
        randomizeDestination();
    }

    // Update is called once per frame
    void Update()
    {
        // Move our position a step closer to the target.
        float step = speed * Time.deltaTime; // calculate distance to move
        transform.position = Vector3.MoveTowards(transform.position, destination, step);

        // Check if the position of the cube and sphere are approximately equal.
        if (Vector3.Distance(transform.position, destination) < 0.001f)
        {
            // Swap the position of the cylinder.
            randomizeDestination();
        }
    }

    void randomizeDestination()
    {
        x = UnityEngine.Random.Range(-(world.sizeX / 2), world.sizeX / 2);
        y = UnityEngine.Random.Range(-(world.sizeY / 2), world.sizeY / 2);
        z = UnityEngine.Random.Range(-(world.sizeZ / 2), world.sizeZ / 2);
        destination = new Vector3(x, y, z);
    }
}
