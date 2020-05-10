using UnityEngine;using CrazyMinnow.AmplitudeWebGL;

public class SequencerVisualizer : MonoBehaviour
{
    public Amplitude amp;    public float multiplier = 10f;    private Material material;    private Color emissionColor;    private float intensity;

    void Start()    {        material = GetComponent<MeshRenderer>().materials[0];        emissionColor = material.GetColor("_EmissionColor");    }    void Update()    {        //intensity = amp.average * multiplier;        //material.SetColor("_EmissionColor", emissionColor * intensity);    }
}
