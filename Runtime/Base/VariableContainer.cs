using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Toorah.ScriptableVariables
{

    [CreateAssetMenu(fileName = "Variable Container", menuName = "Scriptable Variables/Container", order = -1000)]
    public class VariableContainer : ScriptableObject
    {
        [SerializeField, HideInInspector] List<BaseVariable> m_variables = new List<BaseVariable>();
    }
}
