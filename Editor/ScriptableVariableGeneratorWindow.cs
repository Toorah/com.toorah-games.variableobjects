using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEditor;
using UnityEngine;

namespace Toorah.ScribtableVariables.Editor
{
    public class ScriptableVariableGeneratorWindow : EditorWindow
    {
        [MenuItem("Window/Scriptable Variables/Generator Window")]
        static void Open()
        {
            var win = GetWindow<ScriptableVariableGeneratorWindow>();
            win.titleContent.text = "Variables Generator";
            win.Show();
        }


        public TextAsset variableTemplate;
        public string variableTemplateText;
        public TextAsset listTemplate;
        public string listTemplateText;

        public string m_name;
        public string m_type;
        public string m_directory;
        public bool automatic;

        private void OnEnable()
        {
            variableTemplate = Resources.Load<TextAsset>("variabletemplate");
            listTemplate = Resources.Load<TextAsset>("listTemplate");

            variableTemplateText = variableTemplate.text;
            listTemplateText = listTemplate.text;
        }

        private void OnGUI()
        {
            var donotexpand = GUILayout.ExpandWidth(false);

            using(var scope = new EditorGUI.ChangeCheckScope())
            {
                m_name = EditorGUILayout.TextField("Name", m_name);
                using(new GUILayout.HorizontalScope())
                {
                    using(new EditorGUI.DisabledGroupScope(automatic))
                    {
                        m_type = EditorGUILayout.TextField("Type", m_type);
                    }
                    automatic = GUILayout.Toggle(automatic, GUIContent.none, donotexpand);
                }
                if (scope.changed && automatic)
                {
                    m_type = m_name.ToLower();
                }
            }
            using (new GUILayout.HorizontalScope())
            {
                m_directory = EditorGUILayout.TextField("Path", m_directory);
                if(GUILayout.Button("Browse", donotexpand))
                {
                    var path = EditorUtility.OpenFolderPanel("Select Directory", "Assets", "");
                    if (path != "")
                        m_directory = path;
                }
            }

            var variableText = variableTemplateText.Replace("*NAME*", m_name).Replace("*TYPE*", m_type);
            var listText = listTemplateText.Replace("*NAME*", m_name).Replace("*TYPE*", m_type);

            if (GUILayout.Button("Generate"))
            {
                File.WriteAllText(Path.Combine(m_directory, m_name + "Variable.cs"), variableText);
                File.WriteAllText(Path.Combine(m_directory, m_name + "ListVariable.cs"), listText);
                AssetDatabase.SaveAssets();
                AssetDatabase.Refresh();
            }

            GUILayout.Label("Preview", EditorStyles.miniLabel);
            GUILayout.Label(variableText, EditorStyles.helpBox);
            GUILayout.Label(listText, EditorStyles.helpBox);
        }
    }

}