using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Toast.Game.Stats;
using Toast.Game.Items;

namespace Toast.Game.Characters
{
    /// <summary>
    /// Main interface for interacting with character GameObjects.
    /// </summary>
    public class CController : MonoBehaviour
    {
        /* Public Fields */

        /* Serialized Fields */

        /* Private Fields */
        private CharacterData data;
        private StatBlock statBlock;
        private Equipment equipment;

        #region PUBLIC

        /// <summary>
        /// Initialize controller with character data.
        /// </summary>
        public void Initialize(CharacterData data)
        {
            this.data = data;
            statBlock = data.GenerateStatBlock();
            equipment = data.GenerateEquipment();
        }

        #endregion

        #region PRIVATE
        #endregion
    }
}
