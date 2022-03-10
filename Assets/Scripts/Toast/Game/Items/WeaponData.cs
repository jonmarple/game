using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityAtoms.BaseAtoms;
using Toast.Game.Skills;

namespace Toast.Game.Items
{
    /// <summary>
    /// Data container for weapon information.
    /// </summary>
    [CreateAssetMenu(fileName = "Weapon", menuName = "Toast/Game/Items/Weapon")]
    public class WeaponData : ItemData<Weapon>
    {
        /* Public Fields */

        /* Serialized Fields */
        [SerializeField] private IntReference damage;
        [SerializeField] private WeaponSkillData skillPrimary;
        [SerializeField] private WeaponSkillData skillSecondary;

        /* Private Fields */

        #region PUBLIC

        /// <summary> Generate Weapon object. </summary>
        public override Weapon GenerateItem()
        { return new Weapon(itemName, damage, skillPrimary, skillSecondary); }

        #endregion

        #region PRIVATE
        #endregion
    }
}
