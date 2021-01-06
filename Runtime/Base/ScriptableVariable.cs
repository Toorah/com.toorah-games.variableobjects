using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace Toorah.ScriptableVariables
{
    public abstract class ScriptableVariable<T> : BaseVariable
    {
        [SerializeField]
        private T m_value;

        public VariableEvent OnValueChanged = new VariableEvent();

        [System.Serializable]
        public class VariableEvent : UnityEvent<T> { }

        public T Value
        {
            get => m_value;
            set
            {
                if(!m_value.Equals(value))
                {
                    m_value = value;
                    OnValueChanged.Invoke(m_value);
                }
            }
        }
    }
}
