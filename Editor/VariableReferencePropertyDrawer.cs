using System;
using System.Collections;
using System.Collections.Generic;
using Toorah.ScriptableVariables;
using UnityEditor;
using UnityEngine;

namespace Toorah.ScribtableVariables.Editor
{
    [CustomPropertyDrawer(typeof(VariableReference<,>), true)]
    public class VariableReferencePropertyDrawer : PropertyDrawer
    {
        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
        {
            GUI.Box(position, "", EditorStyles.helpBox);
            position.y += 1;
            position.x += 2;
            position.width -= 2;



            position.height = EditorGUIUtility.singleLineHeight;

            var value = property.FindPropertyRelative("m_value");
            
            var variable = property.FindPropertyRelative("m_variable");

            EditorGUI.ObjectField(position, variable);
            position.y += position.height + 2;
            if(variable.objectReferenceValue != null)
            {
                using(var scope = new EditorGUI.ChangeCheckScope())
                {
                    var obj = new SerializedObject(variable.objectReferenceValue);
                    obj.Update();
                    var def = obj.FindProperty("m_default");

                    EditorGUI.PropertyField(position, def, new GUIContent("Value"));
                    if (scope.changed)
                    {
                        obj.ApplyModifiedProperties();
                        EditorUtility.SetDirty(variable.objectReferenceValue);
                        AssetDatabase.ImportAsset(AssetDatabase.GetAssetPath(variable.objectReferenceValue));
                    }
                }

            }
            else
            {
                EditorGUI.PropertyField(position, value);
            }
        }


        public override float GetPropertyHeight(SerializedProperty property, GUIContent label)
        {
            return EditorGUIUtility.singleLineHeight * 2 + 5;
        }
    }
}
