using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityAtoms.BaseAtoms;

namespace Toast.Game.Actions
{
    /// <summary>
    /// Data container for action information.
    /// </summary>
    public abstract class ActionData : ScriptableObject
    {
        /* Serialized Fields */
        [SerializeField] protected StringReference actionName;
        [SerializeField] protected IntReference cost;
        [SerializeField] protected IntReference cooldown;

        #region PUBLIC

        /// <summary> Generate Action object. </summary>
        public abstract Action Generate();

        #endregion
    }
}
