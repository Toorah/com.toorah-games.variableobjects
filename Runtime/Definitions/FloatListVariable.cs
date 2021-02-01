using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Toorah.ScriptableVariables
{
    [CreateAssetMenu(fileName = "Float List Variable", menuName = "Scriptable Variables/List/Float")]
    public class FloatListVariable : ListVariable<float>
    {

    }

    [System.Serializable]
    public class FloatListReference : VariableReference<List<float>, FloatListVariable> { }
    
}
