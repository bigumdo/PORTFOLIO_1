using BGD.Agents;
using BGD.Animators;
using BGD.StatSystem;
using UnityEngine;

namespace BGD.Players
{
    public class PlayerFallState : PlayerAirState
    {
        public PlayerFallState(Agent agent, AnimParamSO animParam) : base(agent, animParam)
        {
        }
    }
}
