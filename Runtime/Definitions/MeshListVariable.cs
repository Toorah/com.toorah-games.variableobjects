using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Toorah.ScriptableVariables
{
    [CreateAssetMenu(fileName = "Mesh List Variable", menuName = "Scriptable Variables/List/Mesh")]
    public class MeshListVariable : ListVariable<Mesh>
    {

    }

    [System.Serializable]
    public class MeshListReference : VariableReference<List<Mesh>, MeshListVariable> { }
    
}
