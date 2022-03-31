using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Toast.Game.Actions
{
    /// <summary>
    /// Attack weapon action.
    /// </summary>
    public class Attack : Action
    {
        /* Public Fields */
        public int Modifier { get; private set; }

        public Attack(string name, int cost, int cooldown, int modifier)
        {
            InitBaseFields(name, cost, cooldown);
            Modifier = modifier;
        }
    }
}
