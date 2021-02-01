using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Toorah.ScriptableVariables
{
    [CreateAssetMenu(fileName = "AnimationCurve Variable", menuName = "Scriptable Variables/Single/AnimationCurve")]
    public class AnimationCurveVariable : ScriptableVariable<AnimationCurve>
    {

    }

    [System.Serializable]
    public class AnimationCurveReference : VariableReference<AnimationCurve, AnimationCurveVariable> { }
    
}
