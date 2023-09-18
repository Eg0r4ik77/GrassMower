﻿public abstract class InputHandler
{
    protected readonly InputHandlersSwitcher switcher;
    protected readonly PlayerInput playerInput;
    
    protected InputHandler(InputHandlersSwitcher switcher, PlayerInput playerInput)
    {
        this.switcher = switcher;
        this.playerInput = playerInput;
    }

    public abstract void Initialize();
    public abstract void Handle();
}