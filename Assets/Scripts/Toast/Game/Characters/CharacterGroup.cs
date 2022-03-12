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
        public List<CharacterData> Characters { get; private set; }

        public CharacterGroup(List<CharacterData> characters)
        { Characters = characters; }
    }
}
