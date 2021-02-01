using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Toorah.ScriptableVariables
{
    [CreateAssetMenu(fileName = "TextAsset List Variable", menuName = "Scriptable Variables/List/TextAsset")]
    public class TextAssetListVariable : ListVariable<TextAsset>
    {

    }

    [System.Serializable]
    public class TextAssetListReference : VariableReference<List<TextAsset>, TextAssetListVariable> { }
    
}
