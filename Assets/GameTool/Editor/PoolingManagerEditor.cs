using System;
using System.Collections.Generic;
using System.IO;
using UnityEditor;
using UnityEngine;

namespace GameTool.Editor
{
    [CustomEditor(typeof(PoolingTable))]
    public class PoolingManagerEditor : UnityEditor.Editor
    {
        public override void OnInspectorGUI()
        {
            PoolingTable instance = (PoolingTable) target;
            base.OnInspectorGUI();
            if (GUILayout.Button("Update Enum"))
            {               
                string path = Application.dataPath + "/GameTool/Scripts/Pool/NamePrefabPool.cs";
                List<string> texts = new List<string>();
                texts.Add("namespace GameTool");
                texts.Add("{");
                texts.Add("    public enum NamePrefabPool");
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
#if UNITY_EDITOR
                AssetDatabase.SaveAssets();
#endif
            }

            if (GUILayout.Button("Update Prefab"))
            {
                instance.UpdatePrefab();
#if UNITY_EDITOR
                AssetDatabase.SaveAssets();
#endif
            }
        }
    }
}