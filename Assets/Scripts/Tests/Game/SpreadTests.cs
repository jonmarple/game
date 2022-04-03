using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using Toast.Game;

public class SpreadTests
{
    [Test]
    public void TestRollValue()
    {
        int count = 4;
        for (int i = 0; i < count; i++)
            Assert.AreEqual(i, new Spread(i, 0).Roll());
    }

    [Test]
    public void TestRollBadValue()
    {
        Spread spreadneg = new Spread(-1, 0);
        Assert.Zero(spreadneg.Roll());
    }

    [Test]
    public void TestRollVariation()
    {
        Spread spread = new Spread(10, 5);
        int attempts = 100;
        for (int i = 0; i < attempts; i++)
        {
            int roll = spread.Roll();
            Assert.IsTrue(5 <= roll && roll <= 15);
        }
    }

    [Test]
    public void TestRollCrit()
    {
        Spread spread = new Spread(1, 0);
        Assert.AreEqual(1, spread.Roll(false));
        Assert.AreEqual(2, spread.Roll(true));
    }

    [Test]
    public void TestEmptySpread()
    {
        Spread spread = new Spread();
        Assert.Zero(spread.Value);
        Assert.Zero(spread.Variation);
    }
}
