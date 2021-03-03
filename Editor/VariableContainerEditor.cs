using System;
using System.Collections;
using System.Collections.Generic;
using Toorah.ScriptableVariables;
using UnityEditor;
using UnityEditorInternal;
using UnityEngine;
using UnityEditor.IMGUI.Controls;
using Object = UnityEngine.Object;
using System.Linq;

namespace Toorah.ScribtableVariables.Editor
{

    [CustomEditor(typeof(VariableContainer))]
    public class VariableContainerEditor : UnityEditor.Editor
    {
        SerializedProperty m_variables;
        ReorderableList m_list;
        Object m_selection;
        SerializedObject m_serializedSelection;
        UnityEditor.Editor m_selectionEditor;

        List<Type> m_allTypes = new List<Type>();
        List<string> m_allTypeNames = new List<string>();
        int m_allTypeIndex = 0;
        string m_newVarName;
        BaseVariable m_addFromExternal;
        private void OnEnable()
        {
            m_variables = serializedObject.FindProperty(nameof(m_variables));
            m_list = new ReorderableList(serializedObject, m_variables, true, true, false, false);
            m_list.drawHeaderCallback += DrawHeader;
            m_list.drawElementCallback += DrawElement;
            m_list.onSelectCallback += OnSelectElement;
            m_list.onRemoveCallback += OnRemove;
            m_list.elementHeightCallback += ElementHeight;

            m_selection = null;


            m_allTypes = AppDomain.CurrentDomain.GetAssemblies()
                       .SelectMany(assembly => assembly.GetTypes())
                       .Where(type => type.IsSubclassOf(typeof(BaseVariable)) && !type.IsAbstract ).ToList();

            m_allTypeNames = m_allTypes.ConvertAll(x => x.Name);
        }

        private void OnRemove(ReorderableList list)
        {
            if(list.index != -1)
            {
                var e = m_variables.GetArrayElementAtIndex(list.index);
                var o = e.objectReferenceValue;
                if(o != null)
                {
                    m_variables.DeleteArrayElementAtIndex(list.index);
                    AssetDatabase.RemoveObjectFromAsset(o);
                    AssetDatabase.SaveAssets();
                    AssetDatabase.Refresh();
                }
                m_variables.DeleteArrayElementAtIndex(list.index);

                if(m_variables.arraySize <= m_list.index)
                    m_list.index--;

                RefreshSelection();

            }
            Repaint();
        }

        private float ElementHeight(int index)
        {
            return EditorGUIUtility.singleLineHeight + 4;
        }

        private void OnSelectElement(ReorderableList list)
        {
            if(list.index == -1)
            {
                m_selection = null;
                return;
            }

            var element = m_variables.GetArrayElementAtIndex(list.index);
            var obj = element.objectReferenceValue;
            m_selection = obj;

            if(m_selection != null)
            {
                m_serializedSelection = new SerializedObject(m_selection);
                m_selectionEditor = CreateEditor(m_selection);
            }
        }

        void RefreshSelection()
        {
            OnSelectElement(m_list);
        }

        void DrawHeader(Rect rect)
        {
            GUI.Label(rect, $"Scriptable Variables ({m_variables.arraySize})");
        }
        private void DrawElement(Rect rect, int index, bool isActive, bool isFocused)
        {
            if (index >= m_variables.arraySize)
                return;

            var element = m_variables.GetArrayElementAtIndex(index);
            var obj = element.objectReferenceValue;
            SerializedObject so = new SerializedObject(obj);
            var isReadOnly = so.FindProperty("m_isReadOnly");
            rect.height = EditorGUIUtility.singleLineHeight;
            rect.y += 2;
            if(obj != null)
            {
                rect.width -= 22;
                rect.width /= 2f;
                //EditorGUI.PropertyField(rect, element, new GUIContent(obj.name));
                EditorGUI.LabelField(rect, $"{obj.name}{(isReadOnly.boolValue ? " (readonly)" : "")}");
                rect.x += rect.width;
                EditorGUI.LabelField(rect, $"| {obj.GetType().Name}");
                rect.x += rect.width+2;
                rect.width = 20;
                if(GUI.Button(rect, "-", EditorStyles.miniButton))
                {
                    m_list.index = index;
                    OnRemove(m_list);
                    
                }
            }
            else
            {
                EditorGUI.DrawRect(rect, (Color.yellow + Color.red) * 0.5f);
                EditorGUI.PropertyField(rect, element, new GUIContent(">> Assign Variable here:"));
            }
        }


