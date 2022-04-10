using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Toast.Game.Characters;
using Toast.Game.Combat;

namespace Toast.Game.UI
{
    /// <summary>
    /// Controller for an Initiative List.
    /// </summary>
    public class InitiativeListController : MonoBehaviour
    {
        /* Serialized Fields */
        [SerializeField] private InitiativeCardController cardControllerPrefab;
        [SerializeField] private HorizontalLayoutGroup container;

        /* Private Fields */
        private List<InitiativeCardController> cards;

        #region PUBLIC

        /// <summary> Initialize list. </summary>
        public void Initialize()
        {
            Clear();

            cards = new List<InitiativeCardController>();

            foreach (Character character in CombatFlow.GroupA.Characters)
            {
                InitiativeCardController card = Instantiate(cardControllerPrefab, container.transform);
                card.Initialize(character, CombatFlow.GroupA.Faction);
                cards.Add(card);
            }

            foreach (Character character in CombatFlow.GroupB.Characters)
            {
                InitiativeCardController card = Instantiate(cardControllerPrefab, container.transform);
                card.Initialize(character, CombatFlow.GroupB.Faction);
                cards.Add(card);
            }

            Refresh();
        }

        /// <summary> Clear list. </summary>
        public void Clear()
        {
            if (cards != null)
            {
                foreach (InitiativeCardController card in cards)
                    if (card) Destroy(card.gameObject);
                cards.Clear();
            }
        }

        /// <summary> Refresh cards. </summary>
        public void Refresh()
        {
            if (CombatFlow.Order != null)
            {
                foreach (Character character in CombatFlow.Order)
                {
                    InitiativeCardController card = GetCard(character);
                    if (card)
                    {
                        if (character.Stats.Dead)
                            Destroy(card.gameObject);
                        else
                            ((RectTransform)card.transform).SetAsLastSibling();
                    }
                }
                RefreshOutlines();
            }
        }

        /// <summary> Refresh card outlines. </summary>
        public void RefreshOutlines()
        {
            foreach (InitiativeCardController card in cards)
                card.RefreshOutline();
        }

        #endregion

        #region PRIVATE

        private InitiativeCardController GetCard(Character character)
        {
            foreach (InitiativeCardController card in cards)
                if (character == card.Character)
                    return card;
            return null;
        }

        #endregion
    }
}
