using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Toorah.ScriptableVariables
{
    [CreateAssetMenu(fileName = "Vector3 Variable", menuName = "Scriptable Variables/Single/Vector3")]
    public class Vector3Variable : ScriptableVariable<Vector3>
    {

    }

    [System.Serializable]
    public class Vector3Reference : VariableReference<Vector3, Vector3Variable> { }
    
}
