using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityAtoms.BaseAtoms;
using Toast.Game.Stats;
using Toast.Game.Items;

namespace Toast.Game.Characters
{
    /// <summary>
    /// Data container for character information.
    /// </summary>
    [CreateAssetMenu(fileName = "Character Data", menuName = "Toast/Game/Characters/Character Data")]
    public class CharacterData : ScriptableObject
    {
        /* Public Fields */
        public string CharacterName { get { return characterName; } }

        /* Serialized Fields */
        [SerializeField] private StringReference characterName;
        [SerializeField] private StatBlockData statBlockData;
        [SerializeField] private EquipmentData equipmentData;

        /* Private Fields */

        #region PUBLIC

        /// <summary> Generate StatBlock object based on character's StatBlockData. </summary>
        public StatBlock GenerateStatBlock()
        { return statBlockData.GenerateStatBlock(); }

        /// <summary> Generates Equipment object based on character's EquipmentData. </summary>
        public Equipment GenerateEquipment()
        { return equipmentData.GenerateEquipment(); }

        #endregion

        #region PRIVATE
        #endregion
    }
}
