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

        /// <summary> Play audio clip. </summary>
        public void Play(AudioClip clip)
        {
            source.PlayOneShot(clip);
            if (debug) Debug.Log(clip);
        }

        #endregion
    }
}
