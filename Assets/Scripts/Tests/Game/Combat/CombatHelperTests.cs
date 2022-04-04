using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using Toast.Game;
using Toast.Game.Actions;
using Toast.Game.Characters;
using Toast.Game.Combat;
using Toast.Game.Shards;

public class CombatHelperTests
{
    [Test]
    public void TestAttack()
    {
        Character source = Factory.GenerateCharacter(weaponPhysicalValue: 3, weaponPhysicalVariation: 0, weaponMagicalValue: 2, weaponMagicalVariation: 0);
        Character target = Factory.GenerateCharacter(hp: 10, hpMax: 10, armorPhysical: 0, armorMagical: 0);

        Assert.AreEqual(10, target.Stats.HP);

        CombatHelper.PerformAttack((Attack)source.Primary, source, target, false);

        Assert.AreEqual(5, target.Stats.HP);
    }

    [Test]
    public void TestRegen()
    {
        Character source = Factory.GenerateCharacter(weaponPhysicalValue: 3, weaponPhysicalVariation: 0, weaponMagicalValue: 2, weaponMagicalVariation: 0, weaponPrimary: new Regen("Regen", 1, 0, 1));
        Character target = Factory.GenerateCharacter(hp: 6, hpMax: 10, armorPhysical: 0, armorMagical: 0);

        Assert.AreEqual(6, target.Stats.HP);

        CombatHelper.PerformRegen((Regen)source.Primary, source, target, false);

        Assert.AreEqual(10, target.Stats.HP);
    }

    [Test]
    public void TestRoll()
    {
        Shard shard = new MShard(new Spread(2, 0));
        Character source = Factory.GenerateCharacter(shards: new List<Shard>() { shard });

        Assert.AreEqual(1, source.ShardBuffer.MBuffer);
        Assert.IsTrue(source.Equipment.Shards.Hand.Contains(shard));

        CombatHelper.PerformRoll(source.Equipment.Shards.Hand[0].Roll, source, source);

        Assert.AreEqual(2, source.ShardBuffer.MBuffer);
        Assert.IsFalse(source.Equipment.Shards.Hand.Contains(shard));
    }

    [Test]
    public void TestActionMod()
    {
        Character source = Factory.GenerateCharacter(weaponPhysicalValue: 2, weaponPhysicalVariation: 0, weaponMagicalValue: 2, weaponMagicalVariation: 0);
        Character target = Factory.GenerateCharacter(hp: 10, hpMax: 10, armorPhysical: 0, armorMagical: 0);

        Assert.AreEqual(10, target.Stats.HP);

        CombatHelper.PerformAttack((Attack)source.Secondary, source, target, false);

        Assert.AreEqual(2, target.Stats.HP);
    }

    [Test]
    public void TestResistance()
    {
        Character source = Factory.GenerateCharacter(weaponPhysicalValue: 4, weaponPhysicalVariation: 0, weaponMagicalValue: 3, weaponMagicalVariation: 0);
        Character pTarget = Factory.GenerateCharacter(hp: 10, hpMax: 10, armorPhysical: 0, armorMagical: 0, physicalMod: ModifierLevel.RESISTANT);
        Character mTarget = Factory.GenerateCharacter(hp: 10, hpMax: 10, armorPhysical: 0, armorMagical: 0, magicalMod: ModifierLevel.RESISTANT);

        Assert.AreEqual(10, pTarget.Stats.HP);
        Assert.AreEqual(10, mTarget.Stats.HP);

        CombatHelper.PerformAttack((Attack)source.Primary, source, pTarget, false);
        CombatHelper.PerformAttack((Attack)source.Primary, source, mTarget, false);

        Assert.AreEqual(5, pTarget.Stats.HP);
        Assert.AreEqual(4, mTarget.Stats.HP);
    }

