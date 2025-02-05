using BGD.Agents;
using BGD.Animators;
using BGD.FSM;

namespace BGD.Players
{
    public abstract class PlayerGroundState : AgentState
    {
        protected PlayerGroundState(Agent agent, AnimParamSO animParam) : base(agent, animParam)
        {
        }
    }
}
