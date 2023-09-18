using UnityEngine;
using Zenject;

public class GameInstaller : MonoInstaller
{
    [SerializeField] private GrassMower _grassMower;
    [SerializeField] private PauseMenu _pauseMenu;
    
    public override void InstallBindings()
    {
        Container
            .Bind<GrassMower>()
            .FromInstance(_grassMower)
            .AsSingle();
        
        Container
            .Bind<PauseMenu>()
            .FromInstance(_pauseMenu)
            .AsSingle();
    }
}