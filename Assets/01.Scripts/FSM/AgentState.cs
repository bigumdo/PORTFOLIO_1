using BGD.Agents;
using BGD.Animators;
using UnityEngine;

namespace BGD.FSM
{
    public class AgentState
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
            _animTrigger = _agent.GetCompo<AgentAnimationTrigger>(true);
            _renderer = agent.GetCompo<AgentRenderer>();
        }

        public virtual void Enter()
        {
            _renderer.SetParam(_animParam, true);
            _isEndTrigger = false;
            _animTrigger.OnAnimationEndTrigger += AnimationEndTrigger;
        }

        public virtual void Exit()
        {
            _renderer.SetParam(_animParam, false);
            _animTrigger.OnAnimationEndTrigger += AnimationEndTrigger;
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
