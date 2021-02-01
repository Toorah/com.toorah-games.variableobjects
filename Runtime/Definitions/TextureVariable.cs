using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Toorah.ScriptableVariables
{
    [CreateAssetMenu(fileName = "Texture Variable", menuName = "Scriptable Variables/Single/Texture")]
    public class TextureVariable : ScriptableVariable<Texture>
    {

    }

    [System.Serializable]
    public class TextureReference : VariableReference<Texture, TextureVariable> { }
    
}
