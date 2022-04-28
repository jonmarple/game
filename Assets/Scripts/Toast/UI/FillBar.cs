using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Toast.UI
{
    /// <summary>
    /// Fill Image Bar controller.
    /// </summary>
    public class FillBar : MonoBehaviour
    {
        /* Serialized Fields */
        [SerializeField] private Image image;
        [SerializeField] private Image bg;
        [SerializeField] private float speed;

        /* Private Fields */
        private float target = 1f;
        private Coroutine fader;

        #region PUBLIC

        /// <summary> Set image fill value. </summary>
        public void SetFill(float fill)
        {
            if (fader != null) StopCoroutine(fader);
            fader = StartCoroutine(RunFade(fill));
        }

        /// <summary> Set image fill value. </summary>
        public void SetActive(bool active)
        {
            if (fader != null) StopCoroutine(fader);
            image.enabled = active;
            bg.enabled = active;
        }

        #endregion

        #region PRIVATE

        private IEnumerator RunFade(float fill)
        {
            target = fill;
            while (image.fillAmount != target)
            {
                yield return new WaitForEndOfFrame();
                image.fillAmount = Mathf.Lerp(image.fillAmount, target, speed * Time.deltaTime);
            }
        }

        #endregion
    }
}