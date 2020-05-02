using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class toggleObject : MonoBehaviour
{

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("space"))
        {
            this.gameObject.GetComponent<Light>().enabled = !this.gameObject.GetComponent<Light>().enabled;
        }
    }
}
