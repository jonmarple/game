using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Toast.Game.Characters;

namespace Toast.Game.UI
{
    /// <summary>
    /// Controller for the AP Bar.
    /// </summary>
    public class APBar : MonoBehaviour
    {
        /* Serialized Fields */
        [SerializeField] private APBubble apBubblePrefab;
        [SerializeField] private RectTransform container;

        /* Private Fields */
        private List<APBubble> apBubbles;
        private Character character;

        private void Start()
        {
            apBubbles = new List<APBubble>();
            Refresh();
        }

        private void OnEnable()
        { CharacterSelector.SelectUpdated += Refresh; }

        private void OnDisable()
        { CharacterSelector.SelectUpdated -= Refresh; }

        #region PUBLIC

        /// <summary> Refresh bar. </summary>
        public void Refresh()
        {
            UpdateCharacter();

            bool active = CharacterSelector.SelectedCharacter != null &&
                          CharacterSelector.SelectedCharacter.AI == null;

            container.gameObject.SetActive(active);

            if (active)
            {
                if (apBubbles.Count < character.Stats.APMax)
                    for (int i = apBubbles.Count; i < character.Stats.APMax; i++)
                        Add(Instantiate(apBubblePrefab, container));
                else if (apBubbles.Count > character.Stats.APMax)
                    for (int i = apBubbles.Count - 1; i >= character.Stats.APMax; i--)
                        Remove(apBubbles[i]);
                for (int i = 0; i < apBubbles.Count; i++)
                    apBubbles[i].SetFill(character.Stats.AP > i);
            }
        }

        #endregion

        #region PRIVATE

        private void UpdateCharacter()
        {
            if (character != null) character.Stats.ValueUpdated -= Refresh;
            character = CharacterSelector.SelectedCharacter;
            if (character != null) character.Stats.ValueUpdated += Refresh;
        }

        private void Add(APBubble bubble)
        {
            apBubbles.Add(bubble);
        }

        private void Remove(APBubble bubble)
        {
            apBubbles.Remove(bubble);
            Destroy(bubble.gameObject);
        }

        #endregion
    }
}
