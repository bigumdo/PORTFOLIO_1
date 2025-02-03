using BGD.Agents;
using BGD.Animators;
using BGD.FSM;
using UnityEngine;

namespace BGD.Players
{
    public class PlayerGroundState : AgentState
    {
        protected Player _player;
        public PlayerGroundState(Agent agent, AnimParamSO animParam) : base(agent, animParam)
        {
            agent = _player;
        }
    }
}
