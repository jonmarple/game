using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Toast.Game.Actions;

namespace Toast.Game.Items
{
    /// <summary>
    /// Weapon item.
    /// </summary>
    [System.Serializable]
    public class Weapon : Item
    {
        /* Public Fields */
        public int Damage { get; private set; }
        public Action Primary { get; private set; }
        public Action Secondary { get; private set; }

        public Weapon(string name, int damage, Action primary, Action secondary)
        {
            ItemName = name;
            Damage = damage;
            Primary = primary;
            Secondary = secondary;
        }
    }
}
