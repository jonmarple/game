using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityAtoms.BaseAtoms;

namespace Toast.Game.Actions
{
    /// <summary>
    /// Abstract data container for action information.
    /// </summary>
    public abstract class ActionData : ScriptableObject
    {
        /* Public Fields */
        public int Cost { get { return cost; } }

        /* Serialized Fields */
        [SerializeField] protected StringReference actionName;
        [SerializeField] protected IntReference cost;

        /* Private Fields */

        #region PUBLIC
        #endregion

        #region PRIVATE
        #endregion
    }
}
