using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using Toast.Game;
using Toast.Game.Actions;
using Toast.Game.Items;

public class WeaponTests
{
    [Test]
    public void TestWeapon()
    {
        Spread physical = new Spread(5, 2);
        Spread magical = new Spread(2, 1);
        Attack primary = new Attack("Primary", 1, 0, 1);
        Attack secondary = new Attack("Secondary", 2, 1, 2);
        Weapon weapon = new Weapon("Weapon", physical, magical, primary, secondary);

        Assert.AreEqual("Weapon", weapon.ItemName);
        Assert.AreEqual(physical, weapon.Physical);
        Assert.AreEqual(magical, weapon.Magical);
        Assert.AreEqual(primary, weapon.Primary);
        Assert.AreEqual(secondary, weapon.Secondary);
    }
}
