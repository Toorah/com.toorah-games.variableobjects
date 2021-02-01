using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Toorah.ScriptableVariables
{
    [CreateAssetMenu(fileName = "Texture List Variable", menuName = "Scriptable Variables/List/Texture")]
    public class TextureListVariable : ListVariable<Texture>
    {

    }

    [System.Serializable]
    public class TextureListReference : VariableReference<List<Texture>, TextureListVariable> { }
    
}
