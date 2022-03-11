using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Toast.Game.Stats;
using Toast.Game.Items;
using Toast.Game.Actions;
using Toast.Game.Combat;

namespace Toast.Game.Characters
{
    /// <summary>
    /// Main interface for interacting with character GameObjects.
    /// </summary>
    public class CController : MonoBehaviour
    {
        /* Public Fields */
        public Armor Armor { get { return equipment.Armor; } }
        public Weapon Weapon { get { return equipment.Weapon; } }

        /* Serialized Fields */

        /* Private Fields */
        private CharacterData data;
        private StatBlock stats;
        private Equipment equipment;

        #region PUBLIC

        /// <summary> Initialize controller with character data. </summary>
        public void Initialize(CharacterData data)
        {
            this.data = data;
            stats = data.GenerateStatBlock();
            equipment = data.GenerateEquipment();
        }

        /// <summary> Whether this Character can afford the specified Action. </summary>
        public bool CanPerformAction(ActionData action)
        { return stats.AP >= action.Cost; }

        /// <summary> Perform specified action. </summary>
        public void PerformAction(ActionData action, CController target = null)
        {
            if (action)
            {
                if (CanPerformAction(action))
                {
                    Debug.Log(data.CharacterName + " performing " + action.ActionName);
                    AlterAP(-action.Cost);
                    switch (action)
                    {
                        case AttackActionData attack:
                            PerformAttack(attack, target);
                            break;
                        case RegenActionData regen:
                            PerformRegen(regen, target);
                            break;
                        case DefendActionData defend:
                            PerformDefend(defend, target);
                            break;
                        default:
                            Debug.LogWarning("Implementation for " + action.ActionName + " missing.");
                            break;
                    }
                }
            }
            else Debug.LogWarning("Action missing.");
        }

        /// <summary> Apply damage to character. </summary>
        public void ApplyDamage(int damage)
        {
            if (stats.Shield < damage)
            {
                damage -= stats.Shield;
                AlterShield(-stats.Shield);
                AlterHP(-damage);
                // TODO: Check HP for death conditions
            }
            else AlterShield(-damage);
        }

        /// <summary> Apply regen to character. </summary>
        public void ApplyRegen(int regen, RegenType type)
        {
            if (type == RegenType.HP)
                AlterHP(Mathf.Clamp(regen, 0, int.MaxValue));
            else if (type == RegenType.AP)
                AlterAP(Mathf.Clamp(regen, 0, int.MaxValue));
        }

        /// <summary> Apply shield to character. </summary>
        public void ApplyShield(int shield)
        { AlterShield(shield); }

        #endregion

        #region PRIVATE

        private void AlterHP(int diff)
        { stats.AlterHP(diff); }

        private void AlterAP(int diff)
        { stats.AlterAP(diff); }

        private void AlterShield(int diff)
        { stats.AlterShield(diff); }

        private void PerformAttack(AttackActionData attack, CController target)
        { target.ApplyDamage(CombatCalculator.CalculateDamage(attack, this, target)); }

        private void PerformRegen(RegenActionData regen, CController target)
        { target.ApplyRegen(CombatCalculator.CalculateRegen(regen, this), regen.Type); }

        private void PerformDefend(DefendActionData defend, CController target)
        { target.ApplyShield(CombatCalculator.CalculateShield(defend, target)); }

        #endregion
    }
}
