using UnityEngine;

namespace BGD.Agents
{
    public class AgentMover : MonoBehaviour, IAgentComponent
    {
        public bool CanMove { get; set;}

        private Rigidbody2D _rigid;
        private Agent _agent;
        private AgentRenderer _agentRenderer;

        public void Initialize(Agent agent)
        {
        }

        public void Movement()
        {

        }

    }
}
