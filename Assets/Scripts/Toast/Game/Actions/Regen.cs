using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Toast.Game.Actions
{
    /// <summary>
    /// Regen weapon action.
    /// </summary>
    public class Regen : Action
    {
        /* Public Fields */
        public int Modifier { get; private set; }

        public Regen(string name, int cost, int cooldown, int modifier)
        {
            InitBaseFields(name, cost, cooldown);
            Modifier = modifier;
        }
    }
}
