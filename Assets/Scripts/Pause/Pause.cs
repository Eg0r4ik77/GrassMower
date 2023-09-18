using System.Collections.Generic;

public class Pause
{
    private static Pause _instance;
    private List<IPauseable> _pauseables = new();

    public static Pause Instance => _instance ?? new Pause();

    public void Register(IPauseable pauseable)
    {
        _pauseables.Add(pauseable);
    }

    public void UnRegister(IPauseable pauseable)
    {
        _pauseables.Remove(pauseable);
    }
    
    public void SetPause(bool paused)
    {
        foreach (IPauseable pauseable in _pauseables)
        {
            pauseable.SetPaused(paused);
        }
    }
}
