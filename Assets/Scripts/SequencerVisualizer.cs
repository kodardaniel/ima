using UnityEngine;using CrazyMinnow.AmplitudeWebGL;

public class SequencerVisualizer : MonoBehaviour
{
    public Amplitude[] amp;    public float multiplier = 10f;    public float updateStep = 0.1f;    public float loudest;    private float currentUpdateTime = 0f;    private Material material;    private Color emissionColor;    private float intensity;

    void Start()    {        amp = GetComponentsInChildren<Amplitude>();        material = GetComponent<MeshRenderer>().materials[0];        emissionColor = material.GetColor("_EmissionColor");    }    void Update()    {        currentUpdateTime += Time.deltaTime;        if (currentUpdateTime >= updateStep)
		{
            currentUpdateTime = 0f;
            loudest = 0f;
            for (int i = 0; i < amp.Length; ++i)
            {
                if (amp[i].average > loudest)
                {
                    loudest = amp[i].average;
                }
            }
            intensity = loudest * multiplier;
            material.SetColor("_EmissionColor", emissionColor * intensity);
        }           }
}
