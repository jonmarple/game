using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Toast.Audio;

namespace Toast.Game.Actions
{
    /// <summary>
    /// Attack weapon action.
    /// </summary>
    public class Attack : Action
    {
        /* Public Fields */
        public int Modifier { get; private set; }

        public Attack(string name, int cost, int cooldown, int modifier, AudioKey audio = AudioKey.NONE)
        {
            InitBaseFields(name, cost, cooldown, audio);
            Modifier = modifier;
        }
    }
}
