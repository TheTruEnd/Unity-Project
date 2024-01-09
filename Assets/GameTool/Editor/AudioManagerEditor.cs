using System.Collections.Generic;
using System.IO;
using UnityEditor;
using UnityEngine;

namespace GameTool.Editor
{
    [CustomEditor(typeof(AudioTable))]
    public class AudioManagerEditor : UnityEditor.Editor
    {
        public override void OnInspectorGUI()
        {
            AudioTable instance = (AudioTable) target;
            base.OnInspectorGUI();
            if (GUILayout.Button("Update Script"))
            {
                string path = Application.dataPath + "/GameTool/Scripts/Audio/eAudioName.cs";
                List<string> texts = new List<string>();
                texts.Add("namespace GameTool");
                texts.Add("{");
                texts.Add("    public enum eMusicName");
                texts.Add("    {");
                texts.Add("        None,");
                foreach (var item in instance.musicTracksSerializers)
                {
                    if (item.key != "None")
                    {
                        texts.Add("        " + item.key + ",");
                    }
                }

                texts.Add("    }");
                texts.Add("    public enum eSoundName");
                texts.Add("    {");
                texts.Add("        None,");
                foreach (var item in instance.soundTracksSerializers)
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