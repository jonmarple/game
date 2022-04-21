using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Toast.Game.Actions;
using Toast.Game.Characters;

namespace Toast.Game.Combat
{
    /// <summary>
    /// Container for combat action information.
    /// </summary>
    public struct ActionInfo
    {
        /* Public Fields */
        public Action Action;
        public Character Source;
        public Character Target;
        public bool Crit;

        public ActionInfo(Action action, Character source, Character target, bool crit)
        {
            Action = action;
            Source = source;
            Target = target;
            Crit = crit;
        }
    }
}
