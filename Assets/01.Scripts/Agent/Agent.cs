using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Events;

namespace BGD.Agent
{
    public class Agent : MonoBehaviour
    {
        public UnityEvent OnHitEvent;
        public UnityEvent OnDeadEvent;

        public bool IsDead { get; set; }

        protected Dictionary<Type, IAgentComponent> _components;

        private void Awake()
        {
            _components = new Dictionary<Type, IAgentComponent>();
            GetComponentsInChildren<IAgentComponent>(true).ToList()
                .ForEach(component => _components.Add(component.GetType(), component));
        }
    }
}
