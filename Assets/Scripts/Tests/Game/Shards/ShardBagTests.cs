using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using Toast.Game;
using Toast.Game.Shards;

public class ShardBagTests
{
    [Test]
    public void TestShardBag()
    {
        ShardBag shards = new ShardBag(30, 5, Spread.Generate(10));

        Assert.AreEqual(5, shards.HandSize);
        Assert.AreEqual(5, shards.Hand.Count);
        Assert.AreEqual(25, shards.Bag.Count);

        shards = new ShardBag(new List<Shard>() { Shard.Generate(10), Shard.Generate(10), Shard.Generate(10) }, 1);

        Assert.AreEqual(1, shards.HandSize);
        Assert.AreEqual(1, shards.Hand.Count);
        Assert.AreEqual(2, shards.Bag.Count);
    }

    [Test]
    public void TestFillHand()
    {
        ShardBag shards = new ShardBag(30, 5, Spread.Generate(10));
        shards.Hand.RemoveAt(0);
        shards.Hand.RemoveAt(0);

        Assert.AreEqual(3, shards.Hand.Count);

        shards.FillHand();

        Assert.AreEqual(5, shards.Hand.Count);
    }

    [Test]
    public void TestGenerateShards()
    {
        List<Shard> shards = ShardBag.GenerateShards(5, Spread.Generate(10));

        Assert.AreEqual(5, shards.Count);
    }
}
