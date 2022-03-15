using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using Toast.Game;
using Toast.Game.AI;
using Toast.Game.Characters;
using Toast.Game.Combat;
using Toast.Game.Stats;

public class CombatFlowTests
{
    [Test]
    public void TestFlow()
    {
        CombatFlow.Initialize(
            new CharacterGroup(new List<Character>(new Character[] { new Character("1", null, null, new StatBlock(1, 1, 1, 1, new Spread(2, 0)), null, new CharacterAI()), new Character("2", null, null, new StatBlock(1, 1, 1, 1, new Spread(3, 0)), null, new CharacterAI()) })),
            new CharacterGroup(new List<Character>(new Character[] { new Character("3", null, null, new StatBlock(1, 1, 1, 1, new Spread(1, 0)), null, new CharacterAI()), new Character("4", null, null, new StatBlock(1, 1, 1, 1, new Spread(2, 0)), null, new CharacterAI()) })));

        foreach (Character c in CombatFlow.Order)
            Debug.Log(c.CharacterName);

        for (int i = 0; i < 10; i++)
            CombatFlow.Step();

        Assert.IsTrue(true);
    }
}
