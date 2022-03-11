using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityAtoms.BaseAtoms;

namespace Toast.Game.Items
{
    /// <summary>
    /// Data container for weapon information.
    /// </summary>
    [CreateAssetMenu(fileName = "Weapon", menuName = "Toast/Game/Items/Weapon")]
    public class WeaponData : ItemData<Weapon>
    {
        /* Serialized Fields */
        [SerializeField] private IntReference damage;

        #region PUBLIC

        public override Weapon Generate()
        { return new Weapon(itemName, damage); }

        #endregion
    }
}
