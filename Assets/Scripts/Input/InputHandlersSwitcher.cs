using UnityEngine;

public abstract class InputHandlersSwitcher : MonoBehaviour
{
    private InputHandler _currentInputHandler;
    private PlayerInput _playerInput;

    protected InputHandler CurrentInputHandler
    {
        get => _currentInputHandler;
        set => _currentInputHandler = value;
    }

    protected PlayerInput PlayerInput => _playerInput;

    public abstract void SwitchInputHandling<T>() where T : InputHandler;
    
    private void Awake()
    {
        _playerInput = new PlayerInput();
    }
    
    private void Update()
    {
        _currentInputHandler.Handle();
    }
}
