using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Toast.Game.Items
{
    /// <summary>
    /// System-serializable weapon information container.
    /// </summary>
    [System.Serializable]
    public class Weapon : Item
    {
        /* Public Fields */
        public int Damage { get { return damage; } }

        /* Private Fields */
        private int damage;

        #region PUBLIC

        public Weapon(string name, int damage)
        {
            this.itemName = name;
            this.damage = damage;
        }

        #endregion

        #region PRIVATE
        #endregion
    }
}
