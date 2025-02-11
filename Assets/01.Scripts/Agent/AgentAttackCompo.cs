using BGD.Casters;
using BGD.StatSystem;
using System.Collections.Generic;
using UnityEngine;

namespace BGD.Agents
{
    public class AgentAttackCompo : MonoBehaviour, IAgentComponent, IAfterInit
    {
        private Caster _caster;
        private AgentMover _mover;
        private AgentStat _stat;

        [SerializeField]private StatSO _damageStat;
        [SerializeField]private List<AttackDataSO> _attackDatas;


        public void Initialize(Agent agent)
        {
            _caster = agent.GetCompo<Caster>();
            _mover = agent.GetCompo<AgentMover>();
            _stat = agent.GetCompo<AgentStat>();
        }
        public void AfterInit()
        {
            _damageStat = _stat.GetStat(_damageStat);
        }



    }
}
