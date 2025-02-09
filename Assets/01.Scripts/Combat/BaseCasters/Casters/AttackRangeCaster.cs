using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BGD.Casters
{
    public class AttackRangeCaster : BaseCaster, IColliderCaster
    {
        public bool ColliderCast(Collider2D[] colliders)
        {
            return true;
        }
    }
}
