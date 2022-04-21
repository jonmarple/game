using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Toast.Game.Actions;
using Toast.Audio;

namespace Toast.Game.Shards
{
    /// <summary>
    /// Magical Armor Shard.
    /// </summary>
    public class AMShard : Shard
    {
        public AMShard(Spread spread)
        {
            Spread = spread;
            Roll = new Roll(ToString(), 1, this, AudioKey.SHARD_ROLL);
        }

        #region PUBLIC

        /// <summary> Generate random AMShard. </summary>
        new public static AMShard Generate(int value)
        { return new AMShard(Spread.Generate(value)); }

        public override string ToString()
        { return "AM-" + Spread.ToString(); }

        #endregion
    }
}
