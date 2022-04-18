using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Toast.Game.Actions;

namespace Toast.Game.Shards
{
    /// <summary>
    /// Multiplication Shard.
    /// </summary>
    public class MShard : Shard
    {
        public MShard(Spread spread)
        {
            Spread = spread;
            Roll = new Roll(ToString(), 1, this);
        }

        #region PUBLIC

        /// <summary> Generate random MShard. </summary>
        public static MShard Generate()
        { return new MShard(Spread.Generate(Random.Range(2, 4))); }

        public override string ToString()
        { return "M-" + Spread.ToString(); }
    }

    #endregion
}
