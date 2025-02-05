using BGD.Agents;
using BGD.Animators;
using BGD.FSM;
using System;
using UnityEngine;

namespace BGD.Players
{
    public class Player : Agent
    {
        public AgentStateListSO states;
        
        [field : SerializeField] public PlayerInputSO PlayerInput {get; private set;}

        private StateMachine _stateMachine;

        protected override void Awake()
        {
            base.Awake();
            _stateMachine = new StateMachine(this, states);
            _stateMachine.Initialize(FSMState.IDLE);
        }

        private void Update()
        {
            _stateMachine.currentState.Update();
        }

        public void ChangeState(FSMState changeState)
        {
            _stateMachine.ChangeState(changeState);
        }
    }
}
