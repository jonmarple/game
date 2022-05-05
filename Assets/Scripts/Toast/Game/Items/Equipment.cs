using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Toast.Game.Shards;

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
        public ShardBag Shards { get; private set; }
        public float AvgLvl { get { return (Armor.Level + Weapon.Level) / 2f; } }

        /* Value Update Delegate/Event */
        public delegate void Updated();
        public event Updated EquipmentUpdated;

        public Equipment(Armor armor, Weapon weapon, ShardBag shards)
        {
            Armor = armor;
            Weapon = weapon;
            Shards = shards;
        }

        #region PUBLIC

        /// <summary> Set armor equipment. </summary>
        public void SetArmor(Armor armor)
        {
            Armor = armor;
            EquipmentUpdated?.Invoke();
        }

        /// <summary> Set weapon equipment. </summary>
        public void SetWeapon(Weapon weapon)
        {
            Weapon = weapon;
            EquipmentUpdated?.Invoke();
        }

        #endregion
    }
}
