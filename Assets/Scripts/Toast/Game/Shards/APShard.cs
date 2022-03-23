using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Toast.Game.Actions;

namespace Toast.Game.Shards
{
    /// <summary>
    /// Physical Armor Shard.
    /// </summary>
    public class APShard : Shard
    {
        public APShard()
        {
            Spread = new Spread();
            Roll = new Roll("APShard Roll", 1, this);
        }

        #region PUBLIC

        /// <summary> Generate random APShard. </summary>
        new public static APShard Generate()
        { return new APShard(); }

        #endregion
    }
}
