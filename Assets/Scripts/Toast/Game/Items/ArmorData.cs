using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Toast.Utility;

namespace Toast.Game.Items
{
    /// <summary>
    /// Data container for armor information.
    /// </summary>
    [CreateAssetMenu(fileName = "Armor", menuName = "Toast/Game/Items/Armor")]
    public class ArmorData : ItemData
    {
        /* Serialized Fields */
        [SerializeField] private int physical;
        [SerializeField] private int magical;

        #region PUBLIC

        public Armor Generate(int level)
        { return new Armor(itemName, Mathf.Clamp(Mathf.CeilToInt(Gaussian.Random(level - 2, level + 2)), 1, int.MaxValue), physical, magical); }

        #endregion
    }
}
