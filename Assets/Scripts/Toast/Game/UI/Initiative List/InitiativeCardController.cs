using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Toast.Game.Characters;

namespace Toast.Game.UI
{
    /// <summary>
    /// Controller for an Initiative Card.
    /// </summary>
    public class InitiativeCardController : MonoBehaviour
    {
        /* Public Fields */
        public Character Character { get; private set; }

        /* Serialized Fields */
        [SerializeField] private Color primaryColor;
        [SerializeField] private Color secondaryColor;
        [SerializeField] private Outline outline;
        [SerializeField] private TextMeshProUGUI nameField;

        #region PUBLIC

        /// <summary> Initialize card with character info. </summary>
        public void Initialize(Character character, bool primaryGroup)
        {
            Character = character;
            nameField.text = Character.CharacterName;
            outline.effectColor = primaryGroup ? primaryColor : secondaryColor;
        }

        #endregion
    }
}
