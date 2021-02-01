using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Toorah.ScriptableVariables
{
    [CreateAssetMenu(fileName = "Mesh Variable", menuName = "Scriptable Variables/Single/Mesh")]
    public class MeshVariable : ScriptableVariable<Mesh>
    {

    }

    [System.Serializable]
    public class MeshReference : VariableReference<Mesh, MeshVariable> { }
    
}
