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

        //Dictionary<int, int> counts = new Dictionary<int, int>();
        //for (int i = spread.Value - spread.Variation; i <= spread.Value + spread.Variation; i++)
        //    counts.Add(i, 0);

        int attempts = 100;
        for (int i = 0; i < attempts; i++)
        {
            int roll = spread.Roll();
            //counts[roll]++;
            Assert.IsTrue((value - variation) <= roll && roll <= (value + variation));
        }

        //foreach (KeyValuePair<int, int> kv in counts)
        //    Debug.Log(kv.Key + "\t" + Mathf.RoundToInt(((float)kv.Value / attempts) * 100) + "\t" + kv.Value);
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

        //Dictionary<int, int> counts = new Dictionary<int, int>();

        int attempts = 100;
        for (int i = 0; i < attempts; i++)
        {
            Spread spread = Spread.Generate(value);
            //if (!counts.ContainsKey(spread.Variation))
            //    counts.Add(spread.Variation, 0);
            //counts[spread.Variation]++;
            Assert.IsTrue(Mathf.RoundToInt(value * 0.25f) <= spread.Variation && spread.Variation <= Mathf.RoundToInt(value * 0.5f));
        }

        //foreach (KeyValuePair<int, int> kv in counts.OrderBy(x => x.Key))
        //    Debug.Log(kv.Key + "\t" + Mathf.RoundToInt(((float)kv.Value / attempts) * 100) + "\t" + kv.Value);
    }
}
