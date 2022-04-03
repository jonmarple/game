using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Toast.Game.Actions;

namespace Toast.Game.Shards
{
    /// <summary>
    /// Magical Damage Shard.
    /// </summary>
    public class DMShard : Shard
    {
        public DMShard()
        {
            Spread = new Spread(5, 2);
            Roll = new Roll("DMShard Roll", 1, this);
        }

        public DMShard(Spread spread)
        {
            Spread = spread;
            Roll = new Roll("DMShard Roll", 1, this);
        }

        #region PUBLIC

        /// <summary> Generate random DMShard. </summary>
        new public static DMShard Generate()
        { return new DMShard(); }

        #endregion
    }
}
