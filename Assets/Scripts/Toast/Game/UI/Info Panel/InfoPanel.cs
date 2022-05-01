using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

namespace Toast.Game.UI
{
    /// <summary>
    /// Controller for an Info Panel.
    /// </summary>
    public class InfoPanel : MonoBehaviour
    {
        /* Serialized Fields */
        [SerializeField] private RectTransform container;
        [SerializeField] private TextMeshProUGUI text;

        private void Start()
        { SetActive(false); }

        #region PUBLIC

        /// <summary> Set info panel text. </summary>
        public void SetText(string text)
        { this.text.text = text; }

        /// <summary> Enable/Disable panel. </summary>
        public void SetActive(bool active)
        { container.gameObject.SetActive(active); }

        #endregion
    }
}
