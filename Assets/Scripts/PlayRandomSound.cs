using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayRandomSound : MonoBehaviour
{
    
    public AudioClip[] audioClipArray;
    public float duration;

    private AudioSource _as;

    void Awake()
	{
        _as = GetComponent<AudioSource>();
	}

    // Start is called before the first frame update
    void Start()
    {
        RandomizeClip();
        PlayClip();
    }

    void RandomizeClip()
    {
        _as.clip = audioClipArray[Random.Range(0, audioClipArray.Length)];
    }

    void PlayClip()
    {  
        _as.PlayOneShot(_as.clip);
        StartCoroutine(PrepNextClip());
    }

    // Coroutine for prepping next clip
    IEnumerator PrepNextClip()
    {
        RandomizeClip();
        duration = _as.clip.length;
        yield return new WaitForSecondsRealtime(duration);
        PlayClip();
    }
}
