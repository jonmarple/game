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
        public static void PerformAttack(Attack attack, Character source, Character target)
        {
            if (!source.Stats.Dead && !target.Stats.Dead)
            {
                ApplyDamage(attack, source, target, true);
                ApplyDamage(attack, source, target, false);
                if (target.Stats.Dead) Debug.Log(target.CharacterName + " died.");
            }
        }

        /// <summary> Perform a regen. </summary>
        public static void PerformRegen(Regen regen, Character source, Character target)
        {
            if (!source.Stats.Dead && !target.Stats.Dead)
            {
                ApplyRegen(regen, source, target);
            }
        }

        #endregion

        #region PRIVATE

        private static void ApplyDamage(Attack attack, Character source, Character target, bool physical)
        {
            int damage = GetDamage(attack, source, physical);
            int armor = GetArmor(target, physical);
            if (armor > 0)
            {
                if (damage > armor) AlterArmorHP(target, -armor, -(damage - armor), physical);
                else AlterArmor(target, -damage, physical);
            }
            else AlterHP(target, -damage);
        }

        private static void ApplyRegen(Regen regen, Character source, Character target)
        {
            int amount = GetRegen(regen, source, true);
            amount += GetRegen(regen, source, false);
            AlterHP(target, amount);
        }

        private static int GetDamage(Attack attack, Character character, bool physical)
        { return attack.Modifier * (physical ? character.Equipment.Weapon.Physical.Roll() : character.Equipment.Weapon.Magical.Roll()); }

        private static int GetRegen(Regen regen, Character character, bool physical)
        { return regen.Modifier * (physical ? character.Equipment.Weapon.Physical.Roll() : character.Equipment.Weapon.Magical.Roll()); }

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
