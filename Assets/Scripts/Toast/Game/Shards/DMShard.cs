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
        public DMShard(Spread spread)
        {
            Spread = spread;
            Roll = new Roll("DMShard Roll", 1, this);
        }

        #region PUBLIC

        /// <summary> Generate random DMShard. </summary>
        new public static DMShard Generate(int value)
        { return new DMShard(Spread.Generate(value)); }

        #endregion
    }
}
