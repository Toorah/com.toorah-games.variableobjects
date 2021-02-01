using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Toorah.ScriptableVariables
{
    [CreateAssetMenu(fileName = "Color Variable", menuName = "Scriptable Variables/Single/Color")]
    public class ColorVariable : ScriptableVariable<Color>
    {

    }

    [System.Serializable]
    public class ColorReference : VariableReference<Color, ColorVariable> { }
    
}
