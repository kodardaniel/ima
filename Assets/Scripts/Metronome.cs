using UnityEngine;
using System;

public class Metronome : MonoBehaviour
{
    /// <summary>
    /// Subscribe to this to listen for ticks coming from the metronome.
    /// This also passes the time that the tick should occur, relative to AudioSettings.dspTime.
    /// That means you can schedule audio system calls in the future with this info.
    /// </summary>
    public event Action<double> Ticked;

    [SerializeField, Tooltip("The tempo in beats per minute"), Range(20f, 200f)] private double _tempo = 120.0;
    [SerializeField, Tooltip("The number of ticks per beat"), Range(1, 8)] private int _subdivisions = 1;
    
    // The lenght of a single tick in seconds
    private double _tickLenght;

    // The next tick time, relative to AudioSettings.dspTime
    private double _nextTickTime;

    /// <summary>
    /// Recalculate the tick lenght and reset the next tick time
    /// </summary>
    private void Reset()
    {
        Recalculate();
        // Bumb the next tick time ahead the lenght of one tick so we don’t get a double trigger
        _nextTickTime = AudioSettings.dspTime + _tickLenght;
    }

    /// <summary>
    /// Derive the lenght of a tick in seconds from the tempo and subdivisions provided
    /// </summary>
    private void Recalculate()
    {
        double beatsPerSecond = _tempo / 60.0;
        double ticksPerSecound = beatsPerSecond * _subdivisions;
        _tickLenght = 1.0 / ticksPerSecound;
    }

    /// <summary>
    /// This gets called when the GameObject first gets set up.
    /// Do initialization here.
    /// </summary>
    private void Awake()
    {
        Reset();
    }

    /// <summary>
    /// This gets called in the editor when an inspecgtor control changes.
    /// Recalculate the tick length here.
    /// </summary>
    private void OnValidate()
    {
        if (Application.isPlaying)
        {
            Recalculate();
        }
    }

    /// <summary>
    /// This gets called once per frame.
    /// Check to see if we should schedule any ticks here.
    /// </summary>
    private void Update()
    {
        double currentTime = AudioSettings.dspTime;

        // Look ahead the length of one frame (approximately), because we’ll be scheduling samples
        currentTime += Time.deltaTime;

        // There may be more than one tick within the next frame, so this will catch them all
        while (currentTime > _nextTickTime)
        {
            // If something has subscribed to ticks from the metronome, let them know we got a tick
            if (Ticked !=null)
            {
                Ticked(_nextTickTime);
            }

            // Increment the next tick time
            _nextTickTime += _tickLenght;
        }
    }

}
