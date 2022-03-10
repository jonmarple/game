using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Toast.Game.Skills;

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
        private WeaponSkillData skillPrimary;
        private WeaponSkillData skillSecondary;

        #region PUBLIC

        public Weapon(string name, int damage, WeaponSkillData skillPrimary, WeaponSkillData skillSecondary)
        {
            this.itemName = name;
            this.damage = damage;
            this.skillPrimary = skillPrimary;
            this.skillSecondary = skillSecondary;
        }

        #endregion

        #region PRIVATE
        #endregion
    }
}
