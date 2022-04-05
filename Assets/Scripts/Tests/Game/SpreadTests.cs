using System.Collections;
using System.Collections.Generic;
using System.Linq;
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
        Spread spread = new Spread(-1, 0);

        Assert.Zero(spread.Roll());
    }

    [Test]
    public void TestRollVariation()
    {
        int value = 10;
        int variation = 5;
        Spread spread = new Spread(value, variation);

        int attempts = 100;
        for (int i = 0; i < attempts; i++)
        {
            int roll = spread.Roll();
            Assert.IsTrue((value - variation) <= roll && roll <= (value + variation));
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

    [Test]
    public void TestGenerate()
    {
        int value = 15;

        int attempts = 100;
        for (int i = 0; i < attempts; i++)
        {
            Spread spread = Spread.Generate(value);
            Assert.IsTrue(Mathf.RoundToInt(value * 0.25f) <= spread.Variation && spread.Variation <= Mathf.RoundToInt(value * 0.5f));
        }
    }
}
