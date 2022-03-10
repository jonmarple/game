using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityAtoms.BaseAtoms;

namespace Toast.Game.Actions
{
    /// <summary>
    /// Data container for attack action information.
    /// </summary>
    [CreateAssetMenu(fileName = "Attack", menuName = "Toast/Game/Actions/Attack")]
    public class AttackActionData : WeaponActionData
    {
        /* Public Fields */

        /* Serialized Fields */
        [SerializeField] private IntReference damageModifier;

        /* Private Fields */

        #region PUBLIC
        #endregion

        #region PRIVATE
        #endregion
    }
}
