using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Toast.Game.Actions
{
    /// <summary>
    /// Base action.
    /// </summary>
    [System.Serializable]
    public abstract class Action
    {
        /* Public Fields */
        public string ActionName { get { return actionName; } }
        public int Cost { get { return cost; } }

        /* Private Fields */
        protected string actionName;
        protected int cost;
    }
}
