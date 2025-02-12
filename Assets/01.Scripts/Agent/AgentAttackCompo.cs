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
        private Dictionary<string, AttackDataSO> _attackDictionary;

        [SerializeField]private StatSO _damageStat;
        [SerializeField]private List<AttackDataSO> _attackDatas;


        public void Initialize(Agent agent)
        {
            _caster = agent.GetCompo<Caster>();
            _mover = agent.GetCompo<AgentMover>();
            _stat = agent.GetCompo<AgentStat>();
            _attackDictionary=  new Dictionary<string, AttackDataSO>();
            _attackDatas.ForEach(data => _attackDictionary.Add(data.dataName,data));
        }
        public void AfterInit()
        {
            _damageStat = _stat.GetStat(_damageStat);
        }

        public AttackDataSO GetAttackData(string dataName)
        {
            AttackDataSO data = _attackDictionary.GetValueOrDefault(dataName,null);
            Debug.Assert(data!=null,$"{dataName}없는 데이터 dlqslek.");
            return data;
        }

    }
}
