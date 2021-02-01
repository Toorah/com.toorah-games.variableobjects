using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Toorah.ScriptableVariables
{
    [CreateAssetMenu(fileName = "Bool Variable", menuName = "Scriptable Variables/Single/Bool")]
    public class BoolVariable : ScriptableVariable<bool>
    {

    }

    [System.Serializable]
    public class BoolReference : VariableReference<bool, BoolVariable> { }
    
}
