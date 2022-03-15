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
        // TODO: save copies of character primary, secondary, defend, move actions for ease of access

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
            Debug.Log(self.CharacterName + " processing turn...");
            // TODO: AI!!
        }

        #endregion

        #region PRIVATE
        #endregion
    }
}
