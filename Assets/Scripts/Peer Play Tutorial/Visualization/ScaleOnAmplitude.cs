using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScaleOnAmplitude : MonoBehaviour
{
    public float _startScale, _maxScale;
    public bool _useBuffer;
    Material _material;
    public float _red, _green, _blue;

    // Start is called before the first frame update
    void Start()
    {
        _material = GetComponent<MeshRenderer>().materials[0];
    }

    // Update is called once per frame
    void Update()
    {
        if (!_useBuffer)
        {
            transform.localScale = new Vector3((AudioPeer._Amplitude * _maxScale) + _startScale, (AudioPeer._Amplitude * _maxScale) + _startScale, (AudioPeer._Amplitude));
        }
        else
        {
            transform.localScale = new Vector3((AudioPeer._AmplitudeBuffer * _maxScale) + _startScale, (AudioPeer._AmplitudeBuffer * _maxScale) + _startScale, (AudioPeer._AmplitudeBuffer));
        }
    }
}
