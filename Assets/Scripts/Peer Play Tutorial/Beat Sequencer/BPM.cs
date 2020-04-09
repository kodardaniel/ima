using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BPM : MonoBehaviour
{
    private static BPM _BPMInstance;
    public float _bpm;
    private float _beatInterval, _beatTimer, _beatIntervalD8, _beatTimerD8;
    public static bool _beatFull, _beatD8;
    public static int _beatCountFull, _beatCountD8;

    private void Awake()
    {
        if (_BPMInstance != null && _BPMInstance !=this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            _BPMInstance = this;
            DontDestroyOnLoad(this.gameObject);
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        BeatDetection();
    }

    void BeatDetection()
    {
        // Full beat count
        _beatFull = false;
        _beatInterval = 240 / _bpm; // 240 = 60 * 4, amount of 1/4 beats per minute
        _beatTimer += Time.deltaTime;
        if (_beatTimer >= _beatInterval)
        {
            _beatTimer -= _beatInterval;
            _beatFull = true;
            _beatCountFull++;
            Debug.Log("Full");
        }
        // Divided beat count
        _beatD8 = false;
        _beatIntervalD8 = _beatInterval / 8;
        _beatTimerD8 += Time.deltaTime;
        if (_beatTimerD8 >= _beatIntervalD8)
        {
            _beatTimerD8 -= _beatIntervalD8;
            _beatD8 = true;
            _beatCountD8++;
            Debug.Log("D8");
        }
    }
}
