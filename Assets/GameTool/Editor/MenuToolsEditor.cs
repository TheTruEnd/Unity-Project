using UnityEditor;

namespace GameTool.Editor
{
    public class MenuToolsEditor
    {
        [MenuItem("MenuTools/Data/ClearData")]
        public static void ClearData()
        {
            GameData.Instance.ClearAllData();
            PrefabUtility.ApplyObjectOverride(GameData.Instance, "Assets/GameTool/Prefabs/GameData.prefab", InteractionMode.AutomatedAction);
        }
        
        [MenuItem("MenuTools/Data/SaveData")]
        public static void SaveData()
        {
            GameData.Instance.SaveAllData();
            PrefabUtility.ApplyObjectOverride(GameData.Instance, "Assets/GameTool/Prefabs/GameData.prefab", InteractionMode.AutomatedAction);
        }
        
        [MenuItem("MenuTools/Data/LoadData")]
        public static void LoadData()
        {
            GameData.Instance.LoadAllData();
            PrefabUtility.ApplyObjectOverride(GameData.Instance, "Assets/GameTool/Prefabs/GameData.prefab", InteractionMode.AutomatedAction);
        }
        
        [MenuItem("MenuTools/Tables/Pooling")]
        public static void Pooling()
        {
            Selection.activeObject =
                AssetDatabase.LoadAssetAtPath<PoolingTable>("Assets/GameTool/Resource/PoolingTable.asset");
        }
        
        [MenuItem("MenuTools/Tables/Audio")]
        public static void Audio()
        {
            Selection.activeObject =
                AssetDatabase.LoadAssetAtPath<AudioTable>("Assets/GameTool/Resource/AudioTable.asset");
        }
        
        [MenuItem("MenuTools/Tables/GameData")]
        public static void OpenGameData()
        {
            Selection.activeObject =
                AssetDatabase.LoadAssetAtPath<GameData>("Assets/GameTool/Prefabs/GameData.prefab");
        }
        
        [MenuItem("MenuTools/Tables/UI")]
        public static void UI()
        {
            Selection.activeObject =
                AssetDatabase.LoadAssetAtPath<CanvasPrefTable>("Assets/GameTool/Resource/CanvasPrefTable.asset");
        }
    }
}