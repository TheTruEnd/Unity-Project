using UnityEngine;

namespace GameTool
{
    public class BaseUI : MonoBehaviour
    {
        [HideInInspector] public eUIType uiType;
        [HideInInspector] public eUIName uiName;

        public virtual void Init(params object[] args)
        {
        }

        public virtual void Pop()
        {
            CanvasManager.Instance.Pop(this);
        }
    }
}