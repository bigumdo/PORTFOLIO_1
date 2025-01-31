using BGD.Agents;
using BGD.Combat;
using UnityEditor;
using UnityEngine;

namespace BGD.Combat
{
    public enum CastMethodType
    {
        Circle,
        Box
    }



    public abstract class BaseCaster : MonoBehaviour
    {
        protected Agent _agent;

        public CastMethodType castMethodType;
        public CastTypeEnum castType;//ĳ��Ʈ Ÿ��
        public LayerMask targetLayer;//� ���� ĳ��Ʈ �� ���ΰ�

        public Vector2 castOffset;
        public Vector2 castSize;
        public float castRange;
        public int castCnt;//�󸶳� ĳ��Ʈ�� ���ΰ�

        public abstract bool Cast(Collider2D[] colliders); //��ӹ޾Ƽ� ���������ϵ��� ����
        public virtual void Initialize(Agent agent)
        {
            _agent = agent;
        }

        [ContextMenu("TestMethod")]
        public void TestMethod()
        {
            Debug.Log(castRange);
        }

        private void OnDrawGizmosSelected()
        {
            Gizmos.color = Color.green;
            switch (castMethodType)
            {
                case CastMethodType.Circle:
                    Gizmos.DrawWireSphere((Vector2)transform.position + castOffset,castRange);
                    break;
                case CastMethodType.Box:
                    Gizmos.DrawWireCube((Vector2)transform.position + castOffset,castSize);
                    break;
            }
        }
    }
}
