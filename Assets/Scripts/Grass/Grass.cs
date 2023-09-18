using System;
using UnityEngine;

public class Grass : MonoBehaviour, IPoolObject
{
    public Action<Grass> ReturnedToPool;
    public bool InUse { get; set; }
    public void Clear() {}

    public void Destroy()
    {
        ReturnedToPool?.Invoke(this);
        gameObject.SetActive(false);
    }
}