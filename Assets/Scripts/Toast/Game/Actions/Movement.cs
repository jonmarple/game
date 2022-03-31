using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Toast.Game.Actions
{
    /// <summary>
    /// Movement action.
    /// </summary>
    public class Movement : Action
    {
        /* Public Fields */
        public MovementType Type { get; private set; }

        public Movement(string name, int cost, int cooldown, MovementType type)
        {
            InitBaseFields(name, cost, cooldown);
            Type = type;
        }
    }
}
