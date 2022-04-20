using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Toast.Audio
{
    /// <summary>
    /// Main audio interface.
    /// </summary>
    public static class AudioManager
    {
        /* Private Fields */
        private static AudioPlayer player;

        #region PUBLIC

        /// <summary> Play audio mapped to key. </summary>
        public static void Play(AudioKey key)
        { player?.Play(key); }

        /// <summary> Play audio clip. </summary>
        public static void Play(AudioClip clip)
        { player?.Play(clip); }

        /// <summary> Register Audio Player. </summary>
        public static void Register(AudioPlayer player)
        { AudioManager.player = player; }

        #endregion
    }
}
