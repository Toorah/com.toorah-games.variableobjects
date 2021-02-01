using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Toorah.ScriptableVariables
{
    [CreateAssetMenu(fileName = "AnimationCurve List Variable", menuName = "Scriptable Variables/List/AnimationCurve")]
    public class AnimationCurveListVariable : ListVariable<AnimationCurve>
    {

    }

    [System.Serializable]
    public class AnimationCurveListReference : VariableReference<List<AnimationCurve>, AnimationCurveListVariable> { }
    
}
