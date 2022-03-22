using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Toast.Game.Characters;
using Toast.Game.Actions;

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
                Debug.Log(attack.ActionName + ": " + damage + "dmg");
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
                Debug.Log(regen.ActionName + ": " + amount + "hp");
            }
        }

        #endregion

        #region PRIVATE

        private static int ApplyDamage(Attack attack, Character source, Character target, bool physical, bool crit)
        {
            int damage = GetDamage(attack, source, physical, crit);
            if (target.Stats.WeakTo(physical ? DamageType.PHYSICAL : DamageType.MAGICAL)) damage *= 2;
            if (target.Stats.ResistantTo(physical ? DamageType.PHYSICAL : DamageType.MAGICAL)) damage /= 2;
            int armor = GetArmor(target, physical);
            if (armor > 0)
            {
                if (damage > armor) AlterArmorHP(target, -armor, -(damage - armor), physical);
                else AlterArmor(target, -damage, physical);
            }
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
