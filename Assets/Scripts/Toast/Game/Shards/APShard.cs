using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Toast.Game.Actions;
using Toast.Audio;

namespace Toast.Game.Shards
{
    /// <summary>
    /// Physical Armor Shard.
    /// </summary>
    public class APShard : Shard
    {
        public APShard(Spread spread)
        {
            Spread = spread;
            Roll = new Roll(ToString(), 1, this, AudioKey.SHARD_ROLL);
        }

        #region PUBLIC

        /// <summary> Generate random APShard. </summary>
        new public static APShard Generate(int value)
        { return new APShard(Spread.Generate(value)); }

        public override string ToString()
        { return "AP-" + Spread.ToString(); }

        #endregion
    }
}
