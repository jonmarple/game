using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Toast.Game.Actions
{
    /// <summary>
    /// Defend action.
    /// </summary>
    [System.Serializable]
    public class Defend : Action
    {
        /* Public Fields */
        public int Modifier { get { return modifier; } }

        /* Private Fields */
        private int modifier;

        public Defend(string name, int cost, int modifier)
        {
            this.actionName = name;
            this.cost = cost;
            this.modifier = modifier;
        }
    }
}
