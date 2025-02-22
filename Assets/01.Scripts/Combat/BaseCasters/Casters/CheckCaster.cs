using BGD.Map;
using UnityEngine;

namespace BGD.Casters
{
    public class CheckCaster : BaseCaster, IColliderCaster
    {
        public bool ColliderCast(Collider2D[] colliders)
        {
            if (colliders[0].TryGetComponent(out BaseGround ground))
            {

                _agent.transform.rotation = Quaternion.Euler(0, 0, ground.angle);
            }
            return true;
        }
    }
}
