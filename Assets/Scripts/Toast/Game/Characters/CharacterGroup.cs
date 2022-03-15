using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Toast.Game.Characters
{
    /// <summary>
    /// List of Characters.
    /// </summary>
    public class CharacterGroup
    {
        /* Public Fields */
        public List<Character> Characters { get; private set; }

        public CharacterGroup(List<Character> characters)
        { Characters = characters; }

        public CharacterGroup(CharacterGroupData data)
        {
            Characters = new List<Character>();
            foreach (CharacterData character in data.Characters)
                Characters.Add(character.Generate());
        }
    }
}
