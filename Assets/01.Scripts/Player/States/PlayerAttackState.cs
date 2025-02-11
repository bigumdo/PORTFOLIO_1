using BGD.Agents;
using BGD.Animators;
using BGD.FSM;
using UnityEngine;

namespace BGD.Players
{
    public class PlayerAttackState : AgentState
    {
        public PlayerAttackState(Agent agent, AnimParamSO animParam) : base(agent, animParam)
        {
        }
    }
}
