using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using Toast.Game.Actions;
using Toast.Game.Characters;
using Toast.Game.Items;
using Toast.Game.Stats;

public class CControllerTests
{
    [Test]
    public void TestGeneralFlow()
    {
        Character source = new Character("Source Char", null, null, new StatBlock(0, 0, 10, 10), new Equipment(null, new Weapon("", 3)));
        Character target = new Character("Target Char", null, null, new StatBlock(10, 10, 0, 0, 10), new Equipment(new Armor("", 1), null));
        Attack attack = new Attack("Test Attack", 1, 2);

        Assert.AreEqual(10, source.Stats.AP);
        Assert.AreEqual(10, target.Stats.HP);
        Assert.AreEqual(10, target.Stats.Shield);

        source.PerformAction(attack, target);

        Assert.AreEqual(9, source.Stats.AP);
        Assert.AreEqual(10, target.Stats.HP);
        Assert.AreEqual(5, target.Stats.Shield);

        source.PerformAction(attack, target);

        Assert.AreEqual(8, source.Stats.AP);
        Assert.AreEqual(10, target.Stats.HP);
        Assert.AreEqual(0, target.Stats.Shield);

        source.PerformAction(attack, target);

        Assert.AreEqual(7, source.Stats.AP);
        Assert.AreEqual(5, target.Stats.HP);
        Assert.AreEqual(0, target.Stats.Shield);

        source.PerformAction(attack, target);

        Assert.AreEqual(6, source.Stats.AP);
        Assert.AreEqual(0, target.Stats.HP);
        Assert.AreEqual(0, target.Stats.Shield);

        source.PerformAction(attack, target);

        Assert.AreEqual(5, source.Stats.AP);
        Assert.AreEqual(0, target.Stats.HP);
        Assert.AreEqual(0, target.Stats.Shield);
    }

    [Test]
    public void TestCanPerformAction()
    {
        Assert.IsTrue(true);
    }

    [Test]
    public void TestPerformAction()
    {
        Assert.IsTrue(true);
    }

    [Test]
    public void TestApplyDamage()
    {
        Assert.IsTrue(true);
    }

    [Test]
    public void TestApplyRegen()
    {
        Assert.IsTrue(true);
    }

    [Test]
    public void TestApplyShield()
    {
        Assert.IsTrue(true);
    }
}
