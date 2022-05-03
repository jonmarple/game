using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Toast.Audio
{
    /// <summary>
    /// Play audio clips.
    /// </summary>
    [RequireComponent(typeof(AudioSource))]
    public class AudioPlayer : MonoBehaviour
    {
        /* Serialized Fields */
        [SerializeField] private AudioClipContainer data;
        [SerializeField] private bool debug;

        /* Private Fields */
        private AudioSource source;

        private void Awake()
        { source = GetComponent<AudioSource>(); }

        private void Start()
        {
            data.Initialize();
            AudioManager.Register(this);
        }

        #region PUBLIC

        /// <summary> Play audio mapped to key. </summary>
        public void Play(AudioKey key)
        { Play(data.Get(key)); }

        /// <summary> Play clip. </summary>
        public void Play(Clip clip)
        { Play(clip.Audio, clip.Volume); }

        /// <summary> Play audio. </summary>
        public void Play(AudioClip clip, float volume)
        {
            source?.PlayOneShot(clip, volume);
            if (debug) Debug.Log(clip);
        }

        #endregion
    }
}
