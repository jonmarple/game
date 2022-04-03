using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using Toast.Game;
using Toast.Game.Shards;

public class ShardBufferTests
{
    [Test]
    public void TestShardBuffer()
    {
        ShardBuffer buffer = new ShardBuffer();

        Assert.Zero(buffer.APBuffer);
        Assert.Zero(buffer.AMBuffer);
        Assert.Zero(buffer.DPBuffer);
        Assert.Zero(buffer.DMBuffer);
        Assert.AreEqual(1, buffer.MBuffer);
    }

    [Test]
    public void TestReset()
    {
        ShardBuffer buffer = new ShardBuffer();
        buffer.SetAttackBuffer(true, 5);
        buffer.SetAttackBuffer(false, 6);
        buffer.SetDefendBuffer(true, 7);
        buffer.SetDefendBuffer(false, 8);

        Assert.AreEqual(5, buffer.APBuffer);
        Assert.AreEqual(6, buffer.AMBuffer);
        Assert.AreEqual(7, buffer.DPBuffer);
        Assert.AreEqual(8, buffer.DMBuffer);
        Assert.AreEqual(1, buffer.MBuffer);

        buffer.Reset();

        Assert.Zero(buffer.APBuffer);
        Assert.Zero(buffer.AMBuffer);
        Assert.Zero(buffer.DPBuffer);
        Assert.Zero(buffer.DMBuffer);
        Assert.AreEqual(1, buffer.MBuffer);
    }

    [Test]
    public void TestGetAttackBuffer()
    {
        ShardBuffer buffer = new ShardBuffer();
        buffer.SetAttackBuffer(true, 5);
        buffer.SetAttackBuffer(false, 6);

        Assert.AreEqual(5, buffer.GetAttackBuffer(true));
        Assert.AreEqual(6, buffer.GetAttackBuffer(false));
    }

    [Test]
    public void TestGetDefendBuffer()
    {
        ShardBuffer buffer = new ShardBuffer();
        buffer.SetDefendBuffer(true, 7);
        buffer.SetDefendBuffer(false, 8);

        Assert.AreEqual(7, buffer.GetDefendBuffer(true));
        Assert.AreEqual(8, buffer.GetDefendBuffer(false));
    }

    [Test]
    public void TestSetAttackBuffer()
    {
        ShardBuffer buffer = new ShardBuffer();
        buffer.SetAttackBuffer(true, 5);
        buffer.SetAttackBuffer(false, 6);

        Assert.AreEqual(5, buffer.APBuffer);
        Assert.AreEqual(6, buffer.AMBuffer);

        buffer.SetAttackBuffer(true, -5);
        buffer.SetAttackBuffer(false, -6);

        Assert.AreEqual(-5, buffer.APBuffer);
        Assert.AreEqual(-6, buffer.AMBuffer);
    }

    [Test]
    public void TestSetDefendBuffer()
    {
        ShardBuffer buffer = new ShardBuffer();
        buffer.SetDefendBuffer(true, 7);
        buffer.SetDefendBuffer(false, 8);

        Assert.AreEqual(7, buffer.DPBuffer);
        Assert.AreEqual(8, buffer.DMBuffer);

        buffer.SetDefendBuffer(true, -7);
        buffer.SetDefendBuffer(false, -8);

        Assert.AreEqual(-7, buffer.DPBuffer);
        Assert.AreEqual(-8, buffer.DMBuffer);
    }

    [Test]
    public void TestAddRoll()
    {
        ShardBuffer buffer = new ShardBuffer();
        APShard apShard = new APShard(new Spread(5, 0));
        AMShard amShard = new AMShard(new Spread(6, 0));
        DPShard dpShard = new DPShard(new Spread(7, 0));
        DMShard dmShard = new DMShard(new Spread(8, 0));
        MShard mShard = new MShard(new Spread(2, 0));

        Assert.Zero(buffer.APBuffer);
        Assert.Zero(buffer.AMBuffer);
        Assert.Zero(buffer.DPBuffer);
        Assert.Zero(buffer.DMBuffer);
        Assert.AreEqual(1, buffer.MBuffer);

        buffer.AddRoll(apShard);
        buffer.AddRoll(amShard);
        buffer.AddRoll(dpShard);
        buffer.AddRoll(dmShard);
        buffer.AddRoll(mShard);

        Assert.AreEqual(5, buffer.APBuffer);
        Assert.AreEqual(6, buffer.AMBuffer);
        Assert.AreEqual(7, buffer.DPBuffer);
        Assert.AreEqual(8, buffer.DMBuffer);
        Assert.AreEqual(2, buffer.MBuffer);
    }
}
