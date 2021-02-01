using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Toorah.ScriptableVariables
{
    [CreateAssetMenu(fileName = "Vector2 List Variable", menuName = "Scriptable Variables/List/Vector2")]
    public class Vector2ListVariable : ListVariable<Vector2>
    {

    }

    [System.Serializable]
    public class Vector2ListReference : VariableReference<List<Vector2>, Vector2ListVariable> { }
    
}
