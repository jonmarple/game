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
        public Faction Faction;
        public bool Active
        {
            get
            {
                bool active = false;
                foreach (Character character in Characters)
                    if (!character.Stats.Dead)
                        active = true;
                return active;
            }
        }

        public CharacterGroup(Faction faction, List<Character> characters)
        {
            Faction = faction;
            Characters = characters;
            foreach (Character character in Characters)
                character.SetFaction(Faction);
        }

        public CharacterGroup(CharacterGroupData data)
        {
            Faction = data.Faction;
            Characters = new List<Character>();
            foreach (CharacterData character in data.Characters)
                Characters.Add(character.Generate());
            foreach (Character character in Characters)
                character.SetFaction(Faction);
        }
    }
}
