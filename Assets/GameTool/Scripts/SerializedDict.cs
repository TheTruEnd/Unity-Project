using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

[Serializable]
public class SerializedDict<TKey, TValue> : IDictionary<TKey, TValue>, ISerializationCallbackReceiver
{
    [Serializable]
    public struct _SerialKVPair<TKeyx, TValuex>
    {
        public TKeyx key;
        public TValuex value;

        public _SerialKVPair<TKeyx, TValuex> Reset()
        {
            key = default;
            return this;
        }
    }

    [SerializeField] public List<_SerialKVPair<TKey, TValue>> list = new List<_SerialKVPair<TKey, TValue>>();
    private Dictionary<TKey, TValue> dict = new Dictionary<TKey, TValue>();

    #region DICTIONARY METHODS

    public IEnumerator<KeyValuePair<TKey, TValue>> GetEnumerator()
    {
        return dict.GetEnumerator();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }

    public void Add(KeyValuePair<TKey, TValue> item)
    {
        if (dict.ContainsKey(item.Key))
        {
            Debug.LogError("The dictionary already contains the key " + item.Key);
        }
        else
        {
            dict.Add(item.Key, item.Value);
        }
    }

    public void Add(TKey key, TValue value)
    {
        if (dict.ContainsKey(key))
        {
            Debug.LogError("The dictionary already contains the key " + key);
        }
        else
        {
            dict.Add(key, value);
        }
    }

    public void Clear()
    {
        dict.Clear();
    }

    public bool Contains(TValue item)
    {
        return dict.ContainsValue(item);
    }

    public bool Contains(KeyValuePair<TKey, TValue> item)
    {
        return dict.Contains(item);
    }

    public void CopyTo(KeyValuePair<TKey, TValue>[] array, int arrayIndex)
    {
        ((IDictionary<TKey, TValue>) dict).CopyTo(array, arrayIndex);
    }

    public bool Remove(KeyValuePair<TKey, TValue> item)
    {
        return dict.Remove(item.Key);
    }

    public int Count => dict.Count;
    public bool IsReadOnly => false;

    public bool ContainsKey(TKey key)
    {
        return dict.ContainsKey(key);
    }

    public bool Remove(TKey key)
    {
        return dict.Remove(key);
    }

    public bool TryGetValue(TKey key, out TValue value)
    {
        return dict.TryGetValue(key, out value);
    }

    public TValue this[TKey key]
    {
        get => dict[key];
        set => dict[key] = value;
    }

    public ICollection<TKey> Keys => dict.Keys;
    public ICollection<TValue> Values => dict.Values;

    #endregion DICTIONARY METHODS

    public void OnBeforeSerialize()
    {
        if (Application.isPlaying)
        {
#if !UNITY_EDITOR
            list.Clear();
            foreach (var value in dict)
            {
                list.Add(new _SerialKVPair<TKey, TValue>() {key = value.Key, value = value.Value});
            }
#endif
        }

        int index = 0;
        foreach (var value in dict)
        {
            if (index >= list.Count)
            {
                list.Add(new _SerialKVPair<TKey, TValue>() {key = value.Key, value = value.Value});
            }
            else
            {
                list[index] = new _SerialKVPair<TKey, TValue>() {key = value.Key, value = value.Value};
                index++;
            }
        }
    }

    // Đưa list vào dict
    public void OnAfterDeserialize()
    {
        // Xoá dict trước
        dict.Clear();

        for (int i = 0; i < list.Count; i++)
        {
            if (!dict.ContainsKey(list[i].key))
            {
                dict.Add(list[i].key, list[i].value);
            }
            else
            {
                Debug.LogError("The element <color=yellow><b>INDEX OF: " + i + "</b></color> with the <color=yellow><b>KEY: " + list[i].key +
                               "</b></color> is already in the list!");
            }

            for (int j = 2; j < list.FindAll(pair => pair.key.Equals(list[i].key)).Count; j++)
            {
                list.RemoveAt(list.FindLastIndex(pair => pair.key.Equals(list[i].key)));
            }
        }
    }
}