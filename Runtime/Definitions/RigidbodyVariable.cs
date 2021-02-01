using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Toorah.ScriptableVariables
{
    [CreateAssetMenu(fileName = "Rigidbody Variable", menuName = "Scriptable Variables/Single/Rigidbody")]
    public class RigidbodyVariable : ScriptableVariable<Rigidbody>
    {

    }

    [System.Serializable]
    public class RigidbodyReference : VariableReference<Rigidbody, RigidbodyVariable> { }
    
}
