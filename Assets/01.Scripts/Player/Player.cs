using BGD.Agents;
using BGD.FSM;
using BGD.Player;
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
        }
    }
}
