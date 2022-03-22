using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityAtoms.BaseAtoms;

namespace Toast.Game.Actions
{
    /// <summary>
    /// Data container for regenerative action information.
    /// </summary>
    [CreateAssetMenu(fileName = "Regen", menuName = "Toast/Game/Actions/Regen")]
    public class RegenActionData : ActionData
    {
        /* Serialized Fields */
        [SerializeField] private IntReference regenModifier;

        #region PUBLIC

        public override Action Generate()
        { return new Regen(actionName, cost, regenModifier); }

        #endregion
    }
}
