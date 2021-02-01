using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Toorah.ScriptableVariables
{
    [CreateAssetMenu(fileName = "GameObject List Variable", menuName = "Scriptable Variables/List/GameObject")]
    public class GameObjectListVariable : ListVariable<GameObject>
    {

    }

    [System.Serializable]
    public class GameObjectListReference : VariableReference<List<GameObject>, GameObjectListVariable> { }
    
}
