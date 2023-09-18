using Zenject;

public class GrassFactory
{
    private readonly DiContainer _diContainer;
    private readonly GrassPrefabs _grassPrefabs;
    
    public GrassFactory(DiContainer diContainer, GrassPrefabs prefabs)
    {
        _diContainer = diContainer;
        _grassPrefabs = prefabs;
    }
    
    public Grass Create(GrassType type)
    {
        Grass grassPrefab = Get(type);
        Grass grassInstance = _diContainer.InstantiatePrefabForComponent<Grass>(grassPrefab);

        return grassInstance;
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
