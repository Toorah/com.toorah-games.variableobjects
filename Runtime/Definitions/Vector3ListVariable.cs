using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Toorah.ScriptableVariables
{
    [CreateAssetMenu(fileName = "Vector3 List Variable", menuName = "Scriptable Variables/List/Vector3")]
    public class Vector3ListVariable : ListVariable<Vector3>
    {

    }

    [System.Serializable]
    public class Vector3ListReference : VariableReference<List<Vector3>, Vector3ListVariable> { }
    
}
