using BGD.Agents;
using BGD.Animators;
using BGD.FSM;
using UnityEngine;

namespace BGD.Players 
{
    public class PlayerIdleState : PlayerGroundState
    {
        public PlayerIdleState(Agent agent, AnimParamSO animParam) : base(agent, animParam)
        {
        }

        public override void Update()
        {
            base.Update();

        }
    }
}
