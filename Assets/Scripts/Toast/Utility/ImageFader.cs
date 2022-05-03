using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Toast.Utility
{
    /// <summary>
    /// Fade image alpha.
    /// </summary>
    [RequireComponent(typeof(Image))]
    public class ImageFader : MonoBehaviour
    {
        /* Private Fields */
        private Image image;

        private void Awake()
        { image = GetComponent<Image>(); }

        #region PUBLIC

        /// <summary> Trigger image fade. </summary>
        public void Fade(float startAlpha, float targetAlpha, float duration)
        { StartCoroutine(HandleFade(startAlpha, targetAlpha, duration)); }

        #endregion

        #region PRIVATE

        private IEnumerator HandleFade(float startAlpha, float targetAlpha, float duration)
        {
            SetAlpha(startAlpha);
            float t = 0;
            while (t < duration)
            {
                yield return new WaitForEndOfFrame();
                t += Time.deltaTime;
                SetAlpha(Mathf.Lerp(startAlpha, targetAlpha, t / duration));
            }
            SetAlpha(targetAlpha);
        }

        private void SetAlpha(float a)
        {
            if (image)
            {
                Color c = image.color;
                c.a = a;
                image.color = c;
            }
        }

        #endregion
    }
}