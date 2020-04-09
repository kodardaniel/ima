using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MaterialEmissionControlMulti : MonoBehaviour
{

    public float multiplier = 10f;

    private Material material;
    private Color emissionColor;
    private float intensity;

    private Light light;

    // Start is called before the first frame update
    void Start()
    {
        material = GetComponent<MeshRenderer>().materials[0];
        emissionColor = material.GetColor("_EmissionColor");

        light = GetComponent<Light>();
    }

    // Update is called once per frame
    void Update()
    {
        //intensity = AudioDataMulti._loudest * multiplier; // Only the loudest of any concurrent sounding voices will be used for intensity
        //material.SetColor("_EmissionColor", emissionColor * intensity);
        //Debug.Log(gameObject.name + AudioDataMulti._loudest);

        light.intensity = intensity * 20;
    }
}

