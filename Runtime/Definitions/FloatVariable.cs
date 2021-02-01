using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Toorah.ScriptableVariables
{
    [CreateAssetMenu(fileName = "Float Variable", menuName = "Scriptable Variables/Single/Float")]
    public class FloatVariable : ScriptableVariable<float>
    {

    }

    [System.Serializable]
    public class FloatReference : VariableReference<float, FloatVariable> { }
    
}
