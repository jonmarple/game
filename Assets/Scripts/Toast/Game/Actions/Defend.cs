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
        public int Modifier { get; private set; }

        public Defend(string name, int cost, int modifier)
        {
            ActionName = name;
            Cost = cost;
            Modifier = modifier;
        }
    }
}
