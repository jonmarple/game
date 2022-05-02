using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Toast.Game.UI
{
    /// <summary>
    /// Controller for an Info Panel Hover Target.
    /// </summary>
    public class InfoPanelTarget : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
    {
        /* Private Fields */
        private InfoPanel panel;
        private float delay = 0f;
        private Coroutine handler;

        #region PUBLIC

        /// <summary> Init hover target. </summary>
        public void Initialize(InfoPanel panel, float delay)
        {
            this.panel = panel;
            this.delay = delay;
            panel.SetActive(false);
        }

        public void OnPointerEnter(PointerEventData data)
        { OnHover(true); }

        public void OnPointerExit(PointerEventData data)
        { OnHover(false); }

        #endregion

        #region PRIVATE

        private void OnHover(bool active)
        {
            if (handler != null) StopCoroutine(handler);
            if (active) handler = StartCoroutine(HandleHover());
            else panel.SetActive(false);
        }

        private IEnumerator HandleHover()
        {
            yield return new WaitForSeconds(delay);
            panel.SetActive(true);
        }

        #endregion
    }
}
