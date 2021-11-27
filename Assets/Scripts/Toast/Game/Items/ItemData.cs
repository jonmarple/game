using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityAtoms.BaseAtoms;

namespace Toast.Game.Items
{
    /// <summary>
    /// Data container for item information.
    /// </summary>
    public abstract class ItemData<T> : ScriptableObject
    {
        /* Public Fields */

        /* Serialized Fields */
        [SerializeField] protected StringReference itemName;

        /* Private Fields */

        #region PUBLIC

        /// <summary>
        /// Generate Item object.
        /// </summary>
        public abstract T GenerateItem();

        #endregion

        #region PRIVATE
        #endregion
    }
}
