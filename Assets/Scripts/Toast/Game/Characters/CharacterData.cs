using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityAtoms.BaseAtoms;
using Toast.Game.Stats;
using Toast.Game.Items;
using Toast.Game.Actions;
using Toast.Game.AI;

namespace Toast.Game.Characters
{
    /// <summary>
    /// Data container for character information.
    /// </summary>
    [CreateAssetMenu(fileName = "Character", menuName = "Toast/Game/Characters/Character")]
    public class CharacterData : ScriptableObject, IData<Character>
    {
        /* Public Fields */
        public string CharacterName { get { return characterName; } }
        public MovementActionData Movement { get { return movementData; } }
        public DefendActionData Defend { get { return defendData; } }
        public StatBlockData StatBlock { get { return statBlockData; } }
        public EquipmentData Equipment { get { return equipmentData; } }
        public CharacterAIData AI { get { return characterAIData; } }

        /* Serialized Fields */
        [SerializeField] private StringReference characterName;
        [SerializeField] private MovementActionData movementData;
        [SerializeField] private DefendActionData defendData;
        [SerializeField] private StatBlockData statBlockData;
        [SerializeField] private EquipmentData equipmentData;
        [SerializeField] private CharacterAIData characterAIData;

        #region PUBLIC

        public Character Generate()
        { return new Character(this); }

        #endregion
    }
}
