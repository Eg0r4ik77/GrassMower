using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class GrassPoolsProvider
{
    private readonly Transform _root;
    private readonly GrassFactory _factory;
    
    private readonly Dictionary<GrassType, GrassPool> _pools = new();

    [Inject]
    public GrassPoolsProvider(Transform root, GrassFactory factory)
    {
        _root = root;
        _factory = factory;
    }

    public GrassPool Get(GrassType type)
    {
        if (!_pools.ContainsKey(type))
        {
            GrassPool pool = new GrassPool(type, _root, _factory);
            _pools[type] = pool;
        }
        
        return _pools[type];
    }
}