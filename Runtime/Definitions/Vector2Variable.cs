using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Toorah.ScriptableVariables
{
    [CreateAssetMenu(fileName = "Vector2 Variable", menuName = "Scriptable Variables/Single/Vector2")]
    public class Vector2Variable : ScriptableVariable<Vector2>
    {

    }

    [System.Serializable]
    public class Vector2Reference : VariableReference<Vector2, Vector2Variable> { }
    
}
