using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Toast.UI.Console
{
    /// <summary>
    /// Fades CanvasGroup based on inactivity.
    /// </summary>
    public class InactivityFader : MonoBehaviour
    {
        /* Serialized Fields */
        [SerializeField] private float timeout = 5f;
        [SerializeField] private float fadeSpeed = 10f;
        [SerializeField] private float maxAlpha = 1f;
        [SerializeField] private float minAlpha = 0.25f;
        [SerializeField] private CanvasGroup canvasGroup;

        /* Private Fields */
        private Coroutine timeoutcr;
        private bool active = false;
        private float targetAlpha = 1f;

        private void Start()
        {
            StartCoroutine(HandleAlpha());
            RegisterEvent();
        }

        #region PUBLIC

        /// <summary> Reset activity timer. </summary>
        public void RegisterEvent()
        {
            if (!active)
            {
                if (timeoutcr != null) StopCoroutine(timeoutcr);
                timeoutcr = StartCoroutine(Timeout());
            }
        }

        /// <summary> Lock activity positive. </summary>
        public void SetActive(bool active)
        {
            this.active = active;
            if (active)
            {
                if (timeoutcr != null) StopCoroutine(timeoutcr);
                targetAlpha = maxAlpha;
            }
            else RegisterEvent();
        }

        #endregion

        #region PRIVATE

        private IEnumerator HandleAlpha()
        {
            while (true)
            {
                yield return new WaitForEndOfFrame();
                canvasGroup.alpha = Mathf.Lerp(canvasGroup.alpha, targetAlpha, fadeSpeed * Time.deltaTime);
            }
        }

        private IEnumerator Timeout()
        {
            targetAlpha = maxAlpha;
            yield return new WaitForSecondsRealtime(timeout);
            targetAlpha = minAlpha;
        }

        #endregion
    }
}
