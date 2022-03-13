using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Toast.Game.Items
{
    /// <summary>
    /// Equipment container.
    /// </summary>
    public class Equipment
    {
        /* Public Fields */
        public Armor Armor { get; private set; }
        public Weapon Weapon { get; private set; }

        public Equipment(Armor armor, Weapon weapon)
        {
            Armor = armor;
            Weapon = weapon;
        }
    }
}
