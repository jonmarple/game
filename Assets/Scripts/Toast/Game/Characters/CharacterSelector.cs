using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityAtoms.BaseAtoms;

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

        /* Private Fields */
        private static BoolEvent OnSelect;
        private static BoolEvent OnHover;

        #region PUBLIC

        /// <summary> Select specified Character. </summary>
        public static void Select(Character character)
        {
            Deselect();
            SelectedCharacter = character;
            SelectedCharacter?.Select(true);
            OnSelect?.Raise(true);
        }

        /// <summary> Deselect current Character. </summary>
        public static void Deselect()
        {
            SelectedCharacter?.Select(false);
            SelectedCharacter = null;
            OnSelect?.Raise(false);
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
                OnHover?.Raise(true);
            }
            else
            {
                HoveredCharacter?.Hover(false);
                HoveredCharacter = null;
                OnHover?.Raise(false);
            }
        }

        public static void SetSelectionEvent(BoolEvent select)
        { OnSelect = select; }

        public static void SetHoverEvent(BoolEvent hover)
        { OnHover = hover; }

        #endregion
    }
}
