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
        public MShard()
        {
            Spread = new Spread();
            Roll = new Roll("MShard Roll", 1, this);
        }

        #region PUBLIC

        /// <summary> Generate random MShard. </summary>
        new public static MShard Generate()
        { return new MShard(); }

        #endregion
    }
}
