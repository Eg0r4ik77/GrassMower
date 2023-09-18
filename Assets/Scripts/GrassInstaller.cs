using UnityEngine;
using Zenject;

public class GrassInstaller : MonoInstaller
{
    [SerializeField] private Transform _root;
    [SerializeField] private GrassPrefabs _prefabs;
    
    public override void InstallBindings()
    {
        Container
            .Bind<GrassFactory>()
            .AsSingle()
            .WithArguments(_prefabs);

        Container
            .BindInterfacesAndSelfTo<GrassPoolsProvider>()
            .AsSingle()
            .WithArguments(_root);

        Container
            .Bind<GrassSpawner>()
            .AsSingle();
    }
}