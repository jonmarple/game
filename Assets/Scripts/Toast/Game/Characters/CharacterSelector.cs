using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Toast.Game.Actions;
using Toast.Audio;

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
            if (character != null && character.AI == null && !character.Stats.Dead)
            {
                Deselect(false);
                AudioManager.Play(AudioKey.CHARACTER_SELECT);
                ActionHelper.Deselect(false);
                SelectedCharacter = character;
                SelectedCharacter?.Select(true);
                SelectUpdated?.Invoke();
            }
        }

        /// <summary> Deselect current Character. </summary>
        public static void Deselect(bool sfx = true)
        {
            if (sfx) AudioManager.Play(AudioKey.CHARACTER_DESELECT);
            ActionHelper.Deselect(false);
            SelectedCharacter?.Select(false);
            SelectedCharacter = null;
            SelectUpdated?.Invoke();
        }

        /// <summary> Toggle specified Character. </summary>
        public static void ToggleSelect(Character character)
        {
            if (character == SelectedCharacter)
                Deselect(true);
            else
                Select(character);
        }

        /// <summary> Hover/unhover specified Character. </summary>
        public static void Hover(bool active, Character character = null)
        {
            if (active)
            {
                Hover(false);
                AudioManager.Play(AudioKey.CHARACTER_HOVER);
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
