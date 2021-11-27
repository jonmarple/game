using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Toast.Game.Items
{
    /// <summary>
    /// System-serializable armor information container.
    /// </summary>
    [System.Serializable]
    public class Armor : Item
    {
        /* Public Fields */
        public int Defense { get { return defense; } }

        /* Private Fields */
        private int defense;

        #region PUBLIC

        public Armor(string name, int defense)
        {
            this.itemName = name;
            this.defense = defense;
        }

        #endregion

        #region PRIVATE
        #endregion
    }
}
