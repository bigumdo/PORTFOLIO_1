using BGD.Agents;
using BGD.Animators;
using BGD.FSM;
using UnityEngine;

namespace BGD.Players 
{
    public class PlayerIdleState : PlayerGroundState
    {
        public PlayerIdleState(Agent agent, AnimParamSO animParam) : base(agent, animParam)
        {
        }

        public override void Enter()
        {
            base.Enter();
            _mover.StopImmediately();
        }

        public override void Update()
        {
            base.Update();
            if(Mathf.Abs(_player.PlayerInput.InputDirection.x) > 0.5f)
            {
                _player.ChangeState(FSMState.Move);
            }
        }
    }
}
