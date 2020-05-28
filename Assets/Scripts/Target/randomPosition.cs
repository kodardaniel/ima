using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class randomPosition : MonoBehaviour
{
    float x;
    float y;
    float z;
    Vector3 destination;

    // Start is called before the first frame update
    void Start()
    {
        randomizePosition();
    }

    public void randomizePosition()
    {
        x = Random.Range(-(world.size / 2), world.size / 2);
        y = Random.Range(-(world.size / 2), world.size / 2);
        z = Random.Range(-(world.size / 2), world.size / 2);
        destination = new Vector3(x, y, z);
        transform.position = destination;
    }
}
