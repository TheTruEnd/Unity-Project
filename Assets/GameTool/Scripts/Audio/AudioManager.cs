using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

// ReSharper disable once CheckNamespace
namespace GameTool
{
    public class AudioManager : SingletonMonoBehaviour<AudioManager>
    {
        [SerializeField] private AudioSource musicSpeaker;
        [SerializeField] private AudioSource soundSpeaker;

        [SerializeField] public AudioTable Serializers;

        private readonly Dictionary<eMusicName, TrackAudio> MusicTracks = new Dictionary<eMusicName, TrackAudio>();

        private readonly Dictionary<eSoundName, TrackAudio> SoundTracks = new Dictionary<eSoundName, TrackAudio>();

        protected override void Awake()
        {
            base.Awake();
            UpdateKey();
        }

        private void UpdateKey()
        {
            foreach (var serializer in Serializers.musicTracksSerializers)
            {
                MusicTracks.Add((eMusicName)Enum.Parse(typeof(eMusicName),serializer.key), serializer.track);
            }

            foreach (var serializer in Serializers.soundTracksSerializers)
            {
                SoundTracks.Add((eSoundName)Enum.Parse(typeof(eSoundName),serializer.key), serializer.track);
            }
        }

        public void PlayMusic(eMusicName filename)
        {
            musicSpeaker.clip = (MusicTracks[filename].listAudio.GetRandom());
            musicSpeaker.Play();
        }

        public void Shot(eSoundName filename, float volume = 1)
        {
            soundSpeaker.PlayOneShot(SoundTracks[filename].listAudio.GetRandom(), volume);
        }

        public void Fade(float volume, float duration = 1f)
        {
            musicSpeaker.DOKill();
            musicSpeaker.DOFade(volume, duration);
        }

        public void PauseMusic()
        {
            musicSpeaker.Pause();
        }

        public void StopMusic()
        {
            musicSpeaker.Stop();
        }

        public void ResumeMusic()
        {
            musicSpeaker.UnPause();
        }

        public void StopSFX()
        {
            soundSpeaker.Stop();
        }

        public AudioClip GetAudioClip(eMusicName s)
        {
            return MusicTracks[s].listAudio.GetRandom();
        }

        public AudioClip GetAudioClip(eSoundName s)
        {
            return SoundTracks[s].listAudio.GetRandom();
        }

        public void Mute(bool value)
        {
            GameData.Instance.MuteAll = value;
        }
    }

    [Serializable]
    public class TrackAudio
    {
        public List<AudioClip> listAudio;
    }

    [Serializable]
    public class SerializerMusic
    {
        public string key;
        public TrackAudio track;
    }

    [Serializable]
    public class SerializerSound
    {
        public string key;
        public TrackAudio track;
    }
}