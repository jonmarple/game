using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Toast.Game.Actions;

namespace Toast.Game.Shards
{
    /// <summary>
    /// Magical Armor Shard.
    /// </summary>
    public class AMShard : Shard
    {
        public AMShard()
        {
            Spread = new Spread();
            Roll = new Roll("AMShard Roll", 1, this);
        }

        #region PUBLIC

        /// <summary> Generate random AMShard. </summary>
        new public static AMShard Generate()
        { return new AMShard(); }

        #endregion
    }
}
