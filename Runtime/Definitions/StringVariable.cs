using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Toorah.ScriptableVariables
{
    [CreateAssetMenu(fileName = "String Variable", menuName = "Scriptable Variables/Single/String")]
    public class StringVariable : ScriptableVariable<string>
    {

    }

    [System.Serializable]
    public class StringReference : VariableReference<string, StringVariable> { }
    
}
