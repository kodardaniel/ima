using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class PlayRandomSound : MonoBehaviour
{
    
    public AudioClip[] audioClipArray;
    public float duration;

    private AudioSource audioSource;

    void Awake()
	{
        audioSource = GetComponent<AudioSource>();
	}

    // Start is called before the first frame update
    void Start()
    {
        RandomizeClip();
        PlayClip();
    }

    void RandomizeClip()
    {
        audioSource.clip = audioClipArray[Random.Range(0, audioClipArray.Length)];
    }

    void PlayClip()
    {  
        audioSource.PlayOneShot(audioSource.clip);
        StartCoroutine(PrepNextClip());
    }

    // Coroutine for prepping next clip
    IEnumerator PrepNextClip()
    {
        RandomizeClip();
        duration = audioSource.clip.length;
        yield return new WaitForSecondsRealtime(duration);
        PlayClip();
    }
}
