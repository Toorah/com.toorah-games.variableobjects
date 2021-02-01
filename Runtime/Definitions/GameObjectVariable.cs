using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Toorah.ScriptableVariables
{
    [CreateAssetMenu(fileName = "GameObject Variable", menuName = "Scriptable Variables/Single/GameObject")]
    public class GameObjectVariable : ScriptableVariable<GameObject>
    {

    }

    [System.Serializable]
    public class GameObjectReference : VariableReference<GameObject, GameObjectVariable> { }
    
}
