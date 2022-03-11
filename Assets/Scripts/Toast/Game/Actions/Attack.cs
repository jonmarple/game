using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Toast.Game.Actions
{
    /// <summary>
    /// Attack weapon action.
    /// </summary>
    [System.Serializable]
    public class Attack : Action
    {
        /* Public Fields */
        public int Modifier { get { return modifier; } }

        /* Private Fields */
        private int modifier;

        public Attack(string name, int cost, int modifier)
        {
            this.actionName = name;
            this.cost = cost;
            this.modifier = modifier;
        }
    }
}
