using System;
using UnityEngine.Events;

// ReSharper disable once CheckNamespace
namespace GameTool
{
    public static class EventDispatcher
    {
        private static readonly UnityAction<object[]>[] Action = new UnityAction<object[]>[Enum.GetNames(typeof(eEventType)).Length];

        public static void PostEvent(this object obj, eEventType eEventType, params object[] args)
        {
            Action[(int) eEventType]?.Invoke(args);
        }

        public static void AddListener(this object obj, eEventType eEventType, UnityAction<object[]> action)
        {
            Action[(int) eEventType] += action;
        }

        public static void RemoveListener(this object obj, eEventType eEventType, UnityAction<object[]> action)
        {
            Action[(int) eEventType] -= action;
        }
    }

    public enum eEventType
    {
        None = 0,
        SceneLoaded,
    }
}