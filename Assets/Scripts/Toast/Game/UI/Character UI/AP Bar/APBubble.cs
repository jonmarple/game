using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Toast.Game.UI
{
    public enum APBubbleState
    {
        ACTIVE,
        INACTIVE,
        HIGHLIGHTED
    }

    /// <summary>
    /// Controller for an AP Bubble.
    /// </summary>
    public class APBubble : MonoBehaviour
    {
        /* Serialized Fields */
        [SerializeField] private Image fill;
        [SerializeField] private Color def;
        [SerializeField] private Color highlight;

        #region PUBLIC

        /// <summary> Set bubble fill state. </summary>
        public void SetFill(APBubbleState state)
        {
            switch (state)
            {
                case APBubbleState.ACTIVE:
                    fill.color = def;
                    fill.enabled = true;
                    break;
                case APBubbleState.INACTIVE:
                    fill.enabled = false;
                    break;
                case APBubbleState.HIGHLIGHTED:
                    fill.color = highlight;
                    fill.enabled = true;
                    break;
            }
        }

        #endregion
    }
}
