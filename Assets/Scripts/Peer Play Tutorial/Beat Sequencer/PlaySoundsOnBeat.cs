using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaySoundsOnBeat : MonoBehaviour
{
    public SoundManager _soundManager;
    public AudioClip _tap, _tick;
    public AudioClip[] _strum;
    int _randomStrum;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       if (BPM._beatFull)
        {
            _soundManager.PlaySound(_tap, 1);
            if (BPM._beatCountFull % 2 == 0)
            {
                // Every second bar
                _randomStrum = Random.Range(0, _strum.Length);
            }
        }
       if (BPM._beatD8 && BPM._beatCountD8 % 2 == 0)
        {
            // Every 1/4 beat ( = Every second 1/8 beat)
            _soundManager.PlaySound(_tick, 0.1f);
        }
       if (BPM._beatD8 && (BPM._beatCountD8 % 8 == 2 || BPM._beatCountD8 % 8 == 4))
        {
            _soundManager.PlaySound(_strum[_randomStrum], 1);
        }
    }
}
