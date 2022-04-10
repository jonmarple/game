using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Toast.Game.Characters;

namespace Toast.Game.UI
{
    /// <summary>
    /// Enables/Disables Button based on Selected Character conditions.
    /// </summary>
    public class EndTurnButton : MonoBehaviour
    {
        /* Serialized Field */
        [SerializeField] private Button button;

        #region PUBLIC

        public void Refresh()
        {
            button.interactable = CharacterSelector.SelectedCharacter != null &&
                                  CharacterSelector.SelectedCharacter.Active &&
                                  CharacterSelector.SelectedCharacter.AI == null;
        }

        #endregion
    }
}
