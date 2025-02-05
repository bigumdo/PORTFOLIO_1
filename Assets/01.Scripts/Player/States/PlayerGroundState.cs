using BGD.Agents;
using BGD.Animators;
using BGD.FSM;

namespace BGD.Players
{
    public abstract class PlayerGroundState : AgentState
    {
        protected AgentMover _mover;
        protected Player _player;
        protected PlayerGroundState(Agent agent, AnimParamSO animParam) : base(agent, animParam)
        {
            _player = agent as Player;
            _mover = agent.GetCompo<AgentMover>();  
        }
    }
}
