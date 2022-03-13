using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using Toast.Game.Characters;
using Toast.Game.Combat;

public class CombatFlowTests
{
    [Test]
    public void TestFlow()
    {
        CombatFlow.Initialize(
            new CharacterGroup(new List<Character>(new Character[] { new Character("1", null, null, null, null), new Character("2", null, null, null, null) })),
            new CharacterGroup(new List<Character>(new Character[] { new Character("3", null, null, null, null), new Character("4", null, null, null, null) })));

        for (int i = 0; i < 10; i++)
            CombatFlow.Step();

        Assert.IsTrue(true);
    }
}
