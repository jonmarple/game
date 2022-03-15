using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityAtoms.BaseAtoms;

namespace Toast.Game.Items
{
    /// <summary>
    /// Data container for item information.
    /// </summary>
    public abstract class ItemData : ScriptableObject
    {
        /* Serialized Fields */
        [SerializeField] protected StringReference itemName;
    }
}
