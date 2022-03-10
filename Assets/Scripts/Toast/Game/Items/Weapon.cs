using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Toast.Game.Actions;

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
        private WeaponActionData actionPrimary;
        private WeaponActionData actionSecondary;

        #region PUBLIC

        public Weapon(string name, int damage, WeaponActionData actionPrimary, WeaponActionData actionSecondary)
        {
            this.itemName = name;
            this.damage = damage;
            this.actionPrimary = actionPrimary;
            this.actionSecondary = actionSecondary;
        }

        #endregion

        #region PRIVATE
        #endregion
    }
}
