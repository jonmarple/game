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

        public Clip(AudioKey key, AudioClip audio)
        {
            Key = key;
            Audio = audio;
        }
    }
}
