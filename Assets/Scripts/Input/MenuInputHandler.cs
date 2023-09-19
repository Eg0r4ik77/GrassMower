using UnityEngine;
using UnityEngine.InputSystem;

namespace Input
{
    public class MenuInputHandler : InputHandler
    {
        private readonly Menu _menu;
        
        public MenuInputHandler(InputHandlersSwitcher switcher, PlayerInput playerInput, Menu menu) 
            : base(switcher, playerInput)
        {
            _menu = menu;
        }

        public override void Start()
        {
            playerInput.UI.Click.performed += ClickButton;
        }
        
        public override void Stop()
        {
            playerInput.UI.Click.performed -= ClickButton;
        }

        public override void Handle()
        {
            HandleButtonSwitch();
        }
        
        private void HandleButtonSwitch()
        {
            Vector2 moveInput = playerInput.UI.MoveToButton.ReadValue<Vector2>();
            
            _menu.TrySwitchButton(moveInput);
        }
        
        private void ClickButton(InputAction.CallbackContext context)
        {
            _menu.ClickCurrentButton();
        }
    }
}