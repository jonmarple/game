using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityAtoms.BaseAtoms;

namespace Toast.Game.Skills
{
    /// <summary>
    /// Data container for attack skill information.
    /// </summary>
    [CreateAssetMenu(fileName = "Attack", menuName = "Toast/Game/Skills/Attack")]
    public class AttackData : WeaponSkillData
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
