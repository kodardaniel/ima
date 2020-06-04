using System.Collections;
using System.Collections.Generic;
using UnityEngine;


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
        
    }

    // Update is called once per frame
    void Update()
    {
        // Move our position a step closer to the target.
        float step = speed * Time.deltaTime; // calculate distance to move
        transform.position = Vector3.MoveTowards(transform.position, target.position, step);

        // Check if the position of the cube and sphere are approximately equal.
        if (Vector3.Distance(transform.position, target.position) < 0.001f)
        {
            // Swap the position of the cylinder.
            randomPosition.randomizePosition();
            // Set line target position
            line.SetPosition(1, target.transform.position);
        }

        // Draw Line
        line.SetPosition(0, transform.position);
    }
}
