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
        public MovementType Type { get; private set; }

        public Movement(string name, int cost, MovementType type)
        {
            ActionName = name;
            Cost = cost;
            Type = type;
        }
    }
}
