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
            foreach (Character character in CombatFlow.Order)
            {
                InitiativeCardController card = Instantiate(cardControllerPrefab, container.transform);
                card.Initialize(character);
                cards.Add(card);
            }
        }

        /// <summary> Clear list. </summary>
        public void Clear()
        {
            if (cards != null)
            {
                foreach (InitiativeCardController card in cards)
                    Destroy(card.gameObject);
                cards.Clear();
            }
        }

        /// <summary> Turn update. </summary>
        public void Turn()
        {
            // TODO: move cards
        }

        #endregion
    }
}
