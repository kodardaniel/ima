using UnityEngine;

public class AudioDataMulti : MonoBehaviour
{

    public float _updateStep = 0.1f;
    public int _sampleDataLength = 1024;

    public static float _loudness;
    public static float _loudest;

    private AudioSource[] _audioSources;
    private float _currentUpdateTime = 0f;
    private float[] _clipSampleData;
    private Transform _sampler;
    private int _timesamples;
   
    // Use this for initialization
    void Awake()
    {
        _sampler = this.gameObject.transform.GetChild(0);
        _clipSampleData = new float[_sampleDataLength];
    }

    private void Start()
    {
        _audioSources = GetComponentsInChildren<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        _currentUpdateTime += Time.deltaTime;
        if (_currentUpdateTime >= _updateStep)
        {
            _currentUpdateTime = 0f;
            _loudness = 0f;
            _loudest = 0f;
            for (int i = 0; i < _audioSources.Length; ++i)
            {
                if (_audioSources[i].clip != null && _audioSources[i].isPlaying == true)
                {
                    _timesamples = _audioSources[i].timeSamples;
                    _audioSources[i].clip.GetData(_clipSampleData, _timesamples);
                    foreach (var sample in _clipSampleData)
                    {
                        _loudness += Mathf.Abs(sample);
                    }
                    _loudness /= _sampleDataLength;
                    // Check/store if loudest of the current sounding voices
                    if (_loudness > _loudest)
                    {
                        _loudest = _loudness;
                    }
                }
            }
        }
    }
}
