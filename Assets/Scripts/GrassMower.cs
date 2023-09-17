using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class GrassMower : MonoBehaviour
{
    [SerializeField] private float _speed = 3f;

    private CharacterController _characterController;
    private InputHandler _inputHandler;

    private PlayerInput _playerInput;

    private Menu menu;

    private void Awake()
    {
        _characterController = GetComponent<CharacterController>();
        menu = FindObjectOfType<Menu>();
        
        _playerInput = new PlayerInput();
        _inputHandler = new InputHandler(this, _playerInput);
    }

    private void OnEnable()
    {
        _playerInput.Enable();
        _playerInput.Player.OpenMenu.performed += SwitchPauseMenu;
        _playerInput.UI.Click.performed += ClickButton;
    }

    private void OnDisable()
    {
        _playerInput.Disable();
        _playerInput.Player.OpenMenu.performed -= SwitchPauseMenu;
        _playerInput.UI.Click.performed -= ClickButton;
    }

    private void Update()
    {
        _inputHandler.Handle();
        MoveToButton();
    }

    public void TryMove(Vector3 direction)
    {
        bool rotated = Rotate(direction);

        if (rotated)
        {
            _characterController.SimpleMove(_speed * transform.forward);
        }
    }

    private bool Rotate(Vector3 direction)
    {
        Quaternion targetRotation = Quaternion.LookRotation(direction);
        
        transform.rotation = Quaternion.RotateTowards( transform.rotation,
            targetRotation, 
            1f);

        bool rotated = Quaternion.Angle(transform.rotation, targetRotation) < 180f;

        return rotated;
    }

    private void SwitchPauseMenu(InputAction.CallbackContext context)
    {
        menu.SwitchActive();
    }

    private void MoveToButton()
    {
        if (!Menu.Paused && SceneManager.GetActiveScene().name != "MainMenu")
            return;
        
        Vector2 moveInput = _playerInput.UI.MoveToButton.ReadValue<Vector2>();
        
        if (moveInput != Vector2.zero)
        {
            menu.MoveToButton(moveInput);
        }
    }

    public void ClickButton(InputAction.CallbackContext context)
    {
        menu.ClickCurrentButton();
    }
}