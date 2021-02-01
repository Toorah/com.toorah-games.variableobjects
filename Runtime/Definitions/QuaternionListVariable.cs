using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Toorah.ScriptableVariables
{
    [CreateAssetMenu(fileName = "Quaternion List Variable", menuName = "Scriptable Variables/List/Quaternion")]
    public class QuaternionListVariable : ListVariable<Quaternion>
    {

    }

    [System.Serializable]
    public class QuaternionListReference : VariableReference<List<Quaternion>, QuaternionListVariable> { }
    
}
