using System;
using System.Collections;
using UnityEngine;

namespace GameTool
{
    public class BasePooling : MonoBehaviour
    {
        [NonSerialized] public NamePrefabPool poolName = NamePrefabPool.None;
        public string poolNameString;
        public int index;

        public virtual void Init(params object[] args)
        {
        }

        public virtual void Disable()
        {
            if (this)
            {
                gameObject.SetActive(false);
            }
        }

        public virtual void Disable(float time)
        {
            StartCoroutine(nameof(WaitDisable), time);
        }

        private IEnumerator WaitDisable(float time)
        {
            yield return new WaitForSeconds(time);
            Disable();
        }

        protected virtual void OnDisable()
        {
            if (PoolingManager.Exists() && this)
            {
                PoolingManager.Instance.PushToPooler(this);
            }
        }

        public void CheckEnum()
        {
            if (poolName.ToString() != poolNameString)
            {
                poolName = (NamePrefabPool)Enum.Parse(typeof(NamePrefabPool), poolNameString);
            }
        }
    }
}