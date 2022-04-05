using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using Toast.Game.Actions;
using Toast.Game.Shards;

public class ActionTests
{
    [Test]
    public void TestAction()
    {
        Action action = new Attack("Test Action", 1, 2, 3);

        Assert.AreEqual("Test Action", action.ActionName);
        Assert.AreEqual(1, action.Cost);
        Assert.AreEqual(2, action.Cooldown);
        Assert.AreEqual(0, action.CooldownCounter);
    }

    [Test]
    public void TestAttack()
    {
        Attack attack = new Attack("Test Attack", 1, 0, 2);

        Assert.AreEqual(2, attack.Modifier);
    }

    [Test]
    public void TestRegen()
    {
        Regen regen = new Regen("Test Regen", 1, 0, 2);

        Assert.AreEqual(2, regen.Modifier);
    }

    [Test]
    public void TestMovement()
    {
        Movement movement = new Movement("Test Movement", 1, 0, MovementType.FOUR);

        Assert.AreEqual(MovementType.FOUR, movement.Type);
    }

    [Test]
    public void TestRoll()
    {
        MShard mShard = MShard.Generate();
        Roll roll = new Roll("Test Roll", 1, mShard);

        Assert.AreEqual(mShard, roll.Shard);
    }

    [Test]
    public void TestCooldown()
    {
        Action action = new Attack("Test Action", 1, 2, 3);

        Assert.Zero(action.CooldownCounter);
        Assert.IsTrue(action.CanPerform());

        action.Perform();

        Assert.AreEqual(2, action.CooldownCounter);
        Assert.IsFalse(action.CanPerform());

        action.Turn();

        Assert.AreEqual(1, action.CooldownCounter);
        Assert.IsFalse(action.CanPerform());

        action.Perform();

        Assert.AreEqual(1, action.CooldownCounter);
        Assert.IsFalse(action.CanPerform());

        action.Turn();

        Assert.Zero(action.CooldownCounter);
        Assert.IsTrue(action.CanPerform());

        action.Turn();

        Assert.Zero(action.CooldownCounter);
        Assert.IsTrue(action.CanPerform());
    }

    [Test]
    public void TestZeroCooldown()
    {
        Action action = new Attack("Test Action", 1, 0, 3);

        Assert.Zero(action.CooldownCounter);
        Assert.IsTrue(action.CanPerform());

        action.Perform();

        Assert.Zero(action.CooldownCounter);
        Assert.IsTrue(action.CanPerform());

        action.Turn();

        Assert.Zero(action.CooldownCounter);
        Assert.IsTrue(action.CanPerform());
    }
}
