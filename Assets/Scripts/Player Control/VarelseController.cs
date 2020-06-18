using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VarelseController : MonoBehaviour
{

    float x;
    float y;
    float z;
    Vector3 destination;
    Transform player;
    [SerializeField]
    bool followingPlayer = false;
    [SerializeField]
    float speed;

    void Awake()
    {
        speed = UnityEngine.Random.Range(4f, 10f);
        player = GameObject.Find("Player").transform;
    }

    // Start is called before the first frame update
    void Start()
    {
        randomizeDestination();
    }

    // Update is called once per frame
    void Update()
    {
        float step = speed * Time.deltaTime; // calculate distance to move

        // If following player is active, move towards player, else move towards random destination
        if (followingPlayer)
        {
            transform.position = Vector3.MoveTowards(transform.position, player.position, step);
        }
        else
        {
            transform.position = Vector3.MoveTowards(transform.position, destination, step);
            // If arrived to approximately random destination, randomize destination
            if (Vector3.Distance(transform.position, destination) < 0.001f)
            {
                randomizeDestination();
            }
        }

    }

    void randomizeDestination()
    {
        x = UnityEngine.Random.Range(-(world.sizeX / 2), world.sizeX / 2);
        y = UnityEngine.Random.Range(-(world.sizeY / 2), world.sizeY / 2);
        z = UnityEngine.Random.Range(-(world.sizeZ / 2), world.sizeZ / 2);
        destination = new Vector3(x, y, z);
    }

    void OnMouseDown()
    {
        followingPlayer = !followingPlayer;
    }
}
