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

        public override void Initialize()
        {
            playerInput.UI.Click.performed += ClickButton;
        }

        public override void Handle()
        {
            TrySwitchButton();
        }
        
        private void TrySwitchButton()
        {
            Vector2 moveInput = playerInput.UI.MoveToButton.ReadValue<Vector2>();
            
            if (moveInput != Vector2.zero)
            {
                _menu.SwitchButton(moveInput);
            }
        }
        
        private void ClickButton(InputAction.CallbackContext context)
        {
            _menu.ClickCurrentButton();
        }
    }
}