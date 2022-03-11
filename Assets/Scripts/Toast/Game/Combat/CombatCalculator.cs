using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Toast.Game.Characters;
using Toast.Game.Actions;

namespace Toast.Game.Combat
{
    /// <summary>
    /// Process combat calculations.
    /// </summary>
    public static class CombatCalculator
    {
        #region PUBLIC

        /// <summary> Calculate attack damage. </summary>
        public static int CalculateDamage(Attack attack, Character source, Character target)
        { return Damage(source.Equipment.Weapon.Damage, attack.Modifier, target.Equipment.Armor.Defense); }

        /// <summary> Calculate regen amount. </summary>
        public static int CalculateRegen(Regen regen, Character source)
        { return Regen(source.Equipment.Weapon.Damage, regen.Modifier); }

        /// <summary> Calculate shield boost. </summary>
        public static int CalculateShield(Defend defend, Character target)
        { return Shield(target.Equipment.Armor.Defense, defend.Modifier); }

        #endregion

        #region PRIVATE

        private static int Damage(int damage, int modifier, int defense)
        { return Mathf.Clamp((damage * modifier) - defense, 0, int.MaxValue); }

        private static int Regen(int regen, int modifier)
        { return Mathf.Clamp(regen * modifier, 0, int.MaxValue); }

        private static int Shield(int defense, int modifier)
        { return Mathf.Clamp(defense * modifier, 0, int.MaxValue); }

        #endregion
    }
}
