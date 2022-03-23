using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Toast.Game.Shards;

namespace Toast.Game.Items
{
    /// <summary>
    /// Equipment container.
    /// </summary>
    public class Equipment
    {
        /* Public Fields */
        public Armor Armor { get; private set; }
        public Weapon Weapon { get; private set; }
        public List<Shard> Shards { get; private set; }

        public Equipment(Armor armor, Weapon weapon, List<Shard> shards)
        {
            Armor = armor;
            Weapon = weapon;
            Shards = shards == null ? new List<Shard>() : shards;
        }
    }
}
