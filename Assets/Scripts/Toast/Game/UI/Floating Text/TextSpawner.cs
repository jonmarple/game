using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

namespace Toast.Game.UI
{
    /// <summary>
    /// Spawn floating text.
    /// </summary>
    public class TextSpawner : MonoBehaviour
    {
        /* Static Fields */
        public static TextSpawner Instance;

        /* Serialized Fields */
        [SerializeField] private FloatingText prefab;

        private void Awake()
        { Instance = this; }

        #region PUBLIC

        /// <summary> Spawn floating text. </summary>
        public void Spawn(string text, Vector3 pos)
        { Instantiate(prefab, pos, Quaternion.identity, transform).Float(text); }

        #endregion
    }
}
