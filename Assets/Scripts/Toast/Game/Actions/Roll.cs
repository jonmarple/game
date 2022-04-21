using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Toast.Game.Shards;
using Toast.Audio;

namespace Toast.Game.Actions
{
    /// <summary>
    /// Shard Roll action.
    /// </summary>
    public class Roll : Action
    {
        /* Public Fields */
        public Shard Shard { get; private set; }

        public Roll(string name, int cost, Shard shard, AudioKey audio = AudioKey.NONE)
        {
            InitBaseFields(name, cost, 0, audio);
            Shard = shard;
        }
    }
}
