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
        CharacterGroup a = new CharacterGroup(new List<Character>() { Factory.GenerateCharacter(), Factory.GenerateCharacter(), Factory.GenerateCharacter() });
        CharacterGroup b = new CharacterGroup(new List<Character>() { Factory.GenerateCharacter() });

        CombatFlow.Reset();
        CombatFlow.Initialize(a, b);

        CombatFlow.Step();
        Assert.AreEqual(0, CombatFlow.Index);
        Assert.AreEqual(CombatFlow.Order[CombatFlow.Index], CombatFlow.CurrentCharacter);
        CombatFlow.Step();
        Assert.AreEqual(1, CombatFlow.Index);
        Assert.AreEqual(CombatFlow.Order[CombatFlow.Index], CombatFlow.CurrentCharacter);
        CombatFlow.Step();
        Assert.AreEqual(2, CombatFlow.Index);
        Assert.AreEqual(CombatFlow.Order[CombatFlow.Index], CombatFlow.CurrentCharacter);
        CombatFlow.Step();
        Assert.AreEqual(3, CombatFlow.Index);
        Assert.AreEqual(CombatFlow.Order[CombatFlow.Index], CombatFlow.CurrentCharacter);
        CombatFlow.Step();
        Assert.AreEqual(4, CombatFlow.Index);
        CombatFlow.Step();
        Assert.AreEqual(0, CombatFlow.Index);
        Assert.AreEqual(CombatFlow.Order[CombatFlow.Index], CombatFlow.CurrentCharacter);
    }

    [Test]
    public void TestInit()
    {
        CharacterGroup a = new CharacterGroup(new List<Character>() { Factory.GenerateCharacter(), Factory.GenerateCharacter(), Factory.GenerateCharacter() });
        CharacterGroup b = new CharacterGroup(new List<Character>() { Factory.GenerateCharacter() });

        CombatFlow.Reset();

        Assert.IsFalse(CombatFlow.Active);
        Assert.IsFalse(CombatFlow.Finished);
        Assert.AreEqual(-1, CombatFlow.Index);
        Assert.AreEqual(null, CombatFlow.GroupA);
        Assert.AreEqual(null, CombatFlow.GroupB);
        Assert.AreEqual(null, CombatFlow.Order);

        CombatFlow.Initialize(a, b);

        Assert.IsTrue(CombatFlow.Active);
        Assert.IsFalse(CombatFlow.Finished);
        Assert.AreEqual(-1, CombatFlow.Index);
        Assert.AreEqual(a, CombatFlow.GroupA);
        Assert.AreEqual(b, CombatFlow.GroupB);
    }

    [Test]
    public void TestOrder()
    {
        Character a1 = Factory.GenerateCharacter(initiativeValue: 1, initiativeVariation: 0);
        Character a2 = Factory.GenerateCharacter(initiativeValue: 3, initiativeVariation: 0);
        Character a3 = Factory.GenerateCharacter(initiativeValue: 2, initiativeVariation: 0);
        Character b1 = Factory.GenerateCharacter(initiativeValue: 4, initiativeVariation: 0);

        CharacterGroup a = new CharacterGroup(new List<Character>() { a1, a2, a3 });
        CharacterGroup b = new CharacterGroup(new List<Character>() { b1 });

        CombatFlow.Reset();
        CombatFlow.Initialize(a, b);

        Assert.AreEqual(b1, CombatFlow.Order[0]);
        Assert.AreEqual(a2, CombatFlow.Order[1]);
        Assert.AreEqual(a3, CombatFlow.Order[2]);
        Assert.AreEqual(a1, CombatFlow.Order[3]);
    }
}
