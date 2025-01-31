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
        public CastTypeEnum castType;//캐스트 타입
        public LayerMask targetLayer;//어떤 것을 캐스트 할 것인가

        public Vector2 castOffset;
        public Vector2 castSize;
        public float castRange;
        public int castCnt;//얼마나 캐스트할 것인가

        public abstract bool Cast(Collider2D[] colliders); //상속받아서 구현가능하도록 설게
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
