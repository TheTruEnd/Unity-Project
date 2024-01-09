using System.Collections.Generic;
using UnityEngine;

namespace GameTool
{
    [CreateAssetMenu(fileName = "CanvasPrefTable", menuName = "ScriptableObject/CanvasPrefTable", order = 0)]
    public class CanvasPrefTable : ScriptableObject
    {
        public List<CanvasPrefManager.UISerializer> Serializers = new List<CanvasPrefManager.UISerializer>();
    }
}