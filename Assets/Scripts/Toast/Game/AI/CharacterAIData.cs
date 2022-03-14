using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Toast.Game.AI
{
    /// <summary>
    /// Data container for character AI module information.
    /// </summary>
    [CreateAssetMenu(fileName = "Character AI", menuName = "Toast/Game/AI/Character AI")]
    public class CharacterAIData : ScriptableObject
    {
        #region PUBLIC

        public CharacterAI Generate()
        { return new CharacterAI(); }

        #endregion
    }
}
