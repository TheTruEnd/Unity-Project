using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Random = UnityEngine.Random;

namespace GameTool
{
    public static class CollectionUltility
    {
        public static T GetRandom<T>(this IList<T> collection)
        {
            return collection[Random.Range(0, collection.Count)];
        }
        
        public static T GetRandom<T>(this IEnumerable<T> collection)
        {
            return collection.ElementAt(Random.Range(0, collection.Count()));
        }
    }
}