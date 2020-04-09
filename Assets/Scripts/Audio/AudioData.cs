using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class AudioData : MonoBehaviour
{

    public float updateStep = 0.1f;
    public int sampleDataLength = 1024;

    public static float loudness;

    private AudioSource audioSource;
    private float currentUpdateTime = 0f;
    private float[] clipSampleData;

    // Use this for initialization
    private void Awake()
    {
        audioSource = GetComponent<AudioSource>(); //this.gameObject.GetComponent<AudioSource>();
        clipSampleData = new float[sampleDataLength];
    }

    // Update is called once per frame
    void Update()
    {
        currentUpdateTime += Time.deltaTime;
        if (currentUpdateTime >= updateStep)
        {
            currentUpdateTime = 0f;
            //I read 1024 samples, which is about 80 ms on a 44khz stereo clip, beginning at the current sample position of the clip.
            audioSource.clip.GetData(clipSampleData, audioSource.timeSamples); 
            loudness = 0f;
            foreach (var sample in clipSampleData)
            {
                loudness += Mathf.Abs(sample);
            }
            loudness /= sampleDataLength; //loudness is what you are looking for
            //Debug.Log(loudness);
        }

    }

}