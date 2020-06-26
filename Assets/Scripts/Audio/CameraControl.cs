using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl : MonoBehaviour
{

    GameObject player;
    Vector3 cameraOffset;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
        cameraOffset = new Vector3(0, 2, -6);
    }

    // Update is called once per frame
    void LateUpdate()
    {
        transform.position = player.transform.position + cameraOffset;
        transform.forward = player.transform.forward;
    }
}
