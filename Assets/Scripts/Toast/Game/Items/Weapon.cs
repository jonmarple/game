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
        public int Damage { get { return damage; } }
        public Action Primary { get { return primaryAction; } }
        public Action Secondary { get { return secondaryAction; } }

        /* Private Fields */
        private int damage;
        private Action primaryAction;
        private Action secondaryAction;

        public Weapon(string name, int damage, Action primary, Action secondary)
        {
            this.itemName = name;
            this.damage = damage;
            this.primaryAction = primary;
            this.secondaryAction = secondary;
        }
    }
}
