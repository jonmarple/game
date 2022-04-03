using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using Toast.Game;
using Toast.Game.Combat;
using Toast.Game.Stats;

public class StatBlockTests
{
    [Test]
    public void TestStatBlock()
    {
        StatBlock stats = new StatBlock(10, 10, 10, 10, 5, 10, new Spread(), ModifierLevel.RESISTANT, ModifierLevel.WEAK);

        Assert.AreEqual(10, stats.HP);
        Assert.AreEqual(10, stats.HPMax);
        Assert.AreEqual(10, stats.AP);
        Assert.AreEqual(10, stats.APMax);
        Assert.AreEqual(5, stats.APRegen);
        Assert.AreEqual(10, stats.Crit);
        Assert.AreEqual(0, stats.Initiative.Value);
        Assert.AreEqual(0, stats.Initiative.Variation);
        Assert.AreEqual(ModifierLevel.RESISTANT, stats.PhysicalMod);
        Assert.AreEqual(ModifierLevel.WEAK, stats.MagicalMod);
    }

    [Test]
    public void TestSetHP()
    {
        StatBlock stats = new StatBlock(10, 10, 10, 10, 5, 10, new Spread(), ModifierLevel.RESISTANT, ModifierLevel.WEAK);

        Assert.AreEqual(10, stats.HP);

        stats.SetHP(5);
        Assert.AreEqual(5, stats.HP);

        stats.SetHP(-5);
        Assert.AreEqual(0, stats.HP);

        stats.SetHP(15);
        Assert.AreEqual(10, stats.HP);
    }

    [Test]
    public void TestAlterHP()
    {
        StatBlock stats = new StatBlock(10, 10, 10, 10, 5, 10, new Spread(), ModifierLevel.RESISTANT, ModifierLevel.WEAK);

        Assert.AreEqual(10, stats.HP);

        stats.AlterHP(-5);
        Assert.AreEqual(5, stats.HP);

        stats.AlterHP(-10);
        Assert.AreEqual(0, stats.HP);

        stats.AlterHP(15);
        Assert.AreEqual(10, stats.HP);
    }

    [Test]
    public void TestSetAP()
    {
        StatBlock stats = new StatBlock(10, 10, 10, 10, 5, 10, new Spread(), ModifierLevel.RESISTANT, ModifierLevel.WEAK);

        Assert.AreEqual(10, stats.AP);

        stats.SetAP(5);
        Assert.AreEqual(5, stats.AP);

        stats.SetAP(-5);
        Assert.AreEqual(0, stats.AP);

        stats.SetAP(15);
        Assert.AreEqual(10, stats.AP);
    }

    [Test]
    public void TestAlterAP()
    {
        StatBlock stats = new StatBlock(10, 10, 10, 10, 5, 10, new Spread(), ModifierLevel.RESISTANT, ModifierLevel.WEAK);

        Assert.AreEqual(10, stats.AP);

        stats.AlterAP(-5);
        Assert.AreEqual(5, stats.AP);

        stats.AlterAP(-10);
        Assert.AreEqual(0, stats.AP);

        stats.AlterAP(15);
        Assert.AreEqual(10, stats.AP);
    }

    [Test]
    public void TestRollCrit()
    {
        StatBlock statsHighCrit = new StatBlock(10, 10, 10, 10, 5, 100, new Spread(), ModifierLevel.RESISTANT, ModifierLevel.WEAK);
        StatBlock statsLowCrit = new StatBlock(10, 10, 10, 10, 5, 0, new Spread(), ModifierLevel.RESISTANT, ModifierLevel.WEAK);

        Assert.IsTrue(statsHighCrit.RollCrit());
        Assert.IsFalse(statsLowCrit.RollCrit());
    }
}
