using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Toast.Game.Actions;
using Toast.Game.Shards;
using Toast.UI;

namespace Toast.Game.UI
{
    /// <summary>
    /// Controller for a Shard.
    /// </summary>
    public class ShardController : ActionButton
    {
        /* Public Fields */
        public Shard Shard { get; private set; }

        /* Serialized Fields */
        [SerializeField] private RectLerp lerp;

        #region PUBLIC

        /// <summary> Initialize shard info. </summary>
        public void Initialize(Shard shard, RectTransform target)
        {
            Shard = shard;
            SetAction(Shard.Roll);
            lerp.SetTarget(target);
            Refresh();
        }

        #endregion
    }
}
