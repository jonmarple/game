using System.Collections;
using System.Collections.Generic;
using UnityEngine;
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
        [SerializeField] private RectTransform targetPrefab;
        [SerializeField] private RectTransform cardContainer;
        [SerializeField] private RectTransform targetContainer;

        /* Private Fields */
        private Dictionary<InitiativeCardController, RectTransform> cardTargets;

        private void Start()
        {
            CombatFlow.CombatStart += Initialize;
            CombatFlow.TurnStart += Refresh;
            CombatFlow.TurnFinish += Refresh;
            CombatFlow.CombatFinish += Refresh;
        }

        #region PUBLIC

        /// <summary> Initialize list. </summary>
        public void Initialize()
        {
            Clear();

            cardTargets = new Dictionary<InitiativeCardController, RectTransform>();

            foreach (Character character in CombatFlow.GroupA.Characters)
                Add(character, CombatFlow.GroupA.Faction);

            foreach (Character character in CombatFlow.GroupB.Characters)
                Add(character, CombatFlow.GroupB.Faction);

            Refresh();
        }

        /// <summary> Clear list. </summary>
        public void Clear()
        {
            if (cardTargets != null)
            {
                foreach (InitiativeCardController card in cardTargets.Keys)
                {
                    if (cardTargets[card]) Destroy(cardTargets[card].gameObject);
                    if (card) Destroy(card.gameObject);
                }
                cardTargets.Clear();
            }
        }

        /// <summary> Refresh cards and list. </summary>
        public void Refresh()
        {
            if (CombatFlow.Order != null)
            {
                foreach (Character character in CombatFlow.Order)
                {
                    InitiativeCardController card = GetCard(character);
                    if (card)
                    {
                        if (character.Stats.Dead) Remove(card);
                        else ((RectTransform)cardTargets[card].transform).SetAsLastSibling();
                    }
                }
            }
        }

        #endregion

        #region PRIVATE

        private InitiativeCardController GetCard(Character character)
        {
            foreach (InitiativeCardController card in cardTargets.Keys)
                if (character == card.Character)
                    return card;
            return null;
        }

        private void Add(Character character, Faction faction)
        {
            InitiativeCardController card = Instantiate(cardControllerPrefab, cardContainer.transform);
            RectTransform target = Instantiate(targetPrefab, targetContainer.transform);
            card.Initialize(character, faction, target);
            cardTargets.Add(card, target);
        }

        private void Remove(InitiativeCardController card)
        {
            if (cardTargets[card]) Destroy(cardTargets[card].gameObject);
            cardTargets.Remove(card);
            if (card) Destroy(card.gameObject);
        }

        #endregion
    }
}
