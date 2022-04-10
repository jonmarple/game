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
    public void TestInit()
    {
        CharacterGroup a = new CharacterGroup(Faction.A, new List<Character>() { Factory.GenerateCharacter(), Factory.GenerateCharacter(), Factory.GenerateCharacter() });
        CharacterGroup b = new CharacterGroup(Faction.B, new List<Character>() { Factory.GenerateCharacter() });

        CombatFlow.Reset();

        Assert.IsFalse(CombatFlow.Active);
        Assert.IsFalse(CombatFlow.Finished);
        Assert.AreEqual(null, CombatFlow.GroupA);
        Assert.AreEqual(null, CombatFlow.GroupB);
        Assert.AreEqual(null, CombatFlow.Order);

        CombatFlow.Start(a, b);

        Assert.IsTrue(CombatFlow.Active);
        Assert.IsFalse(CombatFlow.Finished);
        Assert.AreEqual(a, CombatFlow.GroupA);
        Assert.AreEqual(b, CombatFlow.GroupB);
    }

    [Test]
    public void TestFlow()
    {
        Character a1 = Factory.GenerateCharacter(initiativeValue: 1, initiativeVariation: 0);
        Character a2 = Factory.GenerateCharacter(initiativeValue: 3, initiativeVariation: 0);
        Character a3 = Factory.GenerateCharacter(initiativeValue: 2, initiativeVariation: 0);
        Character b1 = Factory.GenerateCharacter(initiativeValue: 4, initiativeVariation: 0);

        CharacterGroup a = new CharacterGroup(Faction.A, new List<Character>() { a1, a2, a3 });
        CharacterGroup b = new CharacterGroup(Faction.B, new List<Character>() { b1 });

        CombatFlow.Reset();
        CombatFlow.Start(a, b);

        Assert.AreEqual(b1, CombatFlow.CurrentCharacter);
        CombatFlow.FinishTurn();
        Assert.AreEqual(a2, CombatFlow.CurrentCharacter);
        CombatFlow.FinishTurn();
        Assert.AreEqual(a3, CombatFlow.CurrentCharacter);
        CombatFlow.FinishTurn();
        Assert.AreEqual(a1, CombatFlow.CurrentCharacter);
        CombatFlow.FinishTurn();
        Assert.AreEqual(b1, CombatFlow.CurrentCharacter);
    }

    [Test]
    public void TestDeadSkip()
    {
        Character a1 = Factory.GenerateCharacter(initiativeValue: 4, initiativeVariation: 0);
        Character a2 = Factory.GenerateCharacter(initiativeValue: 3, initiativeVariation: 0, hp: 0);
        Character a3 = Factory.GenerateCharacter(initiativeValue: 2, initiativeVariation: 0);
        Character b1 = Factory.GenerateCharacter(initiativeValue: 1, initiativeVariation: 0);

        CharacterGroup a = new CharacterGroup(Faction.A, new List<Character>() { a1, a2, a3 });
        CharacterGroup b = new CharacterGroup(Faction.B, new List<Character>() { b1 });

        CombatFlow.Reset();
        CombatFlow.Start(a, b);

        Assert.AreEqual(a1, CombatFlow.CurrentCharacter);
        CombatFlow.FinishTurn();
        Assert.AreEqual(a3, CombatFlow.CurrentCharacter);
    }
}
