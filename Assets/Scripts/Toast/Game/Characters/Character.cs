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
        public Action Primary { get { return Equipment?.Weapon?.Primary; } }
        public Action Secondary { get { return Equipment?.Weapon?.Secondary; } }
        public Movement Movement { get; private set; }
        public StatBlock Stats { get; private set; }
        public Equipment Equipment { get; private set; }
        public CharacterAI AI { get; private set; }
        public List<Action> Actions { get; private set; }

        public Character(CharacterData data)
        {
            CharacterName = data.CharacterName;
            Movement = (Movement)data.Movement.Generate();
            Stats = data.StatBlock.Generate();
            Equipment = data.Equipment.Generate();
            AI = data.AI.Generate();
            BuildActionsList();
        }

        public Character(string name, Movement movement, StatBlock statBlock, Equipment equipment, CharacterAI ai)
        {
            CharacterName = name;
            Movement = movement;
            Stats = statBlock;
            Equipment = equipment;
            AI = ai;
            BuildActionsList();
        }

        #region PUBLIC

        /// <summary> Whether this Character can afford the specified Action. </summary>
        public bool CanAffordAction(Action action)
        { return Stats.AP >= action.Cost; }

        /// <summary> Whether this Character can perform the specified Action. </summary>
        public bool CanPerformAction(Action action)
        { return !Stats.Dead && CanAffordAction(action) && Actions.Contains(action); }

        /// <summary> Perform specified action. </summary>
        public bool PerformAction(Action action, Character target)
        {
            if (action == null) Debug.LogWarning("Action missing.");
            else if (target == null) Debug.LogWarning("Target missing.");
            else if (!CanPerformAction(action)) Debug.Log(CharacterName + " cannot perform action " + action.ActionName + ".");
            else
            {
                Debug.Log(CharacterName + " performing action " + action.ActionName + " against " + target.CharacterName + ".");
                Stats.AlterAP(-action.Cost);
                switch (action)
                {
                    case Attack attack:
                        CombatHelper.PerformAttack(attack, this, target, Stats.RollCrit());
                        return true;
                    case Regen regen:
                        CombatHelper.PerformRegen(regen, this, target, Stats.RollCrit());
                        return true;
                    default:
                        Debug.LogWarning("Implementation for " + action.ActionName + " missing.");
                        return false;
                }
            }
            return false;
        }

        /// <summary> Process turn. </summary>
        public void Process()
        {
            Stats.AlterAP(Stats.APRegen);
            AI.Process();
        }

        #endregion

        #region PRIVATE

        private void BuildActionsList()
        {
            Actions = new List<Action>();
            if (Equipment != null && Equipment.Weapon != null)
            {
                if (Equipment.Weapon.Primary != null)
                    Actions.Add(Equipment.Weapon.Primary);
                if (Equipment.Weapon.Secondary != null)
                    Actions.Add(Equipment.Weapon.Secondary);
            }
        }

        #endregion
    }
}
