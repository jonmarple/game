using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Toast.Game.Characters;

namespace Toast.Game.UI
{
    /// <summary>
    /// Controller for an Initiative Card.
    /// </summary>
    public class InitiativeCardController : MonoBehaviour
    {
        /* Serialized Fields */
        [SerializeField] private TextMeshProUGUI nameField;

        /* Private Fields */
        private Character character;

        #region PUBLIC

        /// <summary> Initialize card with character info. </summary>
        public void Initialize(Character character)
        {
            this.character = character;
            nameField.text = character.CharacterName;
        }

        #endregion
    }
}
