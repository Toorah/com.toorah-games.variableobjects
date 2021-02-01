using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Toorah.ScriptableVariables
{
    [CreateAssetMenu(fileName = "Color List Variable", menuName = "Scriptable Variables/List/Color")]
    public class ColorListVariable : ListVariable<Color>
    {

    }

    [System.Serializable]
    public class ColorListReference : VariableReference<List<Color>, ColorListVariable> { }
    
}
