using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Toorah.ScriptableVariables
{
    [CreateAssetMenu(fileName = "Int Variable", menuName = "Scriptable Variables/Single/Int")]
    public class IntVariable : ScriptableVariable<int>
    {

    }

    [System.Serializable]
    public class IntReference : VariableReference<int, IntVariable> { }
    
}
