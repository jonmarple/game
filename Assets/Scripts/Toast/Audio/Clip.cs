using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Toast.Audio
{
    /// <summary>
    /// Audio Clip/Key mapping.
    /// </summary>
    [System.Serializable]
    public struct Clip
    {
        /* Public Fields */
        public AudioKey Key;
        public AudioClip Audio;
        public float Volume;

        public Clip(AudioKey key, AudioClip audio, float volume)
        {
            Key = key;
            Audio = audio;
            Volume = volume;
        }
    }
}
