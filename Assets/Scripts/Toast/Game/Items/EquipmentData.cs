using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityAtoms.BaseAtoms;
using Toast.Game.Shards;

namespace Toast.Game.Items
{
    /// <summary>
    /// Data container for equipment information.
    /// </summary>
    [CreateAssetMenu(fileName = "Equipment", menuName = "Toast/Game/Items/Equipment")]
    public class EquipmentData : ScriptableObject, IData<Equipment>
    {
        /* Serialized Fields */
        [SerializeField] private ArmorData armor;
        [SerializeField] private WeaponData weapon;
        [SerializeField] private IntReference shardCount;
        [SerializeField] private IntReference shardHandSize;

        #region PUBLIC

        public Equipment Generate()
        { return new Equipment(armor.Generate(), weapon.Generate(), new ShardBag(shardCount, shardHandSize)); }

        #endregion
    }
}
