using UnityEngine;

namespace BGD.Combat
{
    public class CheckCaster : BaseCaster
    {
        public override bool Cast(Collider2D[] colliders)
        {
            return false;
        }
    }
}
