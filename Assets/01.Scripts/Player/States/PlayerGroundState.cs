using BGD.Agents;
using BGD.Animators;
using BGD.FSM;
using UnityEngine;

namespace BGD.Players
{
    public class PlayerGroundState : AgentState
    {
        protected Player _player;
        protected AgentMover _mover;
        public PlayerGroundState(Agent agent, AnimParamSO animParam) : base(agent, animParam)
        {
            agent = _player;
            _mover = agent.GetCompo<AgentMover>();
        }
    }
}
