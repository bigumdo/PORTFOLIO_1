using BGD.Agents;
using BGD.Animators;
using BGD.FSM;
using System;

namespace BGD.Players
{
    public abstract class PlayerGroundState : AgentState
    {
        protected AgentMover _mover;
        protected Player _player;
        protected PlayerGroundState(Agent agent, AnimParamSO animParam) : base(agent, animParam)
        {
            _player = agent as Player;
            _mover = agent.GetCompo<AgentMover>();
        }

        public override void Enter()
        {
            base.Enter();
            _player.PlayerInput.AttackEvent += HandleAttackEvent;
            _player.PlayerInput.JumpEvent += HandleJumpEvent;
        }

        private void HandleJumpEvent()
        {
            _player.ChangeState(FSMState.JUMP);
        }

        private void HandleAttackEvent()
        {
            _player.ChangeState(FSMState.ATTACK);
        }
    }
}
