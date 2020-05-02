using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class AudioDataVisSingle : MonoBehaviour
{

    public float updateStep = 0.1f;
    public int sampleDataLength = 1024;
    public float loudness;
    public float multiplier = 10f;

    private AudioSource audioSource;
    private float currentUpdateTime = 0f;
    public float[] clipSampleData;
    private Material material;
    private Color emissionColor;
    private float intensity;

    // Use this for initialization
     void Awake()
    {
        audioSource = GetComponent<AudioSource>();
        clipSampleData = new float[sampleDataLength];
    }

    public void updateAudioSource()
    {
        //audioSource = GetComponent<AudioSource>();
    }

    void Start()
    {
        material = GetComponent<MeshRenderer>().materials[0];
        emissionColor = material.GetColor("_EmissionColor");
    }

    // Update is called once per frame
    void Update()
    {
        currentUpdateTime += Time.deltaTime;
        if (currentUpdateTime >= updateStep)
        {
            currentUpdateTime = 0f;
            //1024 samples is about 80 ms on a 44khz stereo clip, beginning at the current sample position of the clip.
            audioSource.clip.GetData(clipSampleData, audioSource.timeSamples);
            loudness = 0f;
            foreach (var sample in clipSampleData)
            {
                loudness += Mathf.Abs(sample);
            }
            loudness /= sampleDataLength; //loudness is what you are looking for
        }

        // Visualization
        Debug.Log(loudness);
        intensity = loudness * multiplier;
        material.SetColor("_EmissionColor", emissionColor * intensity);
    }

}