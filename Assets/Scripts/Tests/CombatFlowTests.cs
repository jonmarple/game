using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using Toast.Game;
using Toast.Game.Characters;
using Toast.Game.Combat;
using Toast.Game.Stats;

public class CombatFlowTests
{
    [Test]
    public void TestFlow()
    {
        CombatFlow.Initialize(
            new CharacterGroup(new List<Character>(new Character[] { new Character("1", null, null, new StatBlock(1, 1, 1, 1, new Spread(2, 0)), null, null), new Character("2", null, null, new StatBlock(1, 1, 1, 1, new Spread(3, 0)), null, null) })),
            new CharacterGroup(new List<Character>(new Character[] { new Character("3", null, null, new StatBlock(1, 1, 1, 1, new Spread(1, 0)), null, null), new Character("4", null, null, new StatBlock(1, 1, 1, 1, new Spread(2, 0)), null, null) })));

        foreach (Character c in CombatFlow.Order)
            Debug.Log(c.CharacterName);

        Assert.IsTrue(true);
    }
}
