﻿using Input;
using UnityEngine;

public class MainMenuInputHandlersSwitcher : InputHandlersSwitcher
{
    [SerializeField] private MainMenu _menu;

    private void Start()
    {
        MenuInputHandler menuInputHandler = new MenuInputHandler(this, PlayerInput, _menu);
        
        CurrentInputHandler = menuInputHandler;
        CurrentInputHandler.Start();
        
        Cursor.visible = false;
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