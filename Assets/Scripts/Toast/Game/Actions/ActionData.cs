using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityAtoms.BaseAtoms;

namespace Toast.Game.Actions
{
    /// <summary>
    /// Data container for action information.
    /// </summary>
    public abstract class ActionData<T> : ScriptableObject
    {
        /* Serialized Fields */
        [SerializeField] protected StringReference actionName;
        [SerializeField] protected IntReference cost;

        #region PUBLIC

        /// <summary> Generate Action object. </summary>
        public abstract T Generate();

        #endregion
    }
}
