using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Toast.Game.Shards
{
    /// <summary>
    /// Shard container.
    /// </summary>
    public class ShardBag
    {
        /* Public Fields */
        public List<Shard> Bag { get; private set; }
        public List<Shard> Hand { get; private set; }
        public int HandSize { get; private set; }

        public ShardBag(List<Shard> shards, int handSize)
        {
            Bag = shards;
            Hand = new List<Shard>();
            HandSize = handSize;
            FillHand();
        }

        public ShardBag(int shardCount, int handSize, Spread targetValue)
        {
            Bag = GenerateShards(shardCount, targetValue);
            Hand = new List<Shard>();
            HandSize = handSize;
            FillHand();
        }

        #region PUBLIC

        public void FillHand()
        {
            while (Hand.Count < HandSize && Bag.Count > 0)
            {
                int index = Random.Range(0, Bag.Count);
                Shard shard = Bag[index];
                Bag.RemoveAt(index);
                Hand.Add(shard);
            }
        }

        public static List<Shard> GenerateShards(int shardCount, Spread targetValue)
        {
            List<Shard> shards = new List<Shard>();
            for (int i = 0; i < shardCount; i++)
                shards.Add(Shard.Generate(targetValue.Roll()));
            return shards;
        }

        #endregion
    }
}
