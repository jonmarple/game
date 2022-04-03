using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using Toast.Game.Characters;

public class CharacterGroupTests
{
    [Test]
    public void TestGroup()
    {
        Character c1 = Factory.GenerateCharacter();
        Character c2 = Factory.GenerateCharacter();
        CharacterGroup group = new CharacterGroup(new List<Character>() { c1, c2 });

        Assert.AreEqual(2, group.Characters.Count);
        Assert.AreEqual(c1, group.Characters[0]);
        Assert.AreEqual(c2, group.Characters[1]);
    }

    [Test]
    public void TestActive()
    {
        CharacterGroup group = new CharacterGroup(new List<Character>() { Factory.GenerateCharacter(), Factory.GenerateCharacter() });
        CharacterGroup dead = new CharacterGroup(new List<Character>() { Factory.GenerateCharacter(hp: 0), Factory.GenerateCharacter(hp: 0) });

        Assert.IsTrue(group.Active);
        Assert.IsFalse(dead.Active);
    }
}
