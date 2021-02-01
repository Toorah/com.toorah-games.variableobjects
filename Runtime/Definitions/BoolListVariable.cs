using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Toorah.ScriptableVariables
{
    [CreateAssetMenu(fileName = "Bool List Variable", menuName = "Scriptable Variables/List/Bool")]
    public class BoolListVariable : ListVariable<bool>
    {

    }

    [System.Serializable]
    public class BoolListReference : VariableReference<List<bool>, BoolListVariable> { }
    
}
