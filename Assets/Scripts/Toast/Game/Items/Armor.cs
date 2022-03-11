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
        public int Defense { get { return defense; } }

        /* Private Fields */
        private int defense;

        public Armor(string name, int defense)
        {
            this.itemName = name;
            this.defense = defense;
        }
    }
}
