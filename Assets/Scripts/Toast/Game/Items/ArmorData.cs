using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Toast.Game.Items
{
    /// <summary>
    /// Data container for armor information.
    /// </summary>
    [CreateAssetMenu(fileName = "Armor", menuName = "Toast/Game/Items/Armor")]
    public class ArmorData : ItemData, IData<Armor>
    {
        /* Serialized Fields */
        [SerializeField] private int physical;
        [SerializeField] private int magical;

        #region PUBLIC

        public Armor Generate()
        { return new Armor(itemName, physical, magical); }

        #endregion
    }
}
