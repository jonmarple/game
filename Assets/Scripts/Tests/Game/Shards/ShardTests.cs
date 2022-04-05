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
        Shard shard = Shard.Generate(0);

        Assert.AreNotEqual(null, shard.Roll);
        Assert.AreEqual(shard, shard.Roll.Shard);
        Assert.IsTrue(shard is APShard ||
                        shard is AMShard ||
                        shard is DPShard ||
                        shard is DMShard ||
                        shard is MShard);
    }

    [Test]
    public void TestGenerateM()
    {
        int attempts = 100;
        for (int i = 0; i < attempts; i++)
        {
            MShard shard = MShard.Generate();

            Assert.IsTrue(2 <= shard.Spread.Value && shard.Spread.Value <= 3);
        }
    }

    [Test]
    public void TestGenerateAP()
    {
        int value = 10;
        APShard shard = APShard.Generate(value);

        Assert.AreEqual(value, shard.Spread.Value);
    }

    [Test]
    public void TestGenerateAM()
    {
        int value = 10;
        AMShard shard = AMShard.Generate(value);

        Assert.AreEqual(value, shard.Spread.Value);
    }

    [Test]
    public void TestGenerateDP()
    {
        int value = 10;
        DPShard shard = DPShard.Generate(value);

        Assert.AreEqual(value, shard.Spread.Value);
    }

    [Test]
    public void TestGenerateDM()
    {
        int value = 10;
        DMShard shard = DMShard.Generate(value);

        Assert.AreEqual(value, shard.Spread.Value);
    }
}
