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
        public DPShard()
        {
            Spread = new Spread(5, 2);
            Roll = new Roll("DPShard Roll", 1, this);
        }

        public DPShard(Spread spread)
        {
            Spread = spread;
            Roll = new Roll("DPShard Roll", 1, this);
        }

        #region PUBLIC

        /// <summary> Generate random DPShard. </summary>
        new public static DPShard Generate()
        { return new DPShard(); }

        #endregion
    }
}
