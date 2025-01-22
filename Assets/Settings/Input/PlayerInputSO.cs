using System;
using UnityEngine;
using UnityEngine.InputSystem;

namespace BGD.Player
{
    [CreateAssetMenu(fileName = "PlayerInputSO", menuName = "SO/PlayerInputSO")]
    public class PlayerInputSO : ScriptableObject, Controls.IPlayerActions
    {
        public event Action JumpEvent;
        public event Action DashEvent;
        public event Action AttackEvent;
        public event Action SlideEvent;
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
        public void OnAttack(InputAction.CallbackContext context)
        {
            
        }

        public void OnInteract(InputAction.CallbackContext context)
        {
            
        }

        public void OnJump(InputAction.CallbackContext context)
        {
            
        }

        public void OnMove(InputAction.CallbackContext context)
        {
            
        }
    }
}
