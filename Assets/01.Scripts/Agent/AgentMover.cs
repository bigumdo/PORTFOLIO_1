using BGD.Combat;
using BGD.FSM;
using BGD.StatSystem;
using System;
using UnityEngine;

namespace BGD.Agents
{
    public class AgentMover : MonoBehaviour, IAgentComponent, IAfterInit
    {
        public Vector2 Velocity => _rbcompo.linearVelocity;
        public bool CanMove { get; set; } = true;
        public bool IsGrounded { get; set;}
        public float LimitYSpeed { get; set;}

        [Header("MoveStat")]
        [SerializeField] private StatSO _moveSpeedStat;
        [SerializeField] private float _moveSpeed;

        [SerializeField] private LayerMask _layerMask;
        [SerializeField] private float _groundCheckWidth, _wallCheckerWidth, _grabWallCheckerWidth;

        [Header("AnimParams")]
        [SerializeField] private StatSO _ySpeedParam;

        private Rigidbody2D _rbcompo;
        private Agent _agent;
        private AgentRenderer _renderer;
        private AgentStat _stat;
        private Caster _caster;

        private float _xMovement;

        private Collider2D _collider;

        public void Initialize(Agent agent)
        {
            _agent = agent;
            _rbcompo = agent.GetComponent<Rigidbody2D>();
            _renderer = agent.GetCompo<AgentRenderer>();
            _stat = agent.GetCompo<AgentStat>();
            _caster = agent.GetCompo<Caster>();
            _collider = agent.GetComponent<Collider2D>();
        }

        public void AfterInit()
        {
            _stat.MoveSpeedStat.OnValueChange += HandleMoveSpeedChange;
            _moveSpeed = _stat.MoveSpeedStat.Value;
            LimitYSpeed = 40f;
        }

        private void OnDestroy()
        {
            _stat.MoveSpeedStat.OnValueChange -= HandleMoveSpeedChange;
        }

        private void HandleMoveSpeedChange(StatSO stat, float current, float previous)
        {
            _moveSpeed = current;
        }

        public void AddForceToAgent(Vector2 force, ForceMode2D forceMode = ForceMode2D.Impulse)
        {
            _rbcompo.AddForce(force, forceMode);
        }

        public void AddForce(Vector2 force, ForceMode2D forceMode2D = ForceMode2D.Impulse)
        {
            _rbcompo.AddForce(force, forceMode2D);
        }

        public void StopImmediately(bool resetYAxis = false)
        {
            if(resetYAxis)
            {
                _rbcompo.linearVelocity = Vector2.zero;
            }
            else
            {
                _rbcompo.linearVelocityX = 0;
            }
        }

        public void SetMovement(float xMovement) => _xMovement = xMovement;

        public void FixedUpdate()
        {
            CheckGround();
            MoveCharacter();

            _rbcompo.linearVelocityY = Math.Clamp(_rbcompo.linearVelocityY, -LimitYSpeed, LimitYSpeed);
        }

        private void MoveCharacter()
        {
            if(CanMove)
            {
                _rbcompo.linearVelocityX = _xMovement * _moveSpeed;
            }

            _renderer.FlipControl(_xMovement);

        }

        private void CheckGround()
        {
            IsGrounded = _caster.Cast(CastTypeEnum.Ground);
        }

        private void IsWallDetected()
        {

        }

        public void Movement()
        {

        }

    }
}
