using System.Collections.Generic;
using UnityEngine;

namespace GameTool
{
    [CreateAssetMenu(fileName = "AudioTable", menuName = "ScriptableObject/AudioTable", order = 0)]
    public class AudioTable : ScriptableObject
    {
        [SerializeField] public List<SerializerMusic> musicTracksSerializers = new List<SerializerMusic>();
        [SerializeField] public List<SerializerSound> soundTracksSerializers = new List<SerializerSound>();
    }
}