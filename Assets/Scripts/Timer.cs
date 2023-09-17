using System;
using UnityEngine;

public class Timer
{
    private readonly float _secondsInterval;
    private readonly Action[] _handlers;
        
    private float _lastTickTime;

    public bool Started { get; private set; }
    
    public Timer(float secondsInterval, params Action[] handlers)
    {
        _handlers = handlers;
        _secondsInterval = secondsInterval;
        
        Reset();
        Started = true;
    }

    public void Tick()
    {
        if (Time.time - _lastTickTime > _secondsInterval)
        {
            foreach (Action handler in _handlers)
            {
                handler();
            }
            
            Reset();
        }
    }
    
    private void Reset()
    {
        _lastTickTime = Time.time;
        Started = false;
    }
}