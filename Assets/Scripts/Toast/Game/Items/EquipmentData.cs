using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Toast.Game.Items
{
    /// <summary>
    /// Data container for equipment information.
    /// </summary>
    [CreateAssetMenu(fileName = "Equipment Data", menuName = "Toast/Game/Items/Equipment Data")]
    public class EquipmentData : ScriptableObject
    {
        /* Public Fields */

        /* Serialized Fields */
        [SerializeField] private ArmorData armor;
        [SerializeField] private WeaponData weapon;

        /* Private Fields */

        #region PUBLIC

        /// <summary>
        /// Generate StatBlock object.
        /// </summary>
        public Equipment GenerateEquipment()
        {
            return new Equipment(armor.GenerateItem(), weapon.GenerateItem());
        }

        #endregion

        #region PRIVATE
        #endregion
    }
}
