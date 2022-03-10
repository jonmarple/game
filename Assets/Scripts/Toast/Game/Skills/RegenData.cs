using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityAtoms.BaseAtoms;

namespace Toast.Game.Skills
{
    /// <summary>
    /// Type of regenerative skill.
    /// Regenerate HP or AP.
    /// </summary>
    public enum RegenType
    {
        HP,
        AP
    }

    /// <summary>
    /// Data container for regenerative skill information.
    /// </summary>
    [CreateAssetMenu(fileName = "Regen", menuName = "Toast/Game/Skills/Regen")]
    public class RegenData : WeaponSkillData
    {
        /* Public Fields */

        /* Serialized Fields */
        [SerializeField] private IntReference regenModifier;
        [SerializeField] private RegenType regenType;

        /* Private Fields */

        #region PUBLIC
        #endregion

        #region PRIVATE
        #endregion
    }
}
