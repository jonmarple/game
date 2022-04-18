using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Toast.Game.Characters;

namespace Toast.Game.Actions
{
    /// <summary>
    /// Assists with Action control.
    /// </summary>
    public static class ActionHelper
    {
        /* Public Fields */
        public static Action SelectedAction;
        public static bool Targeting { get { return SelectedAction != null; } }

        /* Value Update Delegate/Event */
        public delegate void Updated();
        public static event Updated SelectUpdated;

        #region PUBLIC

        /// <summary> Select specified Action. </summary>
        public static void Select(Action action)
        {
            Deselect();
            SelectedAction = action;
            SelectUpdated?.Invoke();
        }

        /// <summary> Deselect current Action. </summary>
        public static void Deselect()
        {
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
                        if (source.Faction == target.Faction)
                            Perform(source, action, target);
                        break;
                    case Roll roll:
                        if (source.Faction == target.Faction)
                            Perform(source, action, target);
                        break;
                }
            }
        }

        #endregion

        #region PRIVATE

        private static void Perform(Character source, Action action, Character target)
        {
            source.PerformAction(action, target);
            Deselect();
        }

        #endregion
    }
}
