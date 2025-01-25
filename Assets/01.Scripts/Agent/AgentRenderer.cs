using BGD.Animators;
using UnityEngine;

namespace BGD.Agents
{
    public class AgentRenderer : MonoBehaviour, IAgentComponent
    {
        public float FacingDirection { get; private set; }

        private Agent _agent;
        private Animator _animator;
        private SpriteRenderer _spriteRenderer;

        public void Initialize(Agent agent)
        {
            _agent = agent;
            _animator = agent.GetComponent<Animator>();
            _spriteRenderer = agent.GetComponent<SpriteRenderer>();
        }

        public void SetParam(AnimParamSO paramSO, bool value) => _animator.SetBool(paramSO.hashValue, value);
        public void SetParam(AnimParamSO paramSO, float value) => _animator.SetFloat(paramSO.hashValue, value);
        public void SetParam(AnimParamSO paramSO, int value) => _animator.SetInteger(paramSO.hashValue, value);
        public void SetParam(AnimParamSO paramSO) => _animator.SetTrigger(paramSO.hashValue);

        public void FlipControl(float xMove)
        {
            if (Mathf.Abs(FacingDirection + xMove) < 0.5f)
                Flip();
        }

        public void Flip()
        {

        }

    }
}
