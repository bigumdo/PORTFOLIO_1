using UnityEngine;

namespace BGD.Casters
{
    public class CheckCaster : BaseCaster, IColliderCaster
    {
        public bool ColliderCast(Collider2D[] colliders)
        {
            Debug.Log("¼º°ø");
            return false;
        }
    }
}
