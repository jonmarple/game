using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Toast.Game.Actions;

namespace Toast.Game.Characters
{
    /// <summary>
    /// Character Selection Controller.
    /// </summary>
    public class CharacterSelector
    {
        /* Public Fields */
        public static Character SelectedCharacter;
        public static Character HoveredCharacter;

        /* Value Update Delegate/Event */
        public delegate void Updated();
        public static event Updated SelectUpdated;
        public static event Updated HoverUpdated;

        #region PUBLIC

        /// <summary> Select specified Character. </summary>
        public static void Select(Character character)
        {
            Deselect();
            ActionHelper.Deselect();
            SelectedCharacter = character;
            SelectedCharacter?.Select(true);
            SelectUpdated?.Invoke();
        }

        /// <summary> Deselect current Character. </summary>
        public static void Deselect()
        {
            ActionHelper.Deselect();
            SelectedCharacter?.Select(false);
            SelectedCharacter = null;
            SelectUpdated?.Invoke();
        }

        /// <summary> Toggle specified Character. </summary>
        public static void ToggleSelect(Character character)
        {
            if (character == SelectedCharacter)
                Deselect();
            else
                Select(character);
        }

        /// <summary> Hover/unhover specified Character. </summary>
        public static void Hover(bool active, Character character = null)
        {
            if (active)
            {
                Hover(false);
                HoveredCharacter = character;
                HoveredCharacter?.Hover(true);
                HoverUpdated?.Invoke();
            }
            else
            {
                HoveredCharacter?.Hover(false);
                HoveredCharacter = null;
                HoverUpdated?.Invoke();
            }
        }

        #endregion
    }
}
