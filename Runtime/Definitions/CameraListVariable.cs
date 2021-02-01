using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Toorah.ScriptableVariables
{
    [CreateAssetMenu(fileName = "Camera List Variable", menuName = "Scriptable Variables/List/Camera")]
    public class CameraListVariable : ListVariable<Camera>
    {

    }

    [System.Serializable]
    public class CameraListReference : VariableReference<List<Camera>, CameraListVariable> { }
    
}
