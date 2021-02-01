using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Toorah.ScriptableVariables
{
    [CreateAssetMenu(fileName = "ScriptableObject List Variable", menuName = "Scriptable Variables/List/ScriptableObject")]
    public class ScriptableObjectListVariable : ListVariable<ScriptableObject>
    {

    }

    [System.Serializable]
    public class ScriptableObjectListReference : VariableReference<List<ScriptableObject>, ScriptableObjectListVariable> { }
    
}
