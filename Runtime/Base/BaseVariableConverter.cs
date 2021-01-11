using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using UnityEngine;

namespace Toorah.ScriptableVariables
{
    public abstract class BaseVariableConverter<T, U, V, W> : MonoBehaviour where V : ScriptableVariable<T> where W : ScriptableVariable<U>
    {
        [SerializeField] protected V m_source;
        [SerializeField] protected W m_target;


        /// <summary>
        /// Make sure to call <code>base.OnEnable();</code>
        /// </summary>
        protected virtual void OnEnable()
        {
            m_source.OnValueChanged.AddListener(SourceToTarget);
            m_target.OnValueChanged.AddListener(TargetToSource);
        }


        /// <summary>
        /// Make sure to call <code>base.OnDisable();</code>
        /// </summary>
        protected virtual void OnDisable()
        {
            m_source.OnValueChanged.RemoveListener(SourceToTarget);
            m_target.OnValueChanged.RemoveListener(TargetToSource);
        }


        public abstract void SourceToTarget(T t);
        public abstract void TargetToSource(U t);
    }
}
