using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Toast.Game.Items
{
    /// <summary>
    /// Data container for equipment information.
    /// </summary>
    [CreateAssetMenu(fileName = "Equipment", menuName = "Toast/Game/Items/Equipment")]
    public class EquipmentData : ScriptableObject
    {
        /* Serialized Fields */
        [SerializeField] private ArmorData armor;
        [SerializeField] private WeaponData weapon;

        #region PUBLIC

        /// <summary> Generate Equipment object. </summary>
        public Equipment Generate()
        { return new Equipment(armor.Generate(), weapon.Generate()); }

        #endregion
    }
}
