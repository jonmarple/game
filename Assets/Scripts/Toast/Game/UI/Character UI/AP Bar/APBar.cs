using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Toast.Game.Actions;
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
        {
            ActionHelper.SelectUpdated += Refresh;
            ActionHelper.HoverUpdated += Refresh;
        }

        private void OnDisable()
        {
            ActionHelper.SelectUpdated -= Refresh;
            ActionHelper.HoverUpdated -= Refresh;
        }

        #region PUBLIC

        /// <summary> Refresh UI. </summary>
        public void Refresh()
        {
            UpdateCharacter();

            if (gameObject.activeInHierarchy && character != null)
            {
                // fixing number of ap bubbles
                if (apBubbles.Count < character.Stats.APMax)
                    for (int i = apBubbles.Count; i < character.Stats.APMax; i++)
                        Add(Instantiate(apBubblePrefab, container));
                else if (apBubbles.Count > character.Stats.APMax)
                    for (int i = apBubbles.Count - 1; i >= character.Stats.APMax; i--)
                        Remove(apBubbles[i]);

                // coloring bubbles
                for (int i = 0; i < apBubbles.Count; i++)
                    if (character.Stats.AP > i)
                        apBubbles[i].SetFill(APBubbleState.ACTIVE);
                    else
                        apBubbles[i].SetFill(APBubbleState.INACTIVE);
                int cost = (ActionHelper.HoveredAction != null ? ActionHelper.HoveredAction.Cost : (ActionHelper.SelectedAction != null ? ActionHelper.SelectedAction.Cost : 0));
                cost = Mathf.Min(character.Stats.AP, cost);
                int start = (character.Stats.AP - cost);
                for (int i = start; i < Mathf.Min(apBubbles.Count, start + cost); i++)
                    apBubbles[i].SetFill(APBubbleState.HIGHLIGHTED);
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
