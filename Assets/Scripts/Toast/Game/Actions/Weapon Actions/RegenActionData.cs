using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityAtoms.BaseAtoms;

namespace Toast.Game.Actions
{
    /// <summary>
    /// Type of regenerative action.
    /// Regenerate HP or AP.
    /// </summary>
    public enum RegenType
    {
        HP,
        AP
    }

    /// <summary>
    /// Data container for regenerative action information.
    /// </summary>
    [CreateAssetMenu(fileName = "Regen", menuName = "Toast/Game/Actions/Regen")]
    public class RegenActionData : WeaponActionData
    {
        /* Public Fields */
        public int Modifier { get { return regenModifier; } }
        public RegenType Type { get { return regenType; } }

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
