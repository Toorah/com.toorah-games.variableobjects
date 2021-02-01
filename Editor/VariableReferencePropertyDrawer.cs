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
        bool m_sync;

        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
        {
            GUI.Box(position, "", EditorStyles.helpBox);
            position.y += 1;
            position.x += 2;
            position.width -= 2;

            position.height = EditorGUIUtility.singleLineHeight;
            EditorGUI.LabelField(position, label, EditorStyles.boldLabel);
            position.y += position.height + 2;
            position.x += 8;
            position.width -= 10;
            var value = property.FindPropertyRelative("m_value");
            
            var variable = property.FindPropertyRelative("m_variable");

            if(variable.objectReferenceValue != null)
            {
                EditorGUI.ObjectField(position, variable);
                position.y += position.height + 2;
                using(var scope = new EditorGUI.ChangeCheckScope())
                {
                    if (variable.objectReferenceValue == null)
                        return;
                    var obj = new SerializedObject(variable.objectReferenceValue);
                    obj.Update();
                    var val = obj.FindProperty("m_value");
                    var def = obj.FindProperty("m_default");
                    position.width *= 0.5f;
                    position.width -= 1;
                    EditorGUI.PropertyField(position, def, new GUIContent("Default"));
                    position.x += position.width + 2;
                    EditorGUI.PropertyField(position, val, new GUIContent("Value"));
                    if (scope.changed)
                    {
                        obj.ApplyModifiedProperties();
                        EditorUtility.SetDirty(variable.objectReferenceValue);
                        AssetDatabase.SaveAssets();
                        AssetDatabase.Refresh();
                    }
                }

            }
            else
            {
                position.width -= 71;
                EditorGUI.PropertyField(position, value);
                position.x += position.width+1;
                position.width = 70;
                EditorGUI.PropertyField(position, variable, GUIContent.none);

            }
        }


        public override float GetPropertyHeight(SerializedProperty property, GUIContent label)
        {
            var variable = property.FindPropertyRelative("m_variable");

            if (variable.objectReferenceValue != null)
            {
                return EditorGUIUtility.singleLineHeight * 3 + 7;
            }
            else
            {
                return EditorGUIUtility.singleLineHeight * 2 + 5;
            }
        }
    }
}
