using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using Toast.Game;
using Toast.Game.Shards;

public class ShardTests
{
    [Test]
    public void TestGenerate()
    {
        Shard shard = Shard.Generate();

        Assert.AreNotEqual(null, shard.Roll);
        Assert.AreEqual(shard, shard.Roll.Shard);
        Assert.IsTrue(shard is APShard ||
                        shard is AMShard ||
                        shard is DPShard ||
                        shard is DMShard ||
                        shard is MShard);
    }
}
