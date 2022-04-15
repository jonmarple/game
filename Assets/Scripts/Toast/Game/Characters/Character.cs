using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Toast.Game.Stats;
using Toast.Game.Items;
using Toast.Game.Shards;
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
        public Faction Faction { get; private set; }
        public Action Primary { get { return Equipment?.Weapon?.Primary; } }
        public Action Secondary { get { return Equipment?.Weapon?.Secondary; } }
        public Movement Movement { get; private set; }
        public StatBlock Stats { get; private set; }
        public Equipment Equipment { get; private set; }
        public CharacterAI AI { get; private set; }
        public ShardBuffer ShardBuffer { get; private set; }
        public bool Active { get { return CombatFlow.CurrentCharacter == this; } }
        public bool Selected { get; private set; }
        public bool Hovered { get; private set; }
        public System.Action TurnProcessHandler;

        /* Value Update Delegate/Event */
        public delegate void Killed();
        public static event Killed CharacterKilled;
        public event Killed ThisCharacterKilled;

        public Character(CharacterData data)
        {
            CharacterName = data.CharacterName;
            Movement = (Movement)data.Movement.Generate();
            Stats = data.StatBlock.Generate();
            Stats.Register(this);
            Equipment = data.Equipment.Generate();
            AI = data.AI?.Generate();
            ShardBuffer = new ShardBuffer();
            Selected = false;
            Hovered = false;
            TurnProcessHandler = HandleTurnProcess;
        }

        public Character(string name, Movement movement, StatBlock statBlock, Equipment equipment, CharacterAI ai)
        {
            CharacterName = name;
            Movement = movement;
            Stats = statBlock;
            Stats.Register(this);
            Equipment = equipment;
            AI = ai;
            ShardBuffer = new ShardBuffer();
            Selected = false;
            Hovered = false;
            TurnProcessHandler = HandleTurnProcess;
        }

        #region PUBLIC

        /// <summary> Perform specified action. </summary>
        public bool PerformAction(Action action, Character target)
        {
            if (action == null) Debug.LogWarning("Action missing.");
            else if (!action.CanPerform()) Debug.LogWarning("Action not available.");
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
                    case Roll roll:
                        CombatHelper.PerformRoll(roll, this, target);
                        return true;
                    default:
                        Debug.LogWarning("Implementation for " + action.ActionName + " missing.");
                        return false;
                }
            }
            return false;
        }

        /// <summary> Start turn process. </summary>
        public void Process()
        {
            // update stats
            Stats.AlterAP(Stats.APRegen);
            Equipment.Shards.FillHand();
            ShardBuffer.Reset();
            Equipment.Weapon.Primary.Turn();
            Equipment.Weapon.Secondary.Turn();

            // run AI
            if (AI != null)
                TurnProcessHandler();
        }

        /// <summary> Whether this Character can perform the specified Action. </summary>
        public bool CanPerformAction(Action action)
        { return !Stats.Dead && (!CombatFlow.Active || Active) && HasAction(action) && CanAffordAction(action) && action.CanPerform(); }

        /// <summary> Whether this Character can afford the specified Action. </summary>
        public bool CanAffordAction(Action action)
        { return Stats.AP >= action.Cost; }

        /// <summary> Whether Character has access to specified Action. </summary>
        public bool HasAction(Action action)
        {
            if (Movement == action)
                return true;
            if (Equipment?.Weapon?.Primary == action)
                return true;
            if (Equipment?.Weapon?.Secondary == action)
                return true;
            foreach (Shard shard in Equipment.Shards.Hand)
                if (shard.Roll == action)
                    return true;
            return false;
        }

        /// <summary> Kill this character. </summary>
        public void Kill()
        {
            ThisCharacterKilled?.Invoke();
            CharacterKilled?.Invoke();
        }

        /// <summary> Select this character. </summary>
        public void Select(bool active)
        { Selected = active; }

        /// <summary> Hover this character. </summary>
        public void Hover(bool active)
        { Hovered = active; }

        /// <summary> Set character's faction. </summary>
        public void SetFaction(Faction faction)
        { Faction = faction; }

        #endregion

        #region PRIVATE

        private void HandleTurnProcess()
        {
            AI.Process();
            CombatFlow.FinishTurn();
        }

        #endregion
    }
}
