using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Toast.Game.Combat;
using Toast.Game.Characters;

namespace Toast.Game.UI
{
    /// <summary>
    /// Controller for a Party List.
    /// </summary>
    public class PartyList : MonoBehaviour
    {
        /* Serialized Fields */
        [SerializeField] private PartyCard partyCardPrefab;
        [SerializeField] private RectTransform cardContainer;
        [SerializeField] private Faction faction;

        /* Private Fields */
        private CharacterGroup group;

        private void OnEnable()
        { CombatFlow.CombatStart += Initialize; }

        private void OnDisable()
        { CombatFlow.CombatStart -= Initialize; }

        #region PUBLIC

        /// <summary> Initialize list. </summary>
        public void Initialize()
        {
            Clear();

            group = CombatFlow.GetGroup(faction);

            foreach (Character character in group.Characters)
                Instantiate(partyCardPrefab, cardContainer).Initialize(character);
        }

        /// <summary> Clear list. </summary>
        public void Clear()
        {
            foreach (Transform child in cardContainer)
                Destroy(child.gameObject);
        }

        #endregion
    }
}