        public override void OnInspectorGUI()
        {
            serializedObject.Update();

            using(var scope = new EditorGUI.ChangeCheckScope())
            {
                m_list.DoLayoutList();
                if (scope.changed)
                    RefreshSelection();
            }
            using (new GUILayout.VerticalScope(EditorStyles.helpBox))
            {
                GUILayout.Label("Add new Variable", EditorStyles.boldLabel);
                if(m_allTypeNames.Count > 0)
                {
                    if(EditorGUILayout.DropdownButton(new GUIContent(m_allTypeNames[m_allTypeIndex]), FocusType.Passive))
                    {
                        GenericMenu menu = new GenericMenu();

                        for(int i = 0; i < m_allTypeNames.Count; i++)
                        {
                            int index = i;

                            if(TryGetBaseType(m_allTypes[i], out var result))
                            {
                                if (IsListType(result))
                                {
                                    menu.AddItem(new GUIContent($"List/{m_allTypeNames[i].Replace("ListVariable", " List")}"), m_allTypeIndex == i, () => { m_allTypeIndex = index; });
                                }
                                else
                                {
                                    menu.AddItem(new GUIContent($"Single/{m_allTypeNames[i].Replace("Variable", "")}"), m_allTypeIndex == i, () => { m_allTypeIndex = index; });
                                }
                            }
                        }

                        menu.ShowAsContext();
                    }


                    //m_allTypeIndex = EditorGUILayout.Popup("Variable Type", m_allTypeIndex, m_allTypeNames.ToArray());
                    m_newVarName = EditorGUILayout.TextField("Variable Name", m_newVarName);
                    GUI.enabled = !string.IsNullOrEmpty(m_newVarName);
                    if(GUILayout.Button("Add"))
                    {

                        var instance = CreateInstance(m_allTypes[m_allTypeIndex]);
                        instance.name = m_newVarName;

                        AssetDatabase.AddObjectToAsset(instance, target);
                        AddNewItem(instance);
                        //m_variables.InsertArrayElementAtIndex(m_variables.arraySize);
                        //var e = m_variables.GetArrayElementAtIndex(m_variables.arraySize - 1);
                        //e.objectReferenceValue = instance;
                        m_newVarName = string.Empty;
                        AssetDatabase.SaveAssets();
                        AssetDatabase.Refresh();
                    }
                    GUI.enabled = true;
                }

                GUILayout.Space(10);
            }

            GUILayout.Space(25);


            if (m_selection)
            {
                using(new GUILayout.VerticalScope(EditorStyles.helpBox))
                {
                    EditorGUILayout.LabelField(m_selection.name + $" ({m_selection.GetType().Name})", EditorStyles.toolbarButton);
                    GUILayout.Space(5);
                    EditorGUI.indentLevel++;
                    m_serializedSelection.Update();
                    m_selectionEditor.OnInspectorGUI();
                    m_serializedSelection.ApplyModifiedProperties();
                }
            }
            serializedObject.ApplyModifiedProperties();
        }

        void AddNewItem(Object var)
        {
            m_variables.InsertArrayElementAtIndex(m_variables.arraySize);
            var e = m_variables.GetArrayElementAtIndex(m_variables.arraySize - 1);
            e.objectReferenceValue = var;
        }


        bool TryGetGenericType(Type type, out Type result)
        {
            result = null;

            if (type.BaseType.IsGenericType && type.BaseType.GetGenericTypeDefinition() == typeof(ScriptableVariable<>))
            {
                result = type.BaseType.GetGenericArguments()[0];
                return true;
            }
            return false;
        }
        bool TryGetBaseType(Type type, out Type result)
        {
            result = null;

            if (type.BaseType.IsGenericType)
            {
                result = type.BaseType;
                return true;
            }
            return false;
        }
        bool IsListType(Type type)
        {
            return type.GetGenericTypeDefinition() == typeof(ListVariable<>);
        }
    }
}
