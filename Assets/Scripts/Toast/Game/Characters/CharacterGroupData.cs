using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Toast.Game.AI;

namespace Toast.Game.Characters
{
    /// <summary>
    /// Data container of a list of Characters.
    /// </summary>
    [CreateAssetMenu(fileName = "Character Group", menuName = "Toast/Game/Characters/Character Group")]
    public class CharacterGroupData : ScriptableObject, IData<CharacterGroup>
    {
        /* Public Fields */
        public Faction Faction { get { return faction; } }
        public List<CharacterData> Characters { get { return characters; } }

        /* Serialized Fields */
        [SerializeField] private Faction faction;
        [SerializeField] private List<CharacterData> characters;

        #region PUBLIC

        public CharacterGroup Generate()
        { return new CharacterGroup(this); }

        public void ApplyAI(CharacterAIData ai)
        {
            foreach (CharacterData character in Characters)
                character.ApplyAI(ai);
        }

        #endregion
    }
}
