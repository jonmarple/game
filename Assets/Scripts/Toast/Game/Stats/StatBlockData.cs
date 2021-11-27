using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityAtoms.BaseAtoms;

namespace Toast.Game.Stats
{
    /// <summary>
    /// Data container for stat information.
    /// </summary>
    [CreateAssetMenu(fileName = "Stat Block Data", menuName = "Toast/Game/Stats/Stat Block Data")]
    public class StatBlockData : ScriptableObject
    {
        /* Public Fields */

        /* Serialized Fields */
        [SerializeField] private IntReference hp;
        [SerializeField] private IntReference hpMax;
        [SerializeField] private IntReference ap;
        [SerializeField] private IntReference apMax;

        /* Private Fields */

        #region PUBLIC

        /// <summary>
        /// Generate StatBlock object.
        /// </summary>
        public StatBlock GenerateStatBlock()
        {
            return new StatBlock(hp, hpMax, ap, apMax);
        }

        #endregion

        #region PRIVATE
        #endregion
    }
}
