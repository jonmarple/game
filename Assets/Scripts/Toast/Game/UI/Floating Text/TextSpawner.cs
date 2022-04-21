using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
        [SerializeField] private Color def;
        [SerializeField] private Color damage;
        [SerializeField] private Color healing;
        [SerializeField] private Color crit;

        private void Awake()
        { Instance = this; }

        #region PUBLIC

        /// <summary> Spawn floating text. </summary>
        public void Spawn(string text, Vector3 pos, FloatingTextType type)
        {
            Color c;
            switch (type)
            {
                case FloatingTextType.DAMAGE:
                    c = damage;
                    break;
                case FloatingTextType.HEALING:
                    c = healing;
                    break;
                case FloatingTextType.CRIT:
                    c = crit;
                    break;
                default:
                    c = def;
                    break;
            }
            Instantiate(prefab, pos, Quaternion.identity, transform).Float(text, c);
        }

        #endregion
    }
}
