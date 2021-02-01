using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Toorah.ScriptableVariables
{
    [CreateAssetMenu(fileName = "String List Variable", menuName = "Scriptable Variables/List/String")]
    public class StringListVariable : ListVariable<string>
    {

    }

    [System.Serializable]
    public class StringListReference : VariableReference<List<string>, StringListVariable> { }
    
}
