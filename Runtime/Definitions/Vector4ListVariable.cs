using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Toorah.ScriptableVariables
{
    [CreateAssetMenu(fileName = "Vector4 List Variable", menuName = "Scriptable Variables/List/Vector4")]
    public class Vector4ListVariable : ListVariable<Vector4>
    {

    }

    [System.Serializable]
    public class Vector4ListReference : VariableReference<List<Vector4>, Vector4ListVariable> { }
    
}
