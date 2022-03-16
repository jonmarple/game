using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Toast.Game.Actions;
using Toast.Game.Characters;

namespace Toast.Game.AI
{
    /// <summary>
    /// Character AI module information container.
    /// </summary>
    public class CharacterAI
    {
        /* Private Fields */
        private Character self;
        private CharacterGroup allies;
        private CharacterGroup enemies;

        #region PUBLIC

        /// <summary> Initialize AI with team info. </summary>
        public void Initialize(Character character, CharacterGroup allies, CharacterGroup enemies)
        {
            this.self = character;
            this.allies = allies;
            this.enemies = enemies;
        }

        /// <summary> Process Character's Turn. </summary>
        public void Process()
        {
            // TODO: AI
            // currently just running secondary and primary action as available
            while (!self.Stats.Dead && allies.Active && enemies.Active)
            {
                if (self.CanPerformAction(self.Secondary))
                    self.PerformAction(self.Secondary, GetTarget(self.Secondary));
                else if (self.CanPerformAction(self.Primary))
                    self.PerformAction(self.Primary, GetTarget(self.Primary));
                else break;
            }
        }

        #endregion

        #region PRIVATE

        private Character GetTarget(Action action)
        {
            switch (action)
            {
                case Attack attack:
                    return RandomCharacter(enemies);
                case Regen regen:
                    return RandomCharacter(allies);
                case Defend defend:
                    return self;
                case Movement movement:
                    return self;
                default:
                    return null;
            }
        }

        private Character RandomCharacter(CharacterGroup group)
        {
            List<Character> living = new List<Character>(group.Characters);
            living.RemoveAll(c => c.Stats.Dead);
            if (living.Count <= 0) return null;
            return living[Random.Range(0, living.Count)];
        }

        #endregion
    }
}
