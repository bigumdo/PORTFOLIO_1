using BGD.Agents;
using UnityEngine;

namespace BGD.FSM
{
    public class AgentState
    {
        protected Agent _agent;
        protected Animator _animator;
        protected bool _isEndTrigger;

        protected AgentRenderer _renderer;
        protected AgentAnimationTrigger _animTrigger;

        public void Initialize(Agent agent)
        {
            _agent = agent;
            _animator = agent.GetComponent<Animator>();
            _animTrigger = agent.GetCompo<AgentAnimationTrigger>();
            _renderer = agent.GetCompo<AgentRenderer>();
        }
    }
}
