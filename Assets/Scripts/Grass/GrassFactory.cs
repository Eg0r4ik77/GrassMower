using UnityEngine;

public class GrassFactory
{
    private readonly GrassPrefabs _grassPrefabs;
    
    public GrassFactory(GrassPrefabs prefabs)
    {
        _grassPrefabs = prefabs;
    }
    
    public Grass Create(GrassType type)
    {
        Grass grassPrefab = Get(type);

        var grass = Object.Instantiate(grassPrefab);

        return grass;
    }

    private Grass Get(GrassType type)
    {
        return type switch
        {
            GrassType.BaseGrass => _grassPrefabs.Get<BaseGrass>(),
            _ => null
        };
    }    
}
