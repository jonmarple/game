using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using Toast.Game.Items;

public class ArmorTests
{
    [Test]
    public void TestArmor()
    {
        int physical = 1;
        int magical = 2;
        Armor armor = new Armor("Armor", physical, magical);

        Assert.AreEqual(physical, armor.Physical);
        Assert.AreEqual(physical, armor.PhysicalMax);
        Assert.AreEqual(magical, armor.Magical);
        Assert.AreEqual(magical, armor.MagicalMax);
    }

    [Test]
    public void TestSetPhysical()
    {
        Armor armor = new Armor("Armor", 1, 0);
        Armor armorZero = new Armor("Armor", 0, 0);

        Assert.AreEqual(1, armor.Physical);
        Assert.AreEqual(1, armor.PhysicalMax);
        Assert.AreEqual(0, armorZero.Physical);
        Assert.AreEqual(0, armorZero.PhysicalMax);

        armor.SetPhysical(0);
        armorZero.SetPhysical(1);

        Assert.AreEqual(0, armor.Physical);
        Assert.AreEqual(1, armor.PhysicalMax);
        Assert.AreEqual(0, armorZero.Physical);
        Assert.AreEqual(0, armorZero.PhysicalMax);
    }

    [Test]
    public void TestSetMagical()
    {
        Armor armor = new Armor("Armor", 0, 1);
        Armor armorZero = new Armor("Armor", 0, 0);

        Assert.AreEqual(1, armor.Magical);
        Assert.AreEqual(1, armor.MagicalMax);
        Assert.AreEqual(0, armorZero.Magical);
        Assert.AreEqual(0, armorZero.MagicalMax);

        armor.SetMagical(0);
        armorZero.SetMagical(1);

        Assert.AreEqual(0, armor.Magical);
        Assert.AreEqual(1, armor.MagicalMax);
        Assert.AreEqual(0, armorZero.Magical);
        Assert.AreEqual(0, armorZero.MagicalMax);
    }

    [Test]
    public void TestAlterPhysical()
    {
        Armor armor = new Armor("Armor", 1, 0);
        Armor armorZero = new Armor("Armor", 0, 0);

        Assert.AreEqual(1, armor.Physical);
        Assert.AreEqual(1, armor.PhysicalMax);
        Assert.AreEqual(0, armorZero.Physical);
        Assert.AreEqual(0, armorZero.PhysicalMax);

        armor.AlterPhysical(-1);
        armorZero.AlterPhysical(1);

        Assert.AreEqual(0, armor.Physical);
        Assert.AreEqual(1, armor.PhysicalMax);
        Assert.AreEqual(0, armorZero.Physical);
        Assert.AreEqual(0, armorZero.PhysicalMax);
    }

    [Test]
    public void TestAlterMagical()
    {
        Armor armor = new Armor("Armor", 0, 1);
        Armor armorZero = new Armor("Armor", 0, 0);

        Assert.AreEqual(1, armor.Magical);
        Assert.AreEqual(1, armor.MagicalMax);
        Assert.AreEqual(0, armorZero.Magical);
        Assert.AreEqual(0, armorZero.MagicalMax);

        armor.AlterMagical(-1);
        armorZero.AlterMagical(1);

        Assert.AreEqual(0, armor.Magical);
        Assert.AreEqual(1, armor.MagicalMax);
        Assert.AreEqual(0, armorZero.Magical);
        Assert.AreEqual(0, armorZero.MagicalMax);
    }
}
