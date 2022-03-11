using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Toast.Game.Actions
{
    /// <summary>
    /// Regen weapon action.
    /// </summary>
    [System.Serializable]
    public class Regen : Action
    {
        /* Public Fields */
        public int Modifier { get { return modifier; } }
        public RegenType Type { get { return regenType; } }

        /* Private Fields */
        private int modifier;
        private RegenType regenType;

        public Regen(string name, int cost, int modifier, RegenType type)
        {
            this.actionName = name;
            this.cost = cost;
            this.modifier = modifier;
            this.regenType = type;
        }
    }
}
