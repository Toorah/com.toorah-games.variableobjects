using System.Collections.Generic;
using System.IO;
using System.Linq;
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

        public bool saveVariable = true;
        public TextAsset variableTemplate;
        public string variableTemplateText;

        public TextAsset variableTemplate1;
        public string variableTemplateText1;

        public bool saveList = true;
        public TextAsset listTemplate;
        public string listTemplateText;

        public TextAsset listTemplate1;
        public string listTemplateText1;

        public TextAsset generateTypes;
        public string generateTypesText;

        public string m_name;
        public string m_type;
        public string m_directory;
        public bool automatic;

        public string m_lastPath;

        [System.Serializable]
        public class Gen
        {
            public List<GenType> types = new List<GenType>();

            public int Count => types.Count;

        }
        public Gen generator;

        [System.Serializable]
        public class GenType
        {
            public string name;
            public string type;

            public GenType(string name, string type)
            {
                this.name = name;
                this.type = type;
            }
        }

        private void OnEnable()
        {
            variableTemplate = Resources.Load<TextAsset>("variabletemplate");
            listTemplate = Resources.Load<TextAsset>("listTemplate");

            variableTemplate1 = Resources.Load<TextAsset>("variabletemplate 1");
            listTemplate1 = Resources.Load<TextAsset>("listTemplate 1");


            generateTypes = Resources.Load<TextAsset>("generateTypes");


            variableTemplateText = variableTemplate.text;
            listTemplateText = listTemplate.text;

            variableTemplateText1 = variableTemplate1.text;
            listTemplateText1 = listTemplate1.text;

            generateTypesText = generateTypes.text;

            if (generator == null)
            {
                LoadDefault();
            }
        }

        void LoadDefault()
        {
            generator = new Gen();
            m_lastPath = string.Empty;
            MarkChange();
            EditorJsonUtility.FromJsonOverwrite(generateTypesText, generator);
        }
        void Load(string path)
        {
            UnMarkChange();
            var text = File.ReadAllText(path);
            m_lastPath = path;
            generator = new Gen();
            EditorJsonUtility.FromJsonOverwrite(text, generator);
        }
        void Save(bool force = false)
        {
            UnMarkChange();
            var g = EditorJsonUtility.ToJson(generator, true);
            string path = string.Empty;
            if (force || string.IsNullOrEmpty(m_lastPath))
                path = EditorUtility.SaveFilePanel("Save JSON", Application.dataPath, "generatorTypes", "json");
            else
                path = m_lastPath;
            if(!string.IsNullOrEmpty(path))
            {
                m_lastPath = path;
                File.WriteAllText(path, g);
                AssetDatabase.SaveAssets();
                AssetDatabase.Refresh();
            }
        }
        void Order()
        {
            generator.types = generator.types.OrderBy(t => !string.IsNullOrEmpty(t.type) ? -100 : 100).ThenBy(t => t.name).ToList();
            MarkChange();
            Repaint();
        }
        void MarkChange()
        {
            if (!titleContent.text.EndsWith("*"))
                titleContent.text += "*";
        }
        void UnMarkChange()
        {
            if (titleContent.text.EndsWith("*"))
                titleContent.text = titleContent.text.Remove(titleContent.text.Length-1);
        }
        Vector2 m_scroll;

        private void OnGUI()
        {
            var donotexpand = GUILayout.ExpandWidth(false);
            var expand = GUILayout.ExpandWidth(true);

            using (new GUILayout.HorizontalScope(EditorStyles.toolbar, expand))
            {
                if(GUILayout.Button("File", EditorStyles.toolbarPopup, donotexpand))
                {
                    GenericMenu menu = new GenericMenu();
                    menu.AddItem(new GUIContent("Default"), false, () => { LoadDefault(); });
                    menu.AddSeparator("");
                    menu.AddItem(new GUIContent("New"), false, () =>
                    {
                        generator = new Gen();
                    });
                    menu.AddItem(new GUIContent("Load"), false, () =>
                    {
                        var path = EditorUtility.OpenFilePanelWithFilters("Open JSON", "", new string[] { "Text Files", "txt,json" });
                        if (!string.IsNullOrEmpty(path))
                            Load(path);
                    });
                    menu.AddItem(new GUIContent("Save"), false, () => { Save(); });
                    menu.AddItem(new GUIContent("Save As..."), false, () => { Save(true); });
                    menu.AddSeparator("");
                    menu.AddItem(new GUIContent("Order"), false, () => { Order(); });
                    menu.ShowAsContext();
                }
            }
            using (new GUILayout.HorizontalScope())
            {
                using (new GUILayout.VerticalScope(EditorStyles.helpBox, GUILayout.Width(200), donotexpand))
                {
                    using (new GUILayout.HorizontalScope())
                    {
                        EditorGUILayout.LabelField("", EditorStyles.toolbarButton, GUILayout.Width(20));
                        EditorGUILayout.LabelField("Name", EditorStyles.toolbarButton);
                        EditorGUILayout.LabelField("Type", EditorStyles.toolbarButton);
                        EditorGUILayout.LabelField("", EditorStyles.toolbarButton, GUILayout.Width(20));
                    }
                    using (var scope = new GUILayout.ScrollViewScope(m_scroll, EditorStyles.helpBox))
                    {
                        m_scroll = scope.scrollPosition;


                        using (var changeScope = new EditorGUI.ChangeCheckScope())
                        {
                            for (int i = 0; i < generator.Count; i++)
                            {
                                var cur = generator.types[i];

                                using (new GUILayout.HorizontalScope())
                                {
                                    if (GUILayout.Button(new GUIContent(">", "Preview"), GUILayout.Width(20)))
                                    {
                                        m_name = cur.name;
                                        m_type = string.IsNullOrEmpty(cur.type) ? m_name : cur.type; 
                                    }

                                    cur.name = EditorGUILayout.DelayedTextField(cur.name);

                                    cur.type = EditorGUILayout.DelayedTextField(cur.type);
                                    if (GUILayout.Button("-", GUILayout.Width(20)))
                                    {
                                        if (!titleContent.text.EndsWith("*"))
                                            titleContent.text += "*";
                                        generator.types.RemoveAt(i);
                                        break;
                                    }
                                }
                            }

                            if (changeScope.changed)
                            {
                                MarkChange();
                            }
                        }
                    }
                    using (new GUILayout.HorizontalScope())
                    {
                        if (GUILayout.Button("Add"))
                        {
                            generator.types.Add(new GenType("", ""));
                            if (!titleContent.text.EndsWith("*"))
                                titleContent.text += "*";
                        }
                    }

                    
                }

                using (new GUILayout.VerticalScope())
                {
                    using (new GUILayout.HorizontalScope())
                    {
                        m_directory = EditorGUILayout.TextField("Path", m_directory);
                        if (GUILayout.Button("Browse", donotexpand))
                        {
                            var path = EditorUtility.OpenFolderPanel("Select Directory", "Assets", "");
                            if (path != "")
                                m_directory = path;
                        }
                    }

                    var variableText = variableTemplateText.Replace("*NAME*", m_name).Replace("*TYPE*", m_type);
                    var listText = listTemplateText.Replace("*NAME*", m_name).Replace("*TYPE*", m_type);


                    var variableText1 = variableTemplateText1.Replace("*NAME*", m_name).Replace("*TYPE*", m_type);
                    var listText1 = listTemplateText1.Replace("*NAME*", m_name).Replace("*TYPE*", m_type);


                    if (GUILayout.Button("Generate"))
                    {
                        EditorUtility.DisplayProgressBar("Generate Variables", "Start", 0);
                        for (int i = 0; i < generator.Count; i++)
                        {
                            var cur = generator.types[i];
                            var name = cur.name;
                            var type = string.IsNullOrEmpty(cur.type) ? name : cur.type;

                            variableText = variableTemplateText.Replace("*NAME*", name).Replace("*TYPE*", type);
                            listText = listTemplateText.Replace("*NAME*", name).Replace("*TYPE*", type);

                            if (saveVariable)
                                File.WriteAllText(Path.Combine(m_directory, name + "Variable.cs"), variableText);
                            if (saveList)
                                File.WriteAllText(Path.Combine(m_directory, name + "ListVariable.cs"), listText);

                            EditorUtility.DisplayProgressBar("Generate Variables", $"Generate: {name}", i / (float)(generator.Count - 1));
                        }
                        EditorUtility.ClearProgressBar();

                        AssetDatabase.SaveAssets();
                        AssetDatabase.Refresh();
                    }
                    m_type = string.IsNullOrEmpty(m_type) ? m_name : m_type;

                    variableText1 = variableTemplateText1.Replace("*NAME*", m_name).Replace("*TYPE*", m_type);
                    listText1 = listTemplateText1.Replace("*NAME*", m_name).Replace("*TYPE*", m_type);

                    GUIStyle label = new GUIStyle(EditorStyles.helpBox);
                    label.richText = true;

                    GUILayout.Label("Preview", EditorStyles.miniLabel);
                    saveVariable = EditorGUILayout.Toggle("Save Variable", saveVariable);
                    if (saveVariable)
                        GUILayout.Label(variableText1, label);
                    saveList = EditorGUILayout.Toggle("Save List", saveList);
                    if (saveList)
                        GUILayout.Label(listText1, label);

                }
            }
        }
    }
}