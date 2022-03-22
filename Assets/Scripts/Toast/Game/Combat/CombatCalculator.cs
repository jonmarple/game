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
        {
            int physical = Damage(source.Equipment.Weapon.Physical.Roll(), attack.Modifier, target.Equipment.Armor.Physical.Roll());
            int magical = Damage(source.Equipment.Weapon.Magical.Roll(), attack.Modifier, target.Equipment.Armor.Magical.Roll());
            return physical + magical;
        }

        /// <summary> Calculate regen amount. </summary>
        public static int CalculateRegen(Regen regen, Character source)
        {
            int physical = Regen(source.Equipment.Weapon.Physical.Roll(), regen.Modifier);
            int magical = Regen(source.Equipment.Weapon.Magical.Roll(), regen.Modifier);
            return physical + magical;
        }

        #endregion

        #region PRIVATE

        private static int Damage(int damage, int modifier, int defense)
        { return Mathf.Clamp((damage * modifier) - defense, 0, int.MaxValue); }

        private static int Regen(int regen, int modifier)
        { return Mathf.Clamp(regen * modifier, 0, int.MaxValue); }

        #endregion
    }
}
