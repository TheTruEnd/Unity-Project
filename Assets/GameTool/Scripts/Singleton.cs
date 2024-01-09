using UnityEngine;

namespace GameTool
{
    public abstract class SingletonMonoBehaviour<T> : MonoBehaviour where T : MonoBehaviour
    {
        public static T Instance
        {
            get
            {
                if (!instance)
                {
                    instance = FindObjectOfType<T>(true);
                }

                return instance;
            }
        }

        private static T instance;

        protected virtual void Awake()
        {
            if (instance && instance != this)
            {
                Destroy(gameObject);
            }
            else
            {
                instance = (T) (MonoBehaviour) this;
            }
        }

        public static bool Exists()
        {
            return instance;
        }
    }

    public class SingletonUI<T> : BaseUI where T : BaseUI
    {
        public static T Instance
        {
            get
            {
                if (!instance)
                {
                    instance = FindObjectOfType<T>(true);
                }

                return instance;
            }
        }

        private static T instance;

        protected virtual void Awake()
        {
            if (instance && instance != this)
            {
                Destroy(gameObject);
            }
            else
            {
                instance = (T) (BaseUI) this;
            }
        }

        public static bool Exists()
        {
            return instance;
        }
    }
}