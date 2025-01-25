using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;

namespace BGD.FSM
{
    public enum FSMState
    {
        Idle,
        Move,
        Dead,
        Attack,
        Battle
    }

    [CreateAssetMenu(menuName = "SO/FSM/AgentStateListSO")]
    public class AgentStateListSO : ScriptableObject
    {
        public List<StateSO> states = new List<StateSO>();
    }
}
