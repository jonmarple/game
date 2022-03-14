using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Toast.Game.Stats;
using Toast.Game.Items;
using Toast.Game.Actions;
using Toast.Game.Combat;
using Toast.Game.AI;

namespace Toast.Game.Characters
{
    /// <summary>
    /// Character information container.
    /// </summary>
    public class Character
    {
        /* Public Fields */
        public string CharacterName { get; private set; }
        public Movement Movement { get; private set; }
        public Defend Defend { get; private set; }
        public StatBlock Stats { get; private set; }
        public Equipment Equipment { get; private set; }
        public CharacterAI AI { get; private set; }

        public Character(CharacterData data)
        {
            CharacterName = data.CharacterName;
            Movement = (Movement)data.Movement.Generate();
            Defend = (Defend)data.Defend.Generate();
            Stats = data.StatBlock.Generate();
            Equipment = data.Equipment.Generate();
            AI = data.AI.Generate();
        }

        public Character(string name, Movement movement, Defend defend, StatBlock statBlock, Equipment equipment, CharacterAI ai)
        {
            CharacterName = name;
            Movement = movement;
            Defend = defend;
            Stats = statBlock;
            Equipment = equipment;
            AI = ai;
        }

        #region PUBLIC

        /// <summary> Whether this Character can afford the specified Action. </summary>
        public bool CanPerformAction(Action action)
        { return !Stats.Dead && Stats.AP >= action.Cost; } // TODO: check if action exists on character

        /// <summary> Perform specified action. </summary>
        public void PerformAction(Action action, Character target)
        {
            if (action == null) Debug.LogWarning("Action missing.");
            else if (target == null) Debug.LogWarning("Target missing.");
            else if (!CanPerformAction(action)) Debug.Log(CharacterName + " cannot perform action " + action.ActionName + ".");
            else
            {
                Debug.Log(CharacterName + " performing action " + action.ActionName + ".");

                Stats.AlterAP(-action.Cost);
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
            if (Stats.Shield < damage)
            {
                damage -= Stats.Shield;
                Stats.AlterShield(-Stats.Shield);
                Stats.AlterHP(-damage);
            }
            else Stats.AlterShield(-damage);
        }

        /// <summary> Apply regen to character. </summary>
        public void ApplyRegen(int regen, RegenType type)
        {
            if (type == RegenType.HP)
                Stats.AlterHP(Mathf.Clamp(regen, 0, int.MaxValue));
            else if (type == RegenType.AP)
                Stats.AlterAP(Mathf.Clamp(regen, 0, int.MaxValue));
        }

        /// <summary> Apply shield to character. </summary>
        public void ApplyShield(int shield)
        { Stats.AlterShield(shield); }

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
