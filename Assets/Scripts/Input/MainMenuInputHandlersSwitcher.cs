using Input;
using UnityEngine;

public class MainMenuInputHandlersSwitcher : InputHandlersSwitcher
{
    [SerializeField] private MainMenu _menu;

    private void Start()
    {
        MenuInputHandler menuInputHandler = new MenuInputHandler(this, PlayerInput, _menu);
        menuInputHandler.Initialize();
        
        CurrentInputHandler = menuInputHandler;
    }

    private void OnEnable()
    {
        PlayerInput.Enable();
    }
    
    private void OnDisable()
    {
        PlayerInput.Disable();
    }

    public override void SwitchInputHandling<T>() {}
}