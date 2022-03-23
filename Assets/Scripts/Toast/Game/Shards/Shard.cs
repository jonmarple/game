using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Toast.Game.Actions;

namespace Toast.Game.Shards
{
    /// <summary>
    /// Base Shard type.
    /// </summary>
    public abstract class Shard
    {
        /* Public Fields */
        public Spread Spread { get; protected set; }
        public Roll Roll { get; protected set; }

        #region PUBLIC

        /// <summary> Generate random Shard. </summary>
        public static Shard Generate()
        {
            switch (Random.Range(1, 6))
            {
                case 1:
                    return APShard.Generate();
                case 2:
                    return AMShard.Generate();
                case 3:
                    return DPShard.Generate();
                case 4:
                    return DMShard.Generate();
                case 5:
                    return MShard.Generate();
            }
            return null;
        }

        #endregion
    }
}
