using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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

        #endregion
    }
}
