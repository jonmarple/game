using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using Toast.Utility;

namespace Toast.Transition
{
    /// <summary>
    /// Scene transition controller.
    /// </summary>
    public class TransitionController : MonoBehaviour
    {
        /* Public Fields */
        public static TransitionController Instance;

        /* Serialized Fields */
        [SerializeField] private TransitionManager manager;
        [SerializeField] private AudioMixer mixer;
        [SerializeField] private GameObject blocker2D;
        [SerializeField] private GameObject blockerUI;
        [SerializeField] private ImageFader fadePanel;

        /* Private Fields */
        private Coroutine transition;
        private const float ZERO = 0f;
        private const float ONE = 1f;
        private float preDelay = 0.25f;
        private float postDelay = 0.5f;
        private float duration = 0.5f;

        private void Awake()
        { Instance = this; }

        private void Start()
        { StartCoroutine(HandleSetup()); }

        #region PUBLIC

        /// <summary> Transition to scene. </summary>
        public void TransitionTo(string scene)
        { if (transition == null) transition = StartCoroutine(HandleTransition(scene)); }

        /// <summary> Fade panel. </summary>
        public void FadePanel(bool active, float duration)
        { fadePanel.Fade(active ? ZERO : ONE, active ? ONE : ZERO, duration); }

        /// <summary> Fade master audio. </summary>
        public void FadeAudio(bool active, float duration)
        { StartCoroutine(HandleFadeAudio(active, duration)); }

        #endregion

        #region PRIVATE

        private IEnumerator HandleSetup()
        {
            mixer.SetFloat("MasterVolume", Mathf.Log10(ZERO) * 20);
            fadePanel.gameObject.SetActive(true);
            SetBlockers(true);
            yield return new WaitForSecondsRealtime(preDelay);
            FadePanel(false, duration);
            FadeAudio(true, duration);
            yield return new WaitForSecondsRealtime(duration);
            SetBlockers(false);
        }

        private IEnumerator HandleTransition(string scene)
        {
            SetBlockers(true);
            yield return new WaitForSecondsRealtime(preDelay);
            FadePanel(true, duration);
            FadeAudio(false, duration);
            yield return new WaitForSecondsRealtime(duration);
            yield return new WaitForSecondsRealtime(postDelay);
            manager.Load(scene);
        }

        private IEnumerator HandleFadeAudio(bool active, float duration)
        {
            (float startVol, float targetVol) = active ? (ZERO, ONE) : (ONE, ZERO);
            mixer.SetFloat("MasterVolume", Mathf.Log10(startVol) * 20);
            float t = 0;
            float v;
            mixer.GetFloat("MasterVolume", out v);
            v = Mathf.Pow(10, v / 20);
            float target = Mathf.Clamp(targetVol, 0.0001f, 1f);
            while (t < duration)
            {
                t += Time.deltaTime;
                float newVol = Mathf.Lerp(v, target, t / duration);
                mixer.SetFloat("MasterVolume", Mathf.Log10(newVol) * 20);
                yield return null;
            }
            // mixer.SetFloat("MasterVolume", Mathf.Log10(targetVol) * 20);
        }

        private void SetBlockers(bool active)
        {
            blocker2D.SetActive(active);
            blockerUI.SetActive(active);
        }

        #endregion
    }
}