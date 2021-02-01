using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Toorah.ScriptableVariables
{
    [CreateAssetMenu(fileName = "Texture2D Variable", menuName = "Scriptable Variables/Single/Texture2D")]
    public class Texture2DVariable : ScriptableVariable<Texture2D>
    {

    }

    [System.Serializable]
    public class Texture2DReference : VariableReference<Texture2D, Texture2DVariable> { }
    
}
