using System.Collections.Generic;
using System.Linq;
using Input;
using UnityEngine;

public class GameInputHandlersSwitcher : InputHandlersSwitcher
{
    [SerializeField] private GrassMower _grassMower;
    [SerializeField] private PauseMenu _pauseMenu;
    
    private List<InputHandler> _inputHandlers;
    private InputHandler _previousInputHandler;

    private void Start()
    {
        _inputHandlers = new List<InputHandler>
        { 
            new ActionInputHandler(this, PlayerInput, _pauseMenu, _grassMower),
            new MenuInputHandler(this, PlayerInput, _pauseMenu)
        };

        foreach (InputHandler inputHandler in _inputHandlers)
        {
            inputHandler.Initialize();
        }
        
        SwitchInputHandling<ActionInputHandler>();
    }

    private void OnEnable()
    {
        PlayerInput.Enable();
        
        _pauseMenu.Closed += SwitchToPreviousInputHandler;
    }
    
    private void OnDisable()
    {
        PlayerInput.Disable();

        _pauseMenu.Closed -= SwitchToPreviousInputHandler;
    }
    
    public override void SwitchInputHandling<T>()
    {
        InputHandler handler = _inputHandlers.FirstOrDefault(handler => handler is T);
        
        if (handler != null)
        {
            SetCurrentInputHandler(handler);
        }
    }

    private void SwitchToPreviousInputHandler()
    {
        SetCurrentInputHandler(_previousInputHandler);
    }
    
    private void SetCurrentInputHandler(InputHandler handler)
    {
        _previousInputHandler = CurrentInputHandler;
        CurrentInputHandler = handler;
    }
}