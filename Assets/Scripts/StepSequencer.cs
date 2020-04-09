using UnityEngine;
using System.Collections.Generic;
using System;

public class StepSequencer : MonoBehaviour
{
    [Serializable]
    public class Step
    {
        public bool Active;
        public int MidiNoteNumber = 60; // Midi Note Nuber 60 = C4
        public double Duration = 2.0f;
    }

    public delegate void HandleTick(double tickTime, int midiNoteNumber, double duration);

    public event HandleTick Ticked;

    [SerializeField] private Metronome _metronome;

    // hide this field in the inspector. We'll be making a custom inspector for these
    [SerializeField, HideInInspector] private List<Step> _steps;

    private int _currentTick = 0;

    #if UNITY_EDITOR
        public List<Step> GetSteps()
        {
            return _steps;
        }
#endif

    private void Awake()
    {
        // Find Metronome
        _metronome = GameObject.Find("Metronome").GetComponent(typeof(Metronome)) as Metronome;
    }

    private void OnEnable()
    {
        if (_metronome != null)
        {
            _metronome.Ticked += HandleTicked;
        }
    }

    private void OnDisable()
    {
        if (_metronome != null)
        {
            _metronome.Ticked -= HandleTicked;
        }
    }

    public void HandleTicked(double tickTime)
    {
        int numSteps = _steps.Count;
        
        if (numSteps == 0)
        {
            return;
        }

        Step step = _steps[_currentTick];

        if (step.Active)
        {
            if (Ticked != null)
            {
                Ticked(tickTime, step.MidiNoteNumber, step.Duration);
            }
        }

        _currentTick = (_currentTick + 1) % numSteps;
    }
}
