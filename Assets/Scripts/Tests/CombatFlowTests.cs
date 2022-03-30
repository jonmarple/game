using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using Toast.Game;
using Toast.Game.AI;
using Toast.Game.Actions;
using Toast.Game.Characters;
using Toast.Game.Items;
using Toast.Game.Combat;
using Toast.Game.Stats;

public class CombatFlowTests
{
    [Test]
    public void TestFlow()
    {
        CombatFlow.Initialize(
            new CharacterGroup(new List<Character>(new Character[] { new Character("a1", null, new StatBlock(10, 10, 0, 4, 2, 10, new Spread(5, 2), ModifierLevel.NONE, ModifierLevel.NONE), new Equipment(new Armor("", 10, 5), new Weapon("", new Spread(4, 1), new Spread(0, 0), new Attack("att1", 1, 1), new Attack("att2", 2, 2)), null), new CharacterAI()),
                                                                     new Character("a2", null, new StatBlock(10, 10, 0, 4, 2, 10, new Spread(5, 2), ModifierLevel.NONE, ModifierLevel.NONE), new Equipment(new Armor("", 10, 5), new Weapon("", new Spread(0, 0), new Spread(3, 1), new Attack("att1", 1, 1), new Regen("reg1", 1, 1)), null), new CharacterAI()) })),
            new CharacterGroup(new List<Character>(new Character[] { new Character("e1", null, new StatBlock(10, 10, 0, 4, 2, 10, new Spread(5, 2), ModifierLevel.NONE, ModifierLevel.NONE), new Equipment(new Armor("", 10, 5), new Weapon("", new Spread(4, 1), new Spread(0, 0), new Attack("att1", 1, 1), new Attack("att2", 2, 2)), null), new CharacterAI()),
                                                                     new Character("e2", null, new StatBlock(10, 10, 0, 4, 2, 10, new Spread(5, 2), ModifierLevel.NONE, ModifierLevel.NONE), new Equipment(new Armor("", 10, 5), new Weapon("", new Spread(0, 0), new Spread(3, 1), new Attack("att1", 1, 1), new Attack("att2", 2, 2)), null), new CharacterAI()) })));

        int i = 0;
        while (!CombatFlow.Finished && i++ < 100)
            CombatFlow.Step();

        Debug.Log(CombatFlow.Active);
        Debug.Log(CombatFlow.Finished);
        Debug.Log(CombatFlow.GroupA.Active);
        Debug.Log(CombatFlow.GroupB.Active);

        Assert.IsTrue(true);
    }
}
