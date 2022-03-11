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
    /// System-serializable character information container.
    /// </summary>
    [System.Serializable]
    public class Character
    {
        /* Public Fields */
        public string CharacterName { get { return characterName; } }
        public Movement Movement { get { return movement; } }
        public Defend Defend { get { return defend; } }
        public StatBlock Stats { get { return stats; } }
        public Equipment Equipment { get { return equipment; } }

        /* Private Fields */
        private string characterName;
        private Movement movement;
        private Defend defend;
        private StatBlock stats;
        private Equipment equipment;

        public Character(CharacterData data)
        {
            this.characterName = data.CharacterName;
            this.movement = data.Movement.Generate();
            this.defend = data.Defend.Generate();
            this.stats = data.StatBlock.Generate();
            this.equipment = data.Equipment.Generate();
        }

        public Character(string name, Movement movement, Defend defend, StatBlock statBlock, Equipment equipment)
        {
            this.characterName = name;
            this.movement = movement;
            this.defend = defend;
            this.stats = statBlock;
            this.equipment = equipment;
        }

        #region PUBLIC

        /// <summary> Whether this Character can afford the specified Action. </summary>
        public bool CanPerformAction(Action action)
        { return stats.AP >= action.Cost; } // TODO: check if action exists on character

        /// <summary> Perform specified action. </summary>
        public void PerformAction(Action action, Character target)
        {
            if (action == null) Debug.LogWarning("Action missing.");
            else if (target == null) Debug.LogWarning("Target missing.");
            else if (!CanPerformAction(action)) Debug.Log(characterName + " cannot perform action " + action.ActionName + ".");
            else
            {
                Debug.Log(characterName + " performing action " + action.ActionName + ".");

                stats.AlterAP(-action.Cost);
                switch (action)
                {
                    case Attack attack:
                        PerformAttack(attack, target);
                        break;
                    case Regen regen:
                        PerformRegen(regen, target);
                        break;
                    case Defend defend:
                        PerformDefend(defend, target);
                        break;
                    default:
                        Debug.LogWarning("Implementation for " + action.ActionName + " missing.");
                        break;
                }
            }
        }

        /// <summary> Apply damage to character. </summary>
        public void ApplyDamage(int damage)
        {
            if (stats.Shield < damage)
            {
                damage -= stats.Shield;
                stats.AlterShield(-stats.Shield);
                stats.AlterHP(-damage);
                // TODO: Check HP for death conditions
            }
            else stats.AlterShield(-damage);
        }

        /// <summary> Apply regen to character. </summary>
        public void ApplyRegen(int regen, RegenType type)
        {
            if (type == RegenType.HP)
                stats.AlterHP(Mathf.Clamp(regen, 0, int.MaxValue));
            else if (type == RegenType.AP)
                stats.AlterAP(Mathf.Clamp(regen, 0, int.MaxValue));
        }

        /// <summary> Apply shield to character. </summary>
        public void ApplyShield(int shield)
        { stats.AlterShield(shield); }

        #endregion

        #region PRIVATE

        private void PerformAttack(Attack attack, Character target)
        { target.ApplyDamage(CombatCalculator.CalculateDamage(attack, this, target)); }

        private void PerformRegen(Regen regen, Character target)
        { target.ApplyRegen(CombatCalculator.CalculateRegen(regen, this), regen.Type); }

        private void PerformDefend(Defend defend, Character target)
        { target.ApplyShield(CombatCalculator.CalculateShield(defend, target)); }

        #endregion
    }
}
