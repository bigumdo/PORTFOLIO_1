using BGD.Agents;
using BGD.Animators;
using UnityEngine;

namespace BGD.FSM
{
    public abstract class AgentState
    {
        protected Agent _agent;
        protected AnimParamSO _animParam;
        protected bool _isEndTrigger;

        protected AgentRenderer _renderer;
        protected AgentAnimationTrigger _animTrigger;

        public AgentState(Agent agent,AnimParamSO animParam)
        {
            _agent = agent;
            _animParam = animParam;
            _renderer = agent.GetCompo<AgentRenderer>();
            _animTrigger = _agent.GetCompo<AgentAnimationTrigger>(true);
        }

        public virtual void Enter()
        {
            _isEndTrigger = false;
            _renderer.SetParam(_animParam, true);
            _animTrigger.OnAnimationEndTrigger += AnimationEndTrigger;
        }

        public virtual void Exit()
        {
            _renderer.SetParam(_animParam, false);
            _animTrigger.OnAnimationEndTrigger -= AnimationEndTrigger;
        }

        public virtual void Update()
        {

        }

        public virtual void AnimationEndTrigger()
        {
            _isEndTrigger = true;
        }
    }
}
