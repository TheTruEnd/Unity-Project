using System;
using System.Collections.Generic;

namespace GameTool
{
    public enum eUIType
    {
        Menu,
        Popup,
        AlwaysOnTop,
    }
    
    public class CanvasPrefManager : SingletonMonoBehaviour<CanvasPrefManager>
    {
        public CanvasPrefTable Serializers;

        public readonly Dictionary<string, SettingUI> DictUISerialized =
            new Dictionary<string, SettingUI>();

        public readonly Dictionary<eUIName, BaseUI> DictUIPref = new Dictionary<eUIName, BaseUI>();

        protected override void Awake()
        {
            base.Awake();
            UpdateKey();
            foreach (var itemPooling in DictUISerialized)
            {
                DictUIPref.Add((eUIName) Enum.Parse(typeof(eUIName), itemPooling.Key), itemPooling.Value.baseUI);
            }
        }
        
        public void UpdateKey()
        {
            DictUISerialized.Clear();
            foreach (var serializer in Serializers.Serializers)
            {
                DictUISerialized.Add(serializer.key, serializer.settingUI);
            }
        }

        [Serializable]
        public class SettingUI
        {
            public eUIType uiType;
            public BaseUI baseUI;
        }

        [Serializable]
        public class UISerializer
        {
            public string key;
            public SettingUI settingUI;
        }
    }
}