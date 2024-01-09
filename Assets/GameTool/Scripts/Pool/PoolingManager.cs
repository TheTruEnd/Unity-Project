using System;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

// ReSharper disable once CheckNamespace
namespace GameTool
{
    public class PoolingManager : SingletonMonoBehaviour<PoolingManager>
    {
        public PoolingTable Serializers;

        private readonly Dictionary<string, ItemPooling> DictPoolSerialized = new Dictionary<string, ItemPooling>();

        private readonly Dictionary<NamePrefabPool, List<BasePooling>> dictPoolItem =
            new Dictionary<NamePrefabPool, List<BasePooling>>();

        private readonly Dictionary<NamePrefabPool, List<Queue<BasePooling>>> DisPoolers =
            new Dictionary<NamePrefabPool, List<Queue<BasePooling>>>();

        private readonly Dictionary<NamePrefabPool, List<BasePooling>> ListObj =
            new Dictionary<NamePrefabPool, List<BasePooling>>();

        private readonly Dictionary<NamePrefabPool, GameObject> parentPoolers = new Dictionary<NamePrefabPool, GameObject>();

        protected override void Awake()
        {
            base.Awake();
            UpdateKey();
            foreach (var itemPooling in DictPoolSerialized)
            {
                dictPoolItem.Add((NamePrefabPool)Enum.Parse(typeof(NamePrefabPool), itemPooling.Key),
                    itemPooling.Value.listPooling);
            }

            Setup();
        }

        public void DisableAllObject()
        {
            foreach (var item in ListObj)
            {
                foreach (var VARIABLE in item.Value)
                {
                    if (VARIABLE)
                    {
                        VARIABLE.Disable();
                    }
                }
            }
        }

        private void Setup()
        {
            foreach (var item in dictPoolItem)
            {
                var kvp = new List<Queue<BasePooling>>();
                for (int i = 0; i < dictPoolItem[item.Key].Count; i++)
                {
                    kvp.Add(new Queue<BasePooling>());
                }

                DisPoolers.Add(item.Key, kvp);
                ListObj.Add(item.Key, new List<BasePooling>());
                var par = new GameObject(item.Key + "Parent");
                par.transform.position = Vector3.zero;
                par.transform.parent = transform;
                parentPoolers.Add(item.Key, par);
            }
        }

        public BasePooling GetObject(NamePrefabPool objectName, Transform parent = null, Vector3 position = new Vector3(), Vector3 scale = new Vector3(), Quaternion rotation = new Quaternion())
        {
            BasePooling item = null;
            if (dictPoolItem[objectName].Count == 0)
            {
                Debug.LogError("Prefab of <color=yellow>" + objectName + "</color> is empty");
                return null;
            }
            int idx = Random.Range(0, dictPoolItem[objectName].Count);
            while (!item)
            {
                if (DisPoolers[objectName][idx].Count == 0)
                {
                    item = Instantiate(dictPoolItem[objectName][idx], parentPoolers[objectName].transform);
                    ListObj[objectName].Add(item);
                    item.poolName = objectName;
                    item.poolNameString = objectName.ToString();
                    item.index = idx;
                }
                else
                {
                    item = DisPoolers[objectName][idx].Dequeue();
                }
            }

            if (!ListObj[item.poolName].Contains(item))
            {
                ListObj[item.poolName].Add(item);
            }

            var itemTransform = item.transform;
            if (parent)
            {
                itemTransform.SetParent(parent);
            }
            itemTransform.position = position;

            if(scale == Vector3.zero)
            {
                item.transform.localScale = Vector3.one;
            }
            else
            {
                item.transform.localScale = scale;
            }

            if (rotation.eulerAngles == Vector3.zero)
            {
                itemTransform.rotation = dictPoolItem[objectName][idx].transform.rotation;
            }
            else
            {
                itemTransform.rotation = rotation;
            }

            item.gameObject.SetActive(true);
            item.Init();
            return item;
        }

        public void PushToPooler(BasePooling item)
        {
            item.CheckEnum();
            DisPoolers[item.poolName][item.index].Enqueue(item);
        }

        public void UpdateKey()
        {
            DictPoolSerialized.Clear();
            foreach (var serializer in Serializers.Serializers)
            {
                DictPoolSerialized.Add(serializer.key, serializer.ItemPooling);
            }
        }

        [Serializable]
        public class ItemPooling
        {
            public List<BasePooling> listPooling;
        }

        [Serializable]
        public class PoolSerializer
        {
            public string key;
            public ItemPooling ItemPooling;
        }
    }
}