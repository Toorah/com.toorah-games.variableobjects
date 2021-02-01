using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Toorah.ScriptableVariables
{
    [CreateAssetMenu(fileName = "Texture2D List Variable", menuName = "Scriptable Variables/List/Texture2D")]
    public class Texture2DListVariable : ListVariable<Texture2D>
    {

    }

    [System.Serializable]
    public class Texture2DListReference : VariableReference<List<Texture2D>, Texture2DListVariable> { }
    
}
