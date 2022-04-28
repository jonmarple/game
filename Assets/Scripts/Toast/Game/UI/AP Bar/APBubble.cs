using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Toast.Game.UI
{
    /// <summary>
    /// Controller for an AP Bubble.
    /// </summary>
    public class APBubble : MonoBehaviour
    {
        /* Serialized Fields */
        [SerializeField] private Image fill;

        #region PUBLIC

        /// <summary> Set whether bubble fill is active. </summary>
        public void SetFill(bool active)
        { fill.enabled = active; }

        #endregion
    }
}
