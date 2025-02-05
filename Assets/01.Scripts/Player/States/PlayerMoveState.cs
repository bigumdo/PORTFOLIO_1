using BGD.Agents;
using BGD.Animators;
using BGD.FSM;

namespace BGD.Players
{
    public class PlayerMoveState : PlayerGroundState
    {
        public PlayerMoveState(Agent agent, AnimParamSO animParam) : base(agent, animParam)
        {
        }

        public override void Update()
        {
            base.Update();
            //_mover.SetMovement(_player.PlayerInput.InputDirection.x);
        }
    }
}
