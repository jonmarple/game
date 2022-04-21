using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Toast.Audio
{
    /// <summary>
    /// Audio clip data container.
    /// </summary>
    [CreateAssetMenu(fileName = "AudioClip Container", menuName = "Toast/Audio/AudioClip Container")]
    public class AudioClipContainer : ScriptableObject
    {
        /* Serialized Fields */
        [SerializeField] private List<Clip> clips;

        /* Private Fields */
        private Dictionary<AudioKey, Clip> mappings;

        #region PUBLIC

        /// <summary> Initialize AudioKey/Clip mappings. </summary>
        public void Initialize()
        {
            mappings = new Dictionary<AudioKey, Clip>();
            foreach (Clip clip in clips)
                mappings[clip.Key] = clip;
        }

        /// <summary> Fetch Clip mapped to Key. </summary>
        public Clip Get(AudioKey key)
        {
            if (mappings.ContainsKey(key)) return mappings[key];
            return new Clip(AudioKey.NONE, null, 0f);
        }

        /// <summary> Play audio clip. </summary>
        public void Play(int index)
        { AudioManager.Play(clips[index]); }

        #endregion
    }
}
