using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Toast.Game.Actions;
using Toast.Game.Characters;
using Toast.Utility;

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
                bool didPerformSecondary = PerformAction(self.Secondary);
                bool didPerformPrimary = false;
                if (!didPerformSecondary) didPerformPrimary = PerformAction(self.Primary);
                if (!didPerformPrimary && !didPerformSecondary) break;
            }
        }

        #endregion

        #region PRIVATE

        private Character GetTarget(Action action)
        {
            switch (action)
            {
                case Attack attack:
                    return WeakestCharacter(enemies);
                case Regen regen:
                    return RandomCharacterRequiringHealing(allies);
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

        private Character RandomCharacterRequiringHealing(CharacterGroup group)
        {
            List<Character> charactersRequiringHealing = new List<Character>();
            foreach (Character character in group.Characters)
                if (!character.Stats.Dead && character.Stats.HP <= character.Stats.HPMax / 2)
                    charactersRequiringHealing.Add(character);
            charactersRequiringHealing.Shuffle();
            return charactersRequiringHealing.Count > 0 ? charactersRequiringHealing[0] : null;
        }

        private Character WeakestCharacter(CharacterGroup group)
        {
            List<Character> sortedCharacters = new List<Character>(group.Characters);
            sortedCharacters.RemoveAll(character => character.Stats.Dead);
            sortedCharacters.Sort((char1, char2) => char1.Stats.HP.CompareTo(char2.Stats.HP));
            return sortedCharacters.Count > 0 ? sortedCharacters[0] : null;
        }

        private bool PerformAction(Action action)
        {
            bool didPerform = false;
            if (self.CanPerformAction(action))
            {
                if (action is Regen)
                {
                    if (RandomCharacterRequiringHealing(allies) != null)
                        didPerform = self.PerformAction(action, GetTarget(action));
                }
                else if (action is Attack)
                {
                    if (WeakestCharacter(enemies) != null)
                        didPerform = self.PerformAction(action, GetTarget(action));
                }
                else didPerform = self.PerformAction(action, GetTarget(action));
            }
            return didPerform;
        }

        #endregion
    }
}
