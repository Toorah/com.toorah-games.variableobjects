using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Toorah.ScriptableVariables
{
    [CreateAssetMenu(fileName = "Gradient Variable", menuName = "Scriptable Variables/Single/Gradient")]
    public class GradientVariable : ScriptableVariable<Gradient>
    {

    }

    [System.Serializable]
    public class GradientReference : VariableReference<Gradient, GradientVariable> { }
    
}
