using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Toast.Game.Items
{
    /// <summary>
    /// Base Item.
    /// </summary>
    [System.Serializable]
    public abstract class Item
    {
        /* Public Fields */
        public string ItemName { get { return itemName; } }

        /* Private Fields */
        protected string itemName;
    }
}
