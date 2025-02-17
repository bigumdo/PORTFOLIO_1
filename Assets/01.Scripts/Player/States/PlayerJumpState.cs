using BGD.Agents;
using BGD.Animators;
using BGD.FSM;
using BGD.StatSystem;
using UnityEngine;

namespace BGD.Players
{
    public class PlayerJumpState : PlayerAirState
    {
        private AgentStat _stat;

        public PlayerJumpState(Agent agent, AnimParamSO animParam) : base(agent, animParam)
        {
        }

        public override void Enter()
        {
            base.Enter();
            StatSO jumpPowerStat = _stat.GetStat(_player.jumpPowerStat);
            Vector2 jumpPower = new Vector2(0, jumpPowerStat.Value);
            _mover.AddForce(jumpPower);
        }

        public override void Update()
        {
            base.Update();
            if(_mover.IsGrounded)
            {
                _player.ChangeState(FSMState.IDLE);
            }
        }
    }
}
