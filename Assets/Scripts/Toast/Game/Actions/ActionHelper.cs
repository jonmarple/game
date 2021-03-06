using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Toast.Game.Characters;
using Toast.Audio;

namespace Toast.Game.Actions
{
    /// <summary>
    /// Assists with Action control.
    /// </summary>
    public static class ActionHelper
    {
        /* Public Fields */
        public static Action SelectedAction;
        public static Action HoveredAction;
        public static bool Targeting { get { return SelectedAction != null; } }

        /* Value Update Delegate/Event */
        public delegate void Updated();
        public static event Updated SelectUpdated;
        public static event Updated HoverUpdated;

        #region PUBLIC

        /// <summary> Select specified Action. </summary>
        public static void Select(Action action)
        {
            Deselect(false);
            AudioManager.Play(AudioKey.ACTION_SELECT);
            SelectedAction = action;
            SelectUpdated?.Invoke();
        }

        /// <summary> Deselect current Action. </summary>
        public static void Deselect(bool sfx = true)
        {
            if (sfx) AudioManager.Play(AudioKey.ACTION_DESELECT);
            SelectedAction = null;
            SelectUpdated?.Invoke();
        }

        /// <summary> Perform action on target. </summary>
        public static void Target(Character target)
        {
            Character source = CharacterSelector.SelectedCharacter;
            Action action = SelectedAction;

            if (source != null && target != null && action != null)
            {
                switch (action)
                {
                    case Attack attack:
                        if (source.Faction != target.Faction)
                            Perform(source, action, target);
                        break;
                    case Regen regen:
                    case Roll roll:
                        if (source.Faction == target.Faction)
                            Perform(source, action, target);
                        break;
                }
            }
        }

        /// <summary> Hover/unhover specified Action. </summary>
        public static void Hover(bool active, Action action = null)
        {
            if (active)
            {
                Hover(false);
                AudioManager.Play(AudioKey.ACTION_HOVER);
                HoveredAction = action;
                HoverUpdated?.Invoke();
            }
            else
            {
                HoveredAction = null;
                HoverUpdated?.Invoke();
            }
        }

        #endregion

        #region PRIVATE

        private static void Perform(Character source, Action action, Character target)
        {
            source.PerformAction(action, target);
            Deselect(false);
        }

        #endregion
    }
}
