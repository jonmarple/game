using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Toast.Game.Characters;
using Toast.Game.Actions;
using Toast.Game.Shards;

namespace Toast.Game.Combat
{
    /// <summary>
    /// Process combat operations.
    /// </summary>
    public static class CombatHelper
    {
        #region PUBLIC

        /// <summary> Perform an attack. </summary>
        public static void PerformAttack(Attack attack, Character source, Character target, bool crit)
        {
            if (!source.Stats.Dead && !target.Stats.Dead)
            {
                if (crit) Debug.Log(attack.ActionName + " crit.");
                int damage = 0;
                damage += ApplyDamage(attack, source, target, true, crit);
                damage += ApplyDamage(attack, source, target, false, crit);
                Debug.Log(attack.ActionName + ": " + damage + " dmg");
                if (target.Stats.Dead) Debug.Log(target.CharacterName + " died.");
            }
        }

        /// <summary> Perform a regen. </summary>
        public static void PerformRegen(Regen regen, Character source, Character target, bool crit)
        {
            if (!source.Stats.Dead && !target.Stats.Dead)
            {
                if (crit) Debug.Log(regen.ActionName + " crit.");
                int amount = ApplyRegen(regen, source, target, crit);
                Debug.Log(regen.ActionName + ": " + amount + " hp");
            }
        }

        /// <summary> Perform a shard roll. </summary>
        public static void PerformRoll(Roll roll, Character source, Character target)
        {
            if (!source.Stats.Dead && !target.Stats.Dead)
            {
                int value = target.ShardBuffer.AddRoll(roll.Shard);
                source.Equipment.Shards.Remove(roll.Shard);
                Debug.Log(roll.ActionName + ": " + value);
            }
        }

        #endregion

        #region PRIVATE

        private static int ApplyDamage(Attack attack, Character source, Character target, bool physical, bool crit)
        {
            // get attack damage and add attack shard buffer
            int damage = GetDamage(attack, source, physical, crit);
            int aShard = source.ShardBuffer.GetAttackBuffer(physical);
            source.ShardBuffer.SetAttackBuffer(physical, 0);
            damage += aShard;

            // apply modifier
            int half = damage / 2;
            switch (physical ? target.Stats.PhysicalMod : target.Stats.MagicalMod)
            {
                case ModifierLevel.RESISTANT:
                    damage -= half;
                    break;
                case ModifierLevel.WEAK:
                    damage += half;
                    break;
                default:
                    break;
            }

            // get armor points and add defense shard buffer
            int armor = GetArmor(target, physical);
            int dShard = target.ShardBuffer.GetDefendBuffer(physical);
            target.ShardBuffer.SetDefendBuffer(physical, 0);
            armor += dShard;

            // apply damage to armor and hp
            if (armor > 0 && damage > armor) AlterArmorHP(target, -armor, -(damage - armor), physical);
            else if (armor > 0) AlterArmor(target, -damage, physical);
            else AlterHP(target, -damage);
            return damage;
        }

        private static int ApplyRegen(Regen regen, Character source, Character target, bool crit)
        {
            int amount = GetRegen(regen, source, true, crit);
            amount += GetRegen(regen, source, false, crit);
            AlterHP(target, amount);
            return amount;
        }

        private static int GetDamage(Attack attack, Character character, bool physical, bool crit)
        { return attack.Modifier * (physical ? character.Equipment.Weapon.Physical.Roll(crit) : character.Equipment.Weapon.Magical.Roll(crit)); }

        private static int GetRegen(Regen regen, Character character, bool physical, bool crit)
        { return regen.Modifier * (physical ? character.Equipment.Weapon.Physical.Roll(crit) : character.Equipment.Weapon.Magical.Roll(crit)); }

        private static int GetArmor(Character character, bool physical)
        { return physical ? character.Equipment.Armor.Physical : character.Equipment.Armor.Magical; }

        private static void AlterArmorHP(Character character, int armorDiff, int hpDiff, bool physical)
        { AlterArmor(character, armorDiff, physical); AlterHP(character, hpDiff); }

        private static void AlterArmor(Character character, int diff, bool physical)
        { if (physical) character.Equipment.Armor.AlterPhysical(diff); else character.Equipment.Armor.AlterMagical(diff); }

        private static void AlterHP(Character character, int diff)
        { character.Stats.AlterHP(diff); }

        #endregion
    }
}
