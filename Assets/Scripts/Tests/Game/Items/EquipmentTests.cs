using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using Toast.Game;
using Toast.Game.Items;
using Toast.Game.Shards;

public class EquipmentTests
{
    [Test]
    public void TestEquipment()
    {
        Armor armor = new Armor("Armor", 10, 10);
        Weapon weapon = new Weapon("Weapon", new Spread(), new Spread(), null, null);
        ShardBag shards = new ShardBag(30, 5, Spread.Generate(10));
        Equipment equipment = new Equipment(armor, weapon, shards);

        Assert.AreEqual(armor, equipment.Armor);
        Assert.AreEqual(weapon, equipment.Weapon);
        Assert.AreEqual(shards, equipment.Shards);
    }
}
