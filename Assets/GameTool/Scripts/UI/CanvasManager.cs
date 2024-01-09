using System;
using System.Collections.Generic;
using UnityEngine;

namespace GameTool
{
    public class CanvasManager : SingletonMonoBehaviour<CanvasManager>
    {
        private readonly Dictionary<eUIName, List<BaseUI>> ListUI = new Dictionary<eUIName, List<BaseUI>>();
        private readonly Dictionary<eUIName, Stack<BaseUI>> DictUIDisabled = new Dictionary<eUIName, Stack<BaseUI>>();
        private readonly Dictionary<eUIType, Transform> DictMenu = new Dictionary<eUIType, Transform>();

        protected override void Awake()
        {
            base.Awake();

            for (int i = 0; i < Enum.GetNames(typeof(eUIName)).Length; i++)
            {
                DictUIDisabled.Add((eUIName) i, new Stack<BaseUI>());
                ListUI.Add((eUIName) i, new List<BaseUI>());
            }

            for (int i = 0; i < Enum.GetNames(typeof(eUIType)).Length; i++)
            {
                GameObject obj = new GameObject(Enum.GetNames(typeof(eUIType))[i], typeof(RectTransform));
                obj.transform.SetParent(transform);
                obj.transform.position = transform.position;
                obj.transform.localScale = Vector3.one;
                SetFullRect(obj);
                DictMenu.Add((eUIType) i, obj.transform);
            }
        }

        public BaseUI Push(eUIName identifier, object[] args = null)
        {
            BaseUI uiReturn;
            if (DictUIDisabled[identifier].Count > 0)
            {
                uiReturn = DictUIDisabled[identifier].Pop();
                if (uiReturn)
                {
                    GotoTop(uiReturn);
                    uiReturn.gameObject.SetActive(true);
                    uiReturn.Init(args);
                    return uiReturn;
                }
            }

            uiReturn = Instantiate(CanvasPrefManager.Instance.DictUIPref[identifier], DictMenu[CanvasPrefManager.Instance.DictUISerialized[identifier.ToString()].uiType]);
            ListUI[identifier].Add(uiReturn);
            uiReturn.uiName = identifier;
            GotoTop(uiReturn);
            uiReturn.Init(args);
            return uiReturn;
        }

        public void Pop(BaseUI ui)
        {
            ui.gameObject.SetActive(false);
            DictUIDisabled[ui.uiName].Push(ui);
        }

        public void Pop(eUIName identifier)
        {
            var ui = ListUI[identifier].Find(_ui => _ui.uiName == identifier && _ui.gameObject.activeSelf);
            if (ui)
            {
                ui.Pop();
            }
        }

        public BaseUI FindEnabling(eUIName identifier)
        {
            return ListUI[identifier].Find(ui => ui.uiName == identifier && ui.gameObject.activeSelf);
        }

        public bool IsShowing(eUIName identifier)
        {
            BaseUI ui = FindEnabling(identifier);
            return ui != null;
        }

        public bool IsHavePopupShowing()
        {
            for(int i = 0; i < ListUI.Count; i++)
            {
                BaseUI popup = ListUI[(eUIName)i].Find(ui => ui.uiType == eUIType.Popup && ui.gameObject.activeSelf);

                if (popup)
                {
                    return true;
                }
            }

            return false;
        }

        private void GotoTop(BaseUI baseUi)
        {
            baseUi.transform.SetSiblingIndex(baseUi.transform.parent.childCount - 1);
        }

        private void SetFullRect(GameObject _obj)
        {
            RectTransform _rect = _obj.GetComponent<RectTransform>();

            _rect.anchorMin = Vector2.zero;
            _rect.anchorMax = Vector2.one;

            _rect.pivot = Vector2.one / 2;

            _rect.offsetMin = Vector2.zero;
            _rect.offsetMax = Vector2.zero;
        }
    }
}