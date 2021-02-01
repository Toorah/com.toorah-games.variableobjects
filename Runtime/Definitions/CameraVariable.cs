using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Toorah.ScriptableVariables
{
    [CreateAssetMenu(fileName = "Camera Variable", menuName = "Scriptable Variables/Single/Camera")]
    public class CameraVariable : ScriptableVariable<Camera>
    {

    }

    [System.Serializable]
    public class CameraReference : VariableReference<Camera, CameraVariable> { }
    
}
