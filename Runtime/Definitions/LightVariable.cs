using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Toorah.ScriptableVariables
{
    [CreateAssetMenu(fileName = "Light Variable", menuName = "Scriptable Variables/Single/Light")]
    public class LightVariable : ScriptableVariable<Light>
    {

    }

    [System.Serializable]
    public class LightReference : VariableReference<Light, LightVariable> { }
    
}
