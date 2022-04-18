using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Toast.Game.Characters;

namespace Toast.Game.UI
{
    /// <summary>
    /// Displays character attack buttons.
    /// </summary>
    public class AttackPanel : MonoBehaviour
    {
        /* Serialized Fields */
        [SerializeField] private CanvasGroup canvasGroup;
        [SerializeField] private float fadeSpeed = 10f;

        /* Private Fields */
        private float targetAlpha = 0f;

        private void Start()
        {
            StartCoroutine(HandleAlpha());
            Refresh();
        }

        private void OnEnable()
        { CharacterSelector.SelectUpdated += Refresh; }

        private void OnDisable()
        { CharacterSelector.SelectUpdated -= Refresh; }

        #region PUBLIC

        public void Refresh()
        {
            targetAlpha = (CharacterSelector.SelectedCharacter != null &&
                           CharacterSelector.SelectedCharacter.AI == null
                           ) ? 1f : 0f;
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

        #endregion
    }
}