    [Test]
    public void TestWeakness()
    {
        Character source = Factory.GenerateCharacter(weaponPhysicalValue: 4, weaponPhysicalVariation: 0, weaponMagicalValue: 3, weaponMagicalVariation: 0);
        Character pTarget = Factory.GenerateCharacter(hp: 10, hpMax: 10, armorPhysical: 0, armorMagical: 0, physicalMod: ModifierLevel.WEAK);
        Character mTarget = Factory.GenerateCharacter(hp: 10, hpMax: 10, armorPhysical: 0, armorMagical: 0, magicalMod: ModifierLevel.WEAK);

        Assert.AreEqual(10, pTarget.Stats.HP);
        Assert.AreEqual(10, mTarget.Stats.HP);

        CombatHelper.PerformAttack((Attack)source.Primary, source, pTarget, false);
        CombatHelper.PerformAttack((Attack)source.Primary, source, mTarget, false);

        Assert.AreEqual(1, pTarget.Stats.HP);
        Assert.AreEqual(2, mTarget.Stats.HP);
    }

    [Test]
    public void TestCrit()
    {
        Character source = Factory.GenerateCharacter(weaponPhysicalValue: 2, weaponPhysicalVariation: 0, weaponMagicalValue: 1, weaponMagicalVariation: 0);
        Character target = Factory.GenerateCharacter(hp: 10, hpMax: 10, armorPhysical: 0, armorMagical: 0);

        Assert.AreEqual(10, target.Stats.HP);

        CombatHelper.PerformAttack((Attack)source.Primary, source, target, true);

        Assert.AreEqual(4, target.Stats.HP);
    }

    [Test]
    public void TestArmor()
    {
        Character source = Factory.GenerateCharacter(weaponPhysicalValue: 3, weaponPhysicalVariation: 0, weaponMagicalValue: 2, weaponMagicalVariation: 0);
        Character target = Factory.GenerateCharacter(hp: 10, hpMax: 10, armorPhysical: 5, armorMagical: 5);

        Assert.AreEqual(10, target.Stats.HP);
        Assert.AreEqual(5, target.Equipment.Armor.Physical);
        Assert.AreEqual(5, target.Equipment.Armor.Magical);

        CombatHelper.PerformAttack((Attack)source.Primary, source, target, false);

        Assert.AreEqual(10, target.Stats.HP);
        Assert.AreEqual(2, target.Equipment.Armor.Physical);
        Assert.AreEqual(3, target.Equipment.Armor.Magical);

        CombatHelper.PerformAttack((Attack)source.Primary, source, target, false);

        Assert.AreEqual(9, target.Stats.HP);
        Assert.AreEqual(0, target.Equipment.Armor.Physical);
        Assert.AreEqual(1, target.Equipment.Armor.Magical);
    }

    [Test]
    public void TestDeath()
    {
        Character source = Factory.GenerateCharacter(weaponPhysicalValue: 3, weaponPhysicalVariation: 0, weaponMagicalValue: 2, weaponMagicalVariation: 0);
        Character target = Factory.GenerateCharacter(hp: 4, hpMax: 10, armorPhysical: 0, armorMagical: 0);

        Assert.AreEqual(4, target.Stats.HP);
        Assert.IsFalse(target.Stats.Dead);

        CombatHelper.PerformAttack((Attack)source.Primary, source, target, false);

        Assert.AreEqual(0, target.Stats.HP);
        Assert.IsTrue(target.Stats.Dead);
    }

    [Test]
    public void TestAShardBuffer()
    {
        MShard mShard = new MShard(new Spread(2, 0));
        APShard apShard = new APShard(new Spread(3, 0));
        AMShard amShard = new AMShard(new Spread(1, 0));
        Character source = Factory.GenerateCharacter(weaponPhysicalValue: 3, weaponPhysicalVariation: 0, weaponMagicalValue: 2, weaponMagicalVariation: 0);
        Character target = Factory.GenerateCharacter(hp: 100, hpMax: 100, armorPhysical: 0, armorMagical: 0);

        Assert.AreEqual(100, target.Stats.HP);

        CombatHelper.PerformAttack((Attack)source.Primary, source, target, false);

        Assert.AreEqual(95, target.Stats.HP);

        CombatHelper.PerformRoll(mShard.Roll, source, source);
        CombatHelper.PerformRoll(apShard.Roll, source, source);
        CombatHelper.PerformAttack((Attack)source.Primary, source, target, false);

        Assert.AreEqual(84, target.Stats.HP);

        CombatHelper.PerformRoll(amShard.Roll, source, source);
        CombatHelper.PerformAttack((Attack)source.Primary, source, target, false);

        Assert.AreEqual(78, target.Stats.HP);
    }

