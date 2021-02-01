using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Toorah.ScriptableVariables
{
    [CreateAssetMenu(fileName = "Rigidbody List Variable", menuName = "Scriptable Variables/List/Rigidbody")]
    public class RigidbodyListVariable : ListVariable<Rigidbody>
    {

    }

    [System.Serializable]
    public class RigidbodyListReference : VariableReference<List<Rigidbody>, RigidbodyListVariable> { }
    
}
