using BGD.Agents;
using UnityEditor;
using UnityEngine;
using UnityEngine.UIElements;

namespace BGD.Casters
{
    public enum CastMethodType
    {
        Circle,
        Box,
        Ray
    }

    public enum RayDirection
    {
        Right,
        Left,
        Up,
        Down
    }


    public abstract class BaseCaster : MonoBehaviour
    {
        protected Agent _agent;

        public CastMethodType castMethodType;
        public CastTypeEnum castType;//ĳ��Ʈ Ÿ��
        public LayerMask targetLayer;//� ���� ĳ��Ʈ �� ���ΰ�

        public Vector2 castOffset;
        public Vector2 castSize;
        public RayDirection rayDirection;
        public float rayDistance;
        public float castRange;
        public int castCnt;//�󸶳� ĳ��Ʈ�� ���ΰ�


        public virtual void Initialize(Agent agent)
        {
            _agent = agent;
        }

        private void OnDrawGizmosSelected()
        {
            Gizmos.color = Color.green;
            Vector2 castDir = new Vector2(castOffset.x * _agent.GetCompo<AgentRenderer>().FacingDirection, castOffset.y);

            switch (castMethodType)
            {
                case CastMethodType.Circle:
                    Gizmos.DrawWireSphere((Vector2)transform.position + castOffset,castRange);
                    break;
                case CastMethodType.Box:
                    Gizmos.DrawWireCube((Vector2)transform.position + castOffset,castSize);
                    break;
                case CastMethodType.Ray:
                    Vector2 dir;
                    switch (rayDirection)
                    {
                        case RayDirection.Right:
                            dir = Vector2.right;
                            break;
                        case RayDirection.Left:
                            dir = Vector2.left;
                            break;
                        case RayDirection.Up:
                            dir = Vector2.up;
                            break;
                        case RayDirection.Down:
                            dir = Vector2.down;
                            break;
                        default:
                            dir = Vector2.right;
                            break;
                    }

                    Gizmos.DrawRay((Vector2)transform.position + castOffset, dir * rayDistance);
                    break;
            }
        }
    }
}
