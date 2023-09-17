using Input;
using UnityEngine;
using UnityEngine.InputSystem;

public class ActionInputHandler : InputHandler
{
    private readonly GrassMower _grassMower;
    private readonly PauseMenu _pauseMenu;

    public ActionInputHandler(InputHandlersSwitcher switcher, PlayerInput playerInput, PauseMenu pauseMenu, GrassMower grassMower) 
        : base(switcher, playerInput)
    {
        _pauseMenu = pauseMenu;
        _grassMower = grassMower;
    }

    public override void Initialize()
    {
        playerInput.Player.OpenMenu.performed += OpenPauseMenu;
    }

    public override void Handle()
    {
        HandleMovement();
    }

    private void HandleMovement()
    {
        Vector2 moveInput = playerInput.Player.Movement.ReadValue<Vector2>();

        if (moveInput != Vector2.zero)
        {
            Vector3 direction = Vector3.forward * moveInput.y + Vector3.right * moveInput.x;
            _grassMower.TryMove(direction.normalized);
        }
    }

    private void OpenPauseMenu(InputAction.CallbackContext context)
    {
        _pauseMenu.Open();
        switcher.SwitchInputHandling<MenuInputHandler>();
    }
}
