using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Toast.Game.Characters
{
    /// <summary>
    /// Data container of a list of Characters.
    /// </summary>
    [CreateAssetMenu(fileName = "Character Group", menuName = "Toast/Game/Characters/Character Group")]
    public class CharacterGroupData : ScriptableObject
    {
        /* Public Fields */
        public List<CharacterData> Characters { get { return characters; } }

        /* Serialized Fields */
        [SerializeField] private List<CharacterData> characters;
    }
}
