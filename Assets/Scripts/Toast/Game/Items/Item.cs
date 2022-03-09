using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Toast.Game.Items
{
    /// <summary>
    /// System-serializable item information container.
    /// </summary>
    [System.Serializable]
    public class Item
    {
        /* Public Fields */
        public string Name { get { return itemName; } }

        /* Private Fields */
        protected string itemName;

        #region PUBLIC
        #endregion

        #region PRIVATE
        #endregion
    }
}
