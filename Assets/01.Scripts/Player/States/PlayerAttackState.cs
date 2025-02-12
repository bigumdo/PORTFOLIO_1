using BGD.Agents;
using BGD.Animators;
using BGD.FSM;
using UnityEngine;

namespace BGD.Players
{
    public class PlayerAttackState : AgentState
    {
        private float _lastAttackTime = 0;
        private float _attackDelayTime;
        private int _attackComboCnt;

        private AgentMover _mover;
        private AgentAttackCompo _attackCompo;
        private Player _player;

        public PlayerAttackState(Agent agent, AnimParamSO animParam) : base(agent, animParam)
        {
            _player = agent as Player;
            _mover = agent.GetCompo<AgentMover>();
            _attackCompo = agent.GetCompo<AgentAttackCompo>();
        }

        public override void Enter()
        {
            base.Enter();
            if (_attackDelayTime + Time.time > _lastAttackTime
                || _attackComboCnt > 2)
            {
                _attackComboCnt = 0;
            }
            _renderer.SetParam(_player.attackCompoParam, _attackComboCnt);
            _mover.CanMove = false;
            _mover.StopImmediately(true);
        }
        private void SetAttackData()
        {
            float atkDirection = _renderer.FacingDirection;
            float xInput = _player.PlayerInput.InputDirection.x; //입력된 x방향
            if (Mathf.Abs(xInput) > 0)
                atkDirection = Mathf.Sign(xInput); // 키보드로 누르고 있는 방향을 우선한다.

        }

        public override void Update()
        {
            base.Update();
        }

        
    }
}
