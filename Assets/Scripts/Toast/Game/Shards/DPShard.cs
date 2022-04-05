using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Toast.Game.Actions;

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
            Roll = new Roll("DPShard Roll", 1, this);
        }

        #region PUBLIC

        /// <summary> Generate random DPShard. </summary>
        new public static DPShard Generate(int value)
        { return new DPShard(Spread.Generate(value)); }

        #endregion
    }
}
