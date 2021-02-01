using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Toorah.ScriptableVariables
{
    [CreateAssetMenu(fileName = "Vector4 Variable", menuName = "Scriptable Variables/Single/Vector4")]
    public class Vector4Variable : ScriptableVariable<Vector4>
    {

    }

    [System.Serializable]
    public class Vector4Reference : VariableReference<Vector4, Vector4Variable> { }
    
}
