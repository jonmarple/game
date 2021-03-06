using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Toast.Game.Actions;
using Toast.Audio;

namespace Toast.Game.Shards
{
    /// <summary>
    /// Physical Damage Shard.
    /// </summary>
    public class DPShard : Shard
    {
        public DPShard(Spread spread)
        {
            Spread = spread;
            Roll = new Roll(ToString(), 1, this, AudioKey.SHARD_ROLL);
        }

        #region PUBLIC

        /// <summary> Generate random DPShard. </summary>
        new public static DPShard Generate(int value)
        { return new DPShard(Spread.Generate(value)); }

        public override string ToString()
        { return "DP-" + Spread.ToString(); }

        #endregion
    }
}
