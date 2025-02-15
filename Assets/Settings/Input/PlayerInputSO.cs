using System;
using UnityEngine;
using UnityEngine.InputSystem;

namespace BGD.Players
{
    [CreateAssetMenu(fileName = "PlayerInputSO", menuName = "SO/PlayerInputSO")]
    public class PlayerInputSO : ScriptableObject, Controls.IPlayerActions
    {
        public event Action JumpEvent;
        public event Action DashEvent;
        public event Action AttackEvent;
        //public event Action SlideEvent;
        public event Action GuardEvent;
        public event Action InteractEvent;

        public Vector2 InputDirection { get; private set; }

        private Controls _controls;

        private void OnEnable()
        {
            if (_controls == null)
            {
                _controls = new Controls();
                _controls.Player.SetCallbacks(this);
            }
            _controls.Player.Enable();
        }

        private void OnDisable()
        {
            _controls.Player.Disable();
        }

        public void OnAttack(InputAction.CallbackContext context)
        {
            if(context.performed)
            {
                AttackEvent?.Invoke();
            } 
        }

        public void OnInteract(InputAction.CallbackContext context)
        {
            if (context.performed)
                InteractEvent?.Invoke();
        }

        public void OnJump(InputAction.CallbackContext context)
        {
            if (context.performed)
                JumpEvent?.Invoke();
        }

        public void OnMove(InputAction.CallbackContext context)
        {
            InputDirection = context.ReadValue<Vector2>();
        }

        public void OnDash(InputAction.CallbackContext context)
        {
            if (context.performed)
                DashEvent?.Invoke();
        }

        public void OnGuard(InputAction.CallbackContext context)
        {
            if (context.performed)
                GuardEvent?.Invoke();
        }
    }
}
