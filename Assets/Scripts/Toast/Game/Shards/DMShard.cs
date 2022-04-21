using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Toast.Game.Actions;
using Toast.Audio;

namespace Toast.Game.Shards
{
    /// <summary>
    /// Magical Damage Shard.
    /// </summary>
    public class DMShard : Shard
    {
        public DMShard(Spread spread)
        {
            Spread = spread;
            Roll = new Roll(ToString(), 1, this, AudioKey.SHARD_ROLL);
        }

        #region PUBLIC

        /// <summary> Generate random DMShard. </summary>
        new public static DMShard Generate(int value)
        { return new DMShard(Spread.Generate(value)); }

        public override string ToString()
        { return "DM-" + Spread.ToString(); }

        #endregion
    }
}
