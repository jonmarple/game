using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Toast.Game.Actions;
using Toast.Game.Characters;
using Toast.Game.Combat;

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
        private System.Action postProcessCallback;

        #region PUBLIC

        /// <summary> Initialize AI with team info. </summary>
        public void Initialize(Character character, CharacterGroup allies, CharacterGroup enemies)
        {
            this.self = character;
            this.allies = allies;
            this.enemies = enemies;
            this.postProcessCallback = self.PostProcessCallback;
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

            postProcessCallback.Invoke();
        }

        #endregion

        #region PRIVATE

        private Character CharRequiringHP(CharacterGroup group)
        {
            Character character = CharWithLowestHP(group);
            if (character != null && character.Stats.HP <= character.Stats.HPMax / 2)
                return character;
            return null;
        }

        private Character CharWithLowestHP(CharacterGroup group)
        { return TopCharFromSort(group.Characters, (char1, char2) => char1.Stats.HP.CompareTo(char2.Stats.HP), true); }

        private Character TopCharFromSort(List<Character> characters, System.Comparison<Character> comparison, bool ignoreDead)
        {
            List<Character> sortedCharacters = new List<Character>(characters);
            if (ignoreDead) sortedCharacters.RemoveAll(character => character.Stats.Dead);
            sortedCharacters.Sort(comparison);
            return sortedCharacters.Count > 0 ? sortedCharacters[0] : null;
        }

        private bool PerformAction(Action action)
        {
            bool didPerform = false;
            if (self.CanPerformAction(action))
            {
                switch (action)
                {
                    case Attack attack:
                        if (CharWithLowestHP(enemies) != null)
                            didPerform = self.PerformAction(action, CharWithLowestHP(enemies));
                        return didPerform;
                    case Regen regen:
                        if (CharRequiringHP(allies) != null)
                            didPerform = self.PerformAction(action, CharRequiringHP(allies));
                        return didPerform;
                    default:
                        return didPerform;
                }
            }
            return didPerform;
        }

        #endregion
    }
}
