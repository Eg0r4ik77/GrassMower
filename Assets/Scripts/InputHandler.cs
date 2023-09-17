using UnityEngine;

public class InputHandler
{
    private readonly GrassMower _grassMower;
    private readonly PlayerInput _playerInput;

    public InputHandler(GrassMower grassMower, PlayerInput playerInput)
    {
        _grassMower = grassMower;
        _playerInput = playerInput;
    }

    public void Handle()
    {
        if (Menu.Paused)
            return;
            
        HandleMovement();
    }

    private void HandleMovement()
    {
        Vector2 moveInput = _playerInput.Player.Movement.ReadValue<Vector2>();

        if (moveInput != Vector2.zero)
        {
            Vector3 direction = Vector3.forward * moveInput.y + Vector3.right * moveInput.x;
            _grassMower.TryMove(direction.normalized);
        }
    }
}
