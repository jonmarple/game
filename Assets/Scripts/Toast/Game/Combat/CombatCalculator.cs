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

        /// <summary> Calculate attack damage based on source weapon, attack, and target defense. </summary>
        public static int CalculateDamage(AttackActionData attack, CController source, CController target)
        { return Mathf.Clamp((source.Weapon.Damage * attack.Modifier) - target.Armor.Defense, 0, int.MaxValue); }

        /// <summary> Calculate regen amount based on source weapon and regen action. </summary>
        public static int CalculateRegen(RegenActionData regen, CController source)
        { return Mathf.Clamp(source.Weapon.Damage * regen.Modifier, 0, int.MaxValue); }

        /// <summary> Calculate shield boost based on target armor and defend action. </summary>
        public static int CalculateShield(DefendActionData defend, CController target)
        { return Mathf.Clamp(target.Armor.Defense * defend.Modifier, 0, int.MaxValue); }

        #endregion

        #region PRIVATE
        #endregion
    }
}