    [Test]
    public void TestDShardBuffer()
    {
        MShard mShard = new MShard(new Spread(2, 0));
        DPShard dpShard = new DPShard(new Spread(2, 0));
        DMShard dmShard = new DMShard(new Spread(1, 0));
        Character source = Factory.GenerateCharacter(weaponPhysicalValue: 3, weaponPhysicalVariation: 0, weaponMagicalValue: 2, weaponMagicalVariation: 0);
        Character target = Factory.GenerateCharacter(hp: 100, hpMax: 100, armorPhysical: 0, armorMagical: 0);

        Assert.AreEqual(100, target.Stats.HP);

        CombatHelper.PerformAttack((Attack)source.Primary, source, target, false);

        Assert.AreEqual(95, target.Stats.HP);

        CombatHelper.PerformRoll(dpShard.Roll, target, target);
        CombatHelper.PerformAttack((Attack)source.Primary, source, target, false);

        Assert.AreEqual(92, target.Stats.HP);

        CombatHelper.PerformRoll(mShard.Roll, target, target);
        CombatHelper.PerformRoll(dmShard.Roll, target, target);
        CombatHelper.PerformAttack((Attack)source.Primary, source, target, false);

        Assert.AreEqual(89, target.Stats.HP);
    }

    [Test]
    public void TestConjunction()
    {
        MShard mShard = new MShard(new Spread(2, 0));
        APShard apShard = new APShard(new Spread(3, 0));
        AMShard amShard = new AMShard(new Spread(2, 0));
        DPShard dpShard = new DPShard(new Spread(2, 0));
        DMShard dmShard = new DMShard(new Spread(1, 0));
        Character source = Factory.GenerateCharacter(weaponPhysicalValue: 3, weaponPhysicalVariation: 0, weaponMagicalValue: 2, weaponMagicalVariation: 0);
        Character target = Factory.GenerateCharacter(hp: 100, hpMax: 100, armorPhysical: 10, armorMagical: 10, weaponPhysicalValue: 1, weaponPhysicalVariation: 0, weaponMagicalValue: 2, weaponMagicalVariation: 0, physicalMod: ModifierLevel.RESISTANT, magicalMod: ModifierLevel.WEAK, weaponPrimary: new Regen("Regen", 1, 0, 1));

        Assert.AreEqual(100, target.Stats.HP);
        Assert.AreEqual(10, target.Equipment.Armor.Physical);
        Assert.AreEqual(10, target.Equipment.Armor.Magical);

        CombatHelper.PerformRoll(mShard.Roll, source, source);
        CombatHelper.PerformRoll(mShard.Roll, source, source);
        CombatHelper.PerformRoll(apShard.Roll, source, source);
        CombatHelper.PerformRoll(mShard.Roll, source, source);
        CombatHelper.PerformRoll(amShard.Roll, source, source);
        CombatHelper.PerformRoll(dpShard.Roll, target, target);
        CombatHelper.PerformRoll(dmShard.Roll, target, target);
        CombatHelper.PerformAttack((Attack)source.Secondary, source, target, true);

        Assert.AreEqual(93, target.Stats.HP);
        Assert.AreEqual(0, target.Equipment.Armor.Physical);
        Assert.AreEqual(0, target.Equipment.Armor.Magical);

        CombatHelper.PerformRoll(amShard.Roll, target, target);
        CombatHelper.PerformRegen((Regen)target.Primary, target, target, false);

        Assert.AreEqual(96, target.Stats.HP);
        Assert.AreEqual(0, target.Equipment.Armor.Physical);
        Assert.AreEqual(0, target.Equipment.Armor.Magical);
    }
}
