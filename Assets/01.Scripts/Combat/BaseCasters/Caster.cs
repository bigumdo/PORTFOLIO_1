using BGD.Agents;
using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

namespace BGD.Casters
{
    public enum CastTypeEnum // CastŸ��
    {
        Damge,
        AttackRnage,
        PlayerAttack,
        Ground,
        Wall
    }

    public class Caster : MonoBehaviour, IAgentComponent
    {
        private Agent _agent;
        private Dictionary<CastTypeEnum, BaseCaster> _casters; //Cast�� ����Dictionary
        private Collider2D[] _castTargets; // ������ ������Ʈ�� Collider�� ��� ����
        private AgentRenderer _agentRenderer;
        private Vector2 _agentDir;
        [SerializeField] private BaseCaster _currentCast;//���� �������� Caster�� ��� ���� ����

        public void Initialize(Agent agent)
        {
            _agent = agent;
            _agentRenderer = agent.GetCompo<AgentRenderer>();
            _casters = new Dictionary<CastTypeEnum, BaseCaster>();
            BaseCaster[] casts = GetComponentsInChildren<BaseCaster>();//������ ĳ��Ʈ ������ ������
            foreach (BaseCaster c in casts)
            {
                c.Initialize(agent);
                _casters.Add(c.castType, c); // Enum���� cast�����ϱ� ���� �߰�
            }
        }

        public bool Cast(CastTypeEnum castType, bool multiCast = true)
        {
            _currentCast = _casters.GetValueOrDefault(castType);//Ÿ�Կ� �´� Cast�� ���� �´�.
            Debug.Assert(_currentCast != null, $"{castType}cast���� ���ư�");// CurrentCast�� Null�ƴ϶�� ����

            switch (_currentCast.castMethodType)
            {
                case CastMethodType.Circle:
                    return CircleCast();
                case CastMethodType.Box:
                    return BoxCast();
                case CastMethodType.Ray:
                    return RayCast();
            }
            return false;
        }

        private bool RayCast()
        {
            switch (_currentCast.rayDirection)
            {
                case RayDirection.Right:
                    _agentDir = Vector2.right;
                    break;
                case RayDirection.Left:
                    _agentDir = Vector2.left;
                    break;
                case RayDirection.Up:
                    _agentDir = Vector2.up;
                    break;
                case RayDirection.Down:
                    _agentDir = Vector2.down;
                    break;
            }
            RaycastHit2D hit = Physics2D.Raycast((Vector2)transform.position, _agentDir, _currentCast.rayDistance);

            if (hit.collider != null)
            {
                if(_currentCast is IRaycastCaster rayCaster)
                {
                    rayCaster.RayCast(hit);
                }
            }
            return false;
        }

        private bool CircleCast()//���ϴ� ĳ��Ʈ Ÿ�԰� �󸶳� üũ������ �޴´�.
        {
            _agentDir = new Vector2(_currentCast.castOffset.x * _agentRenderer.FacingDirection, _currentCast.castOffset.y);
            _castTargets = Physics2D.OverlapCircleAll((Vector2)_currentCast.transform.position + _agentDir, _currentCast.castRange,
                 _currentCast.targetLayer, 0, _currentCast.castCnt);//cat������ �°� OverapCircleAllüũ
            if (_castTargets.Length > 0)
            {
                if (_currentCast is IColliderCaster colliderCaster)
                {
                    return colliderCaster.ColliderCast(_castTargets);
                }
            }
            return false;
        }

        private bool BoxCast()
        {
            _agentDir = new Vector2(_currentCast.castOffset.x * _agentRenderer.FacingDirection, _currentCast.castOffset.y);
            _castTargets = Physics2D.OverlapBoxAll((Vector2)_currentCast.transform.position + _agentDir, _currentCast.castSize,
                 0, _currentCast.targetLayer,0,_currentCast.castCnt);//cat������ �°� OverapCircleAllüũ
            if (_castTargets.Length > 0)
            {
                if (_currentCast is IColliderCaster colliderCaster)
                {
                    return colliderCaster.ColliderCast(_castTargets);
                }
            }
            return false;
        }
    }
}