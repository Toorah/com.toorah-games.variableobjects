using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Toorah.ScriptableVariables
{
    [CreateAssetMenu(fileName = "Material List Variable", menuName = "Scriptable Variables/List/Material")]
    public class MaterialListVariable : ListVariable<Material>
    {

    }

    [System.Serializable]
    public class MaterialListReference : VariableReference<List<Material>, MaterialListVariable> { }
    
}
