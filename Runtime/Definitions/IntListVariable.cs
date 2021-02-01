using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Toorah.ScriptableVariables
{
    [CreateAssetMenu(fileName = "Int List Variable", menuName = "Scriptable Variables/List/Int")]
    public class IntListVariable : ListVariable<int>
    {

    }

    [System.Serializable]
    public class IntListReference : VariableReference<List<int>, IntListVariable> { }
    
}
