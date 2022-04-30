using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Toast.Game.Characters;

namespace Toast.Game.UI
{
    /// <summary>
    /// Controller for the main Char UI.
    /// </summary>
    public class CharUIMain : MonoBehaviour
    {
        /* Serialized Fields */
        [SerializeField] private RectTransform container;
        [SerializeField] private HandUI handUI;
        [SerializeField] private ShardList shardList;
        [SerializeField] private APBar apBar;
        [SerializeField] private StatBar statBar;

        private void OnEnable()
        { CharacterSelector.SelectUpdated += Refresh; }

        private void OnDisable()
        { CharacterSelector.SelectUpdated -= Refresh; }

        #region PUBLIC

        /// <summary> Refresh UI. </summary>
        public void Refresh()
        {
            bool active = CharacterSelector.SelectedCharacter != null &&
                          CharacterSelector.SelectedCharacter.AI == null;

            container.gameObject.SetActive(active);

            handUI.Refresh();
            shardList.Refresh();
            apBar.Refresh();
            statBar.Register(CharacterSelector.SelectedCharacter);
        }

        #endregion
    }
}
