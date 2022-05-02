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
        [Header("Target")]
        [SerializeField] private float delay = 0f;
        [SerializeField] private GameObject target;

        [Header("Components")]
        [SerializeField] private TextMeshProUGUI text;
        [SerializeField] private Animator animator;

        private void Start()
        { target.AddComponent<InfoPanelTarget>().Initialize(this, delay); }

        #region PUBLIC

        /// <summary> Set info panel text. </summary>
        public void SetText(string text)
        { this.text.text = text; }

        /// <summary> Enable/Disable panel. </summary>
        public void SetActive(bool active)
        { animator.SetBool("Active", active); }

        #endregion
    }
}
