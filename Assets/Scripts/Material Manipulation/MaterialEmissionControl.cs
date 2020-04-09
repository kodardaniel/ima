using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MaterialEmissionControl : MonoBehaviour
{

    public float multiplier = 10f;

    private Material material;
    private Color emissionColor;
    private float intensity;

    // Start is called before the first frame update
    void Start()
    {
        material = GetComponent<MeshRenderer>().materials[0];
        emissionColor = material.GetColor("_EmissionColor");        
    }

    // Update is called once per frame
    void Update()
    {
        intensity = AudioData.loudness * multiplier;
        material.SetColor("_EmissionColor", emissionColor * intensity);
    }
}
