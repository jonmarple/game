using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityAtoms.BaseAtoms;

namespace Toast.Game.Items
{
    /// <summary>
    /// Data container for armor information.
    /// </summary>
    [CreateAssetMenu(fileName = "Armor Data", menuName = "Toast/Game/Items/Armor Data")]
    public class ArmorData : ItemData<Armor>
    {
        /* Public Fields */

        /* Serialized Fields */
        [SerializeField] private IntReference defense;

        /* Private Fields */

        #region PUBLIC

        /// <summary> Generate Armor object. </summary>
        public override Armor GenerateItem()
        { return new Armor(itemName, defense); }

        #endregion

        #region PRIVATE
        #endregion
    }
}
