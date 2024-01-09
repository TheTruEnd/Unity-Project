using System;
using System.Collections.Generic;
using UnityEngine;
#if UNITY_EDITOR
using UnityEditor;
#endif

namespace GameTool
{
    [CreateAssetMenu(fileName = "PoolingTable", menuName = "ScriptableObject/PoolingTable", order = 0)]
    public class PoolingTable : ScriptableObject
    {
        public List<PoolingManager.PoolSerializer> Serializers = new List<PoolingManager.PoolSerializer>();

        public void UpdatePrefab()
        {
            foreach (var item in Serializers)
            {
                if (item.key != "None")
                {
                    for (int i = 0; i < item.ItemPooling.listPooling.Count; i++)
                    {
                        BasePooling obj = item.ItemPooling.listPooling[i];
                        if (obj)
                        {
                            NamePrefabPool name = NamePrefabPool.None;
                            if (Enum.TryParse<NamePrefabPool>(item.key, out name))
                            {
                                obj.poolName = name;
                                obj.poolNameString = name.ToString();
                            }
                            obj.index = i;

#if UNITY_EDITOR
                            if (PrefabUtility.IsPartOfRegularPrefab(obj))
                            {
                                EditorUtility.SetDirty(obj);
                                PrefabUtility.RecordPrefabInstancePropertyModifications(obj.gameObject);
                            }
#endif
                        }
                    }
                }
            }
        }
    }
}