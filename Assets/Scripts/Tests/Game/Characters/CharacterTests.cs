using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using Toast.Game;
using Toast.Game.Actions;
using Toast.Game.Combat;
using Toast.Game.Characters;
using Toast.Game.Shards;

public class CharacterTests
{
    [Test]
    public void TestPerformAction()
    {
        Character character = Factory.GenerateCharacter(ap: 3, initiativeValue: 1, initiativeVariation: 0);
        Character target = Factory.GenerateCharacter(hp: 100, hpMax: 100, initiativeValue: 10, initiativeVariation: 0);

        CombatFlow.Start(new CharacterGroup(Faction.A, new List<Character>() { character }), new CharacterGroup(Faction.B, new List<Character>() { target }));

        Assert.IsFalse(character.PerformAction(character.Primary, target)); // fail due to character inactivity

        CombatFlow.FinishTurn();

        Assert.IsTrue(character.PerformAction(character.Secondary, target));
        Assert.IsFalse(character.PerformAction(character.Secondary, target)); // fail due to cooldown
        Assert.IsTrue(character.PerformAction(character.Primary, target));
        Assert.IsFalse(character.PerformAction(null, target)); // fail due to missing action
        Assert.IsFalse(character.PerformAction(new Attack("Test Attack", 0, 0, 1), target)); // fail due to unattached action

        character.Stats.SetAP(0);

        Assert.IsFalse(character.PerformAction(character.Primary, target)); // fail due to ap cost
    }

    [Test]
    public void TestProcess()
    {
        Character character = Factory.GenerateCharacter(ap: 0, apMax: 10, apRegen: 2, weaponPrimary: new Attack("Primary", 1, 1, 1), weaponSecondary: new Attack("Secondary", 2, 2, 2), handSize: 5);

        character.Primary.Perform();
        character.Secondary.Perform();
        character.Equipment.Shards.Hand.RemoveAt(0);
        character.Equipment.Shards.Hand.RemoveAt(0);
        character.ShardBuffer.AddRoll(new MShard(new Spread(5, 0)));

        Assert.AreEqual(0, character.Stats.AP);
        Assert.AreEqual(1, character.Primary.CooldownCounter);
        Assert.AreEqual(2, character.Secondary.CooldownCounter);
        Assert.AreEqual(3, character.Equipment.Shards.Hand.Count);
        Assert.AreEqual(5, character.ShardBuffer.MBuffer);

        character.Process();

        Assert.AreEqual(2, character.Stats.AP);
        Assert.AreEqual(0, character.Primary.CooldownCounter);
        Assert.AreEqual(1, character.Secondary.CooldownCounter);
        Assert.AreEqual(5, character.Equipment.Shards.Hand.Count);
        Assert.AreEqual(1, character.ShardBuffer.MBuffer);
    }

    [Test]
    public void TestCanPerformAction()
    {
        Character character = Factory.GenerateCharacter(ap: 1, weaponPrimary: new Attack("Primary", 1, 1, 1));
        Character dead = Factory.GenerateCharacter(hp: 0);
        Attack attack = new Attack("Attack", 1, 0, 1);

        CombatFlow.Reset();

        Assert.IsTrue(character.CanPerformAction(character.Primary));

        character.Primary.Perform();

        Assert.IsFalse(character.CanPerformAction(character.Primary)); // fail due to cooldown
        Assert.IsFalse(character.CanPerformAction(character.Secondary)); // fail due to ap cost
        Assert.IsFalse(character.CanPerformAction(attack)); // fail due to unattached action
        Assert.IsFalse(dead.CanPerformAction(dead.Primary)); // fail due to being dead
    }

    [Test]
    public void TestCanAffordAction()
    {
        int cost = 2;
        Character character = Factory.GenerateCharacter(ap: cost);

        int count = cost * 2;
        for (int i = 0; i < count; i++)
            Assert.AreEqual(i <= cost, character.CanAffordAction(new Attack("Attack", i, 0, 1)));
    }

    [Test]
    public void TestHasAction()
    {
        Character character = Factory.GenerateCharacter();
        Attack attack = new Attack("Attack", 1, 0, 1);

        Assert.IsTrue(character.HasAction(character.Primary));
        Assert.IsTrue(character.HasAction(character.Secondary));
        Assert.IsTrue(character.HasAction(character.Movement));
        Assert.IsTrue(character.HasAction(character.Equipment.Shards.Hand[0].Roll));
        Assert.IsFalse(character.HasAction(attack));
    }
}
