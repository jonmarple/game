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
        [SerializeField] private IntReference shardListSize;

        #region PUBLIC

        public Equipment Generate()
        { return new Equipment(armor.Generate(), weapon.Generate(), GenerateShards()); }

        #endregion

        #region PRIVATE

        private List<Shard> GenerateShards()
        {
            List<Shard> shards = new List<Shard>();
            for (int i = 0; i < Mathf.Clamp(shardListSize, 0, int.MaxValue); i++)
                shards.Add(Shard.Generate());
            return shards;
        }

        #endregion
    }
}
