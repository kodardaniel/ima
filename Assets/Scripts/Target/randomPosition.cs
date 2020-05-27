using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class randomPosition : MonoBehaviour
{
    public float worldRadius = 250f;
    
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
        x = Random.Range(-worldRadius, worldRadius);
        y = Random.Range(-worldRadius, worldRadius);
        z = Random.Range(-worldRadius, worldRadius);
        destination = new Vector3(x, y, z);
        transform.position = destination;
    }
}
