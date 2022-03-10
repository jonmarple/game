using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityAtoms.BaseAtoms;
using Toast.Game.Actions;

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
        [SerializeField] private WeaponActionData actionPrimary;
        [SerializeField] private WeaponActionData actionSecondary;

        /* Private Fields */

        #region PUBLIC

        /// <summary> Generate Weapon object. </summary>
        public override Weapon GenerateItem()
        { return new Weapon(itemName, damage, actionPrimary, actionSecondary); }

        #endregion

        #region PRIVATE
        #endregion
    }
}
