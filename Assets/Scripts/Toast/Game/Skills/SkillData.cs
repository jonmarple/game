using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityAtoms.BaseAtoms;

namespace Toast.Game.Skills
{
    /// <summary>
    /// Abstract data container for skill information.
    /// </summary>
    public abstract class SkillData : ScriptableObject
    {
        /* Public Fields */

        /* Serialized Fields */
        [SerializeField] protected StringReference skillName;

        /* Private Fields */

        #region PUBLIC
        #endregion

        #region PRIVATE
        #endregion
    }
}
