using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Toast.Game.Items
{
    /// <summary>
    /// Armor item.
    /// </summary>
    [System.Serializable]
    public class Armor : Item
    {
        /* Public Fields */
        public int Defense { get; private set; }

        public Armor(string name, int defense)
        {
            ItemName = name;
            Defense = defense;
        }
    }
}
