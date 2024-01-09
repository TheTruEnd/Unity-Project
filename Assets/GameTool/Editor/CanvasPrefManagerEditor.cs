using System.Collections.Generic;
using System.IO;
using UnityEditor;
using UnityEngine;

namespace GameTool.Editor
{
    [CustomEditor(typeof(CanvasPrefTable))]
    public class CanvasPrefManagerEditor : UnityEditor.Editor
    {
        public override void OnInspectorGUI()
        {
            CanvasPrefTable instance = (CanvasPrefTable) target;
            base.OnInspectorGUI();
            if (GUILayout.Button("Update Script"))
            {
                string path = Application.dataPath + "/GameTool/Scripts/UI/eUIName.cs";
                List<string> texts = new List<string>();
                texts.Add("namespace GameTool");
                texts.Add("{");
                texts.Add("    public enum eUIName");
                texts.Add("    {");
                texts.Add("        None,");
                foreach (var item in instance.Serializers)
                {
                    if (item.key != "None")
                    {
                        texts.Add("        " + item.key + ",");
                    }
                }

                texts.Add("    }");
                texts.Add("}");
                File.WriteAllLines(path, texts.ToArray());
            }
        }
    }
}