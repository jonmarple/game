using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Toast.Game.Actions
{
    /// <summary>
    /// Movement action.
    /// </summary>
    [System.Serializable]
    public class Movement : Action
    {
        /* Public Fields */
        public MovementType Type { get { return type; } }

        /* Private Fields */
        private MovementType type;

        public Movement(string name, int cost, MovementType type)
        {
            this.actionName = name;
            this.cost = cost;
            this.type = type;
        }
    }
}
