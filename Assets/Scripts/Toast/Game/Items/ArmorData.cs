using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Toast.Game.Items
{
    /// <summary>
    /// Data container for armor information.
    /// </summary>
    [CreateAssetMenu(fileName = "Armor", menuName = "Toast/Game/Items/Armor")]
    public class ArmorData : ItemData<Armor>
    {
        /* Serialized Fields */
        [SerializeField] private Spread physical;
        [SerializeField] private Spread magical;

        #region PUBLIC

        public override Armor Generate()
        { return new Armor(itemName, physical, magical); }

        #endregion
    }
}
