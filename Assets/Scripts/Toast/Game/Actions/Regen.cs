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
        public int Modifier { get; private set; }
        public RegenType Type { get; private set; }

        public Regen(string name, int cost, int modifier, RegenType type)
        {
            ActionName = name;
            Cost = cost;
            Modifier = modifier;
            Type = type;
        }
    }
}
