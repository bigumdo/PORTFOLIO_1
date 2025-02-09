using BGD.Agents;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BGD.Casters
{
    public class PlayerDamageCaster : BaseCaster, IColliderCaster
    {
        [SerializeField] protected int _damage;

        public  bool ColliderCast(Collider2D[] colliders)
        {
            for (int i = 0; i < colliders.Length; i++)
            {
                if (colliders[i].TryGetComponent(out AgentHealth health))
                {
                    //���߿� ������ ������ ���� �Ҳ���
                    health.ApplyDamage(_damage);
                }
            }
            return false;
        }
    }
}
