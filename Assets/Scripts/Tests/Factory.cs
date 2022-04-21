using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using Toast.Game;
using Toast.Game.Characters;
using Toast.Game.Combat;
using Toast.Game.Actions;
using Toast.Game.AI;
using Toast.Game.Items;
using Toast.Game.Stats;
using Toast.Game.Shards;
using Toast.Audio;

public class Factory
{
    #region PUBLIC

    /*
    public static Character GenerateCharacter(
        string name = null,
        Movement movement = null,
        StatBlock statBlock = null,
        Equipment equipment = null,
        CharacterAI ai = null
    )
    {
        return new Character(
            name != null ? name : "Name",
            movement != null ? movement : new Movement("Movement", 1, 0, MovementType.FOUR),
            statBlock != null ? statBlock : new StatBlock(10, 10, 10, 10, 5, 10, new Spread(10, 5), ModifierLevel.NONE, ModifierLevel.NONE),
            equipment != null ? equipment : new Equipment(new Armor("Armor", 10, 10), new Weapon("Weapon", new Spread(5, 2), new Spread(5, 2), new Attack("Primary", 1, 0, 1), new Attack("Secondary", 2, 1, 2)), new ShardBag(ShardBag.GenerateShards(30), 5)),
            ai
        );
    }
    */

    public static Character GenerateCharacter(
        string name = "Character",
        string movementName = "Movement",
        int movementCost = 1,
        int movementCooldown = 0,
        MovementType movementType = MovementType.FOUR,
        int hp = 10,
        int hpMax = 10,
        int ap = 10,
        int apMax = 10,
        int apRegen = 5,
        int crit = 10,
        int initiativeValue = 10,
        int initiativeVariation = 5,
        ModifierLevel physicalMod = ModifierLevel.NONE,
        ModifierLevel magicalMod = ModifierLevel.NONE,
        string armorName = "Armor",
        int armorPhysical = 10,
        int armorMagical = 10,
        string weaponName = "Weapon",
        int weaponPhysicalValue = 5,
        int weaponPhysicalVariation = 2,
        int weaponMagicalValue = 5,
        int weaponMagicalVariation = 2,
        Action weaponPrimary = null,
        Action weaponSecondary = null,
        List<Shard> shards = null,
        int shardCount = 30,
        int handSize = 5,
        int shardTargetValue = 10,
        CharacterAI ai = null
    )
    {
        return new Character(
            name,
            new Movement(movementName, movementCost, movementCooldown, movementType),
            new StatBlock(hp, hpMax, ap, apMax, apRegen, crit,
                new Spread(initiativeValue, initiativeVariation),
                physicalMod, magicalMod),
            new Equipment(
                new Armor(armorName, armorPhysical, armorMagical),
                new Weapon(weaponName,
                    new Spread(weaponPhysicalValue, weaponPhysicalVariation),
                    new Spread(weaponMagicalValue, weaponMagicalVariation),
                    weaponPrimary != null ? weaponPrimary : new Attack("Primary", 1, 0, 1),
                    weaponSecondary != null ? weaponSecondary : new Attack("Secondary", 2, 1, 2)),
                new ShardBag(shards != null ? shards : ShardBag.GenerateShards(shardCount, Spread.Generate(shardTargetValue)), handSize)),
            ai
        );
    }

    #endregion
}
