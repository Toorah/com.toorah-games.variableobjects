using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace Toorah.ScriptableVariables
{
    public abstract class ScriptableVariable<T> : BaseVariable
    {
        [SerializeField]
        private T m_default;
        [SerializeField]
        private T m_value;

        [SerializeField] bool m_isReadOnly;

        private void OnEnable()
        {
            m_value = m_default;
        }

        public VariableEvent OnValueChanged = new VariableEvent();

        [System.Serializable]
        public class VariableEvent : UnityEvent<T> { }

        public T Value
        {
            get => m_value;
            set
            {
                if(!m_value.Equals(value) && !m_isReadOnly)
                {
                    m_value = value;
                    OnValueChanged.Invoke(m_value);
                }
            }
        }

        public void SetValue(T value)
        {
            Value = value;
        }

        public void SetWithoutNotify(T value)
        {
            if(!m_isReadOnly)
                m_value = value;
        }

        public static implicit operator T(ScriptableVariable<T> var) => var.Value;
    }

    public abstract class VariableReference<T, V> where V : ScriptableVariable<T> 
    {
        [SerializeField] T m_value;
        [SerializeField] V m_variable;

        public T Value
        {
            get
            {
                if (m_variable)
                {
                    return m_variable.Value;
                }

                return m_value;
            }
            set
            {
                if (m_variable)
                {
                    m_variable.Value = value;
                }

                m_value = value;
            }
        }
    }

}
