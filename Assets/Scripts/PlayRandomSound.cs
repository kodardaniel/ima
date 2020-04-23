using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayRandomSound : MonoBehaviour
{
    
    public AudioClip[] audioClipArray;

    private AudioSource _as;

    void Awake()
	{
        _as = GetComponent<AudioSource>();
	}

    // Start is called before the first frame update
    void Start()
    {
        PlayRandom();
    }

    private void Update()
    {
       if (_as.isPlaying == false)
        {
            PlayRandom();
        }
    }

    void PlayRandom()
    {
        _as.clip = audioClipArray[Random.Range(0, audioClipArray.Length)];
        _as.PlayOneShot(_as.clip);
    }
}
