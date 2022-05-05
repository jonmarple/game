using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

namespace Toast.Game.Prototype
{
    /// <summary>
    /// Sets prototype level text.
    /// </summary>
    public class PrototypeLevel : MonoBehaviour
    {
        /* Serialized Fields */
        [SerializeField] private TextMeshProUGUI text;
        [SerializeField] private PrototypeOption options;
        [SerializeField] private int initialLevel = 1;

        private void Start()
        { options.SetLevel(initialLevel); }

        private void OnEnable()
        { options.LevelUpdated += Refresh; }

        private void OnDisable()
        { options.LevelUpdated -= Refresh; }

        #region PUBLIC

        public void Refresh()
        { text?.SetText(options.Level.ToString()); }

        #endregion
    }
}
