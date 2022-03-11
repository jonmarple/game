using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityAtoms.BaseAtoms;

namespace Toast.Game.Actions
{
    /// <summary>
    /// Data container for defense action information.
    /// </summary>
    [CreateAssetMenu(fileName = "Defend", menuName = "Toast/Game/Actions/Defend")]
    public class DefendActionData : ActionData
    {
        /* Public Fields */
        public int Modifier { get { return defenseModifier; } }

        /* Serialized Fields */
        [SerializeField] private IntReference defenseModifier;

        /* Private Fields */

        #region PUBLIC
        #endregion

        #region PRIVATE
        #endregion
    }
}
