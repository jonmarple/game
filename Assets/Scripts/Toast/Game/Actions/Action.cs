using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Toast.Game.Actions
{
    /// <summary>
    /// Base action.
    /// </summary>
    public abstract class Action
    {
        /* Public Fields */
        public string ActionName { get; protected set; }
        public int Cost { get; protected set; }
    }
}
