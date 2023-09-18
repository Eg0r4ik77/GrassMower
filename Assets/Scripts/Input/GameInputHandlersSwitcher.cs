﻿using System.Collections.Generic;
using System.Linq;
using Input;
using Zenject;

public class GameInputHandlersSwitcher : InputHandlersSwitcher
{
    private GrassMower _grassMower;
    private PauseMenu _pauseMenu;
    
    private List<InputHandler> _inputHandlers;
    private InputHandler _previousInputHandler;

    [Inject]
    private void Construct(GrassMower grassMower, PauseMenu pauseMenu)
    {
        _grassMower = grassMower;
        _pauseMenu = pauseMenu;
    }
    
    private void Start()
    {
        var actionInputHandler = new ActionInputHandler(this, PlayerInput, _pauseMenu, _grassMower);
        var pauseInputHandler = new MenuInputHandler(this, PlayerInput, _pauseMenu);
        
        _inputHandlers = new List<InputHandler>
        { 
            actionInputHandler,
            pauseInputHandler
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