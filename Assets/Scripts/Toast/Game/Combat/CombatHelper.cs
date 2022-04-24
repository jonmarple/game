using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Toast.Game.Characters;
using Toast.Game.Actions;
using Toast.Game.UI;
using Toast.Audio;

namespace Toast.Game.Combat
{
    /// <summary>
    /// Process combat operations.
    /// </summary>
    public static class CombatHelper
    {
        /* Roll Delegate/Event */
        public delegate void Performed();
        public static event Performed ShardRolled;

        #region PUBLIC

        /// <summary> Perform an attack. </summary>
        public static void PerformAttack(Attack attack, Character source, Character target, bool crit)
        {
            if (!source.Stats.Dead && !target.Stats.Dead)
            {
                attack.Perform();
                source.Controller.AnimateAction();
                ActionInfo info = new ActionInfo(attack, source, target, crit);
                if (CombatController.Instance)
                    CombatController.Instance.PerformAction(HandleAttack, info);
                else HandleAttack(info);
            }
        }

        /// <summary> Perform a regen. </summary>
        public static void PerformRegen(Regen regen, Character source, Character target, bool crit)
        {
            if (!source.Stats.Dead && !target.Stats.Dead)
            {
                regen.Perform();
                source.Controller.AnimateAction();
                ActionInfo info = new ActionInfo(regen, source, target, crit);
                if (CombatController.Instance)
                    CombatController.Instance.PerformAction(HandleRegen, info);
                else HandleAttack(info);
            }
        }

        /// <summary> Perform a shard roll. </summary>
        public static void PerformRoll(Roll roll, Character source, Character target)
        {
            if (!source.Stats.Dead && !target.Stats.Dead)
            {
                roll.Perform();
                source.Controller.AnimateAction();
                ActionInfo info = new ActionInfo(roll, source, target, false);
                if (CombatController.Instance)
                    CombatController.Instance.PerformAction(HandleRoll, info);
                else HandleAttack(info);
            }
        }

        #endregion

        #region PRIVATE

        private static void HandleAttack(ActionInfo info)
        {
            int damage = ApplyDamage((Attack)info.Action, info.Source, info.Target, true, info.Crit)
                       + ApplyDamage((Attack)info.Action, info.Source, info.Target, false, info.Crit);
            if (info.Crit) AudioManager.Play(AudioKey.DAMAGE_DEALT_CRIT);
            else AudioManager.Play(AudioKey.DAMAGE_DEALT);
            info.Target.Controller.AnimateDamage();
            TextSpawner.Instance?.Spawn(damage.ToString(), (info.Target.Controller?.transform.position ?? Vector3.zero) + Vector3.up, info.Crit ? FloatingTextType.CRIT : FloatingTextType.DAMAGE);
            Debug.Log(info.Action.ActionName + ": " + damage + " dmg");
            if (info.Target.Stats.Dead) Debug.Log(info.Target.CharacterName + " died.");
        }

        private static void HandleRegen(ActionInfo info)
        {
            int amount = ApplyRegen((Regen)info.Action, info.Source, info.Target, info.Crit);
            if (info.Crit) AudioManager.Play(AudioKey.HEALING_DEALT_CRIT);
            else AudioManager.Play(AudioKey.HEALING_DEALT);
            info.Target.Controller.AnimateHealing();
            TextSpawner.Instance?.Spawn(amount.ToString(), (info.Target.Controller?.transform.position ?? Vector3.zero) + Vector3.up, info.Crit ? FloatingTextType.CRIT : FloatingTextType.HEALING);
            Debug.Log(info.Action.ActionName + ": " + amount + " hp");
        }

        private static void HandleRoll(ActionInfo info)
        {
            int value = info.Target.ShardBuffer.AddRoll(((Roll)info.Action).Shard);
            info.Source.Equipment.Shards.Hand.Remove(((Roll)info.Action).Shard);
            ShardRolled?.Invoke();
            AudioManager.Play(AudioKey.SHARD_BUFF_DEALT);
            TextSpawner.Instance?.Spawn(value.ToString(), (info.Target.Controller?.transform.position ?? Vector3.zero) + Vector3.up, FloatingTextType.DEFAULT);
            Debug.Log(info.Action.ActionName + ": " + value);
        }

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
            int amount = GetRegen(regen, source, true, crit) + GetRegen(regen, source, false, crit);
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
