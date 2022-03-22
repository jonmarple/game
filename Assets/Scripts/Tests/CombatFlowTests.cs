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
            new CharacterGroup(new List<Character>(new Character[] { new Character("a1", null, null, new StatBlock(10, 10, 2, 5, 2, new Spread(5, 2)), new Equipment(new Armor("", new Spread(2, 1), new Spread(2, 1)), new Weapon("", new Spread(4, 1), new Spread(0, 0), new Attack("att1", 1, 1), new Attack("att2", 2, 2))), new CharacterAI()),
                                                                     new Character("a2", null, null, new StatBlock(10, 10, 2, 5, 2, new Spread(5, 2)), new Equipment(new Armor("", new Spread(2, 1), new Spread(2, 1)), new Weapon("", new Spread(4, 1), new Spread(0, 0), new Attack("att1", 1, 1), new Attack("att2", 2, 2))), new CharacterAI()),
                                                                     new Character("a3", null, null, new StatBlock(10, 10, 2, 5, 2, new Spread(5, 2)), new Equipment(new Armor("", new Spread(2, 1), new Spread(2, 1)), new Weapon("", new Spread(0, 0), new Spread(3, 1), new Attack("att1", 1, 1), new Regen("reg1", 2, 1))), new CharacterAI()),
                                                                     new Character("a4", null, null, new StatBlock(10, 10, 2, 5, 2, new Spread(5, 2)), new Equipment(new Armor("", new Spread(2, 1), new Spread(2, 1)), new Weapon("", new Spread(0, 0), new Spread(3, 1), new Attack("att1", 1, 1), new Regen("reg2", 2, 1))), new CharacterAI()) })),
            new CharacterGroup(new List<Character>(new Character[] { new Character("e1", null, null, new StatBlock(10, 10, 2, 5, 2, new Spread(5, 2)), new Equipment(new Armor("", new Spread(2, 1), new Spread(2, 1)), new Weapon("", new Spread(4, 1), new Spread(0, 0), new Attack("att1", 1, 1), new Attack("att2", 2, 2))), new CharacterAI()),
                                                                     new Character("e2", null, null, new StatBlock(10, 10, 2, 5, 2, new Spread(5, 2)), new Equipment(new Armor("", new Spread(2, 1), new Spread(2, 1)), new Weapon("", new Spread(4, 1), new Spread(0, 0), new Attack("att1", 1, 1), new Attack("att2", 2, 2))), new CharacterAI()),
                                                                     new Character("e3", null, null, new StatBlock(10, 10, 2, 5, 2, new Spread(5, 2)), new Equipment(new Armor("", new Spread(2, 1), new Spread(2, 1)), new Weapon("", new Spread(0, 0), new Spread(3, 1), new Attack("att1", 1, 1), new Attack("att2", 2, 2))), new CharacterAI()),
                                                                     new Character("e4", null, null, new StatBlock(10, 10, 2, 5, 2, new Spread(5, 2)), new Equipment(new Armor("", new Spread(2, 1), new Spread(2, 1)), new Weapon("", new Spread(0, 0), new Spread(3, 1), new Attack("att1", 1, 1), new Attack("att2", 2, 2))), new CharacterAI()) })));

        while (!CombatFlow.Finished)
            CombatFlow.Step();

        Debug.Log(CombatFlow.Active);
        Debug.Log(CombatFlow.Finished);
        Debug.Log(CombatFlow.GroupA.Active);
        Debug.Log(CombatFlow.GroupB.Active);

        Assert.IsTrue(true);
    }
}
