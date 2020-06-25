using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class randomPosition : MonoBehaviour
{
    float x;
    float y;
    float z;
    Vector3 destination;

    public float yMin;
    public float yMax;

    // Start is called before the first frame update
    void Start()
    {
        // If Player Target, provide custom parameters, else call method with default parameters
        if (gameObject.name == "Player Target")
        {
            yMin = world.yMax * 0.8f;
            yMax = world.yMax * 0.9f;
            randomizePosition(yMin, yMax);
        } else
        {
            randomizePosition();
        }

    }

    public void randomizePosition(float yMin = world.yMin, float yMax = world.yMax)
    {
        x = Random.Range(-(world.sizeX / 2), world.sizeX / 2);
        y = Random.Range(yMin, yMax);
        z = Random.Range(-(world.sizeZ / 2), world.sizeZ / 2);
        destination = new Vector3(x, y, z);
        transform.position = destination;
    }
}
