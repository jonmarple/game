using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Toast.Game.Items
{
    /// <summary>
    /// Equipment container.
    /// </summary>
    [System.Serializable]
    public class Equipment
    {
        /* Public Fields */
        public Armor Armor { get { return armor; } }
        public Weapon Weapon { get { return weapon; } }

        /* Private Fields */
        private Armor armor;
        private Weapon weapon;

        public Equipment(Armor armor, Weapon weapon)
        {
            this.armor = armor;
            this.weapon = weapon;
        }
    }
}
