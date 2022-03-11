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
    public class RegenActionData : ActionData<Regen>
    {
        /* Serialized Fields */
        [SerializeField] private IntReference regenModifier;
        [SerializeField] private RegenType regenType;

        #region PUBLIC

        public override Regen Generate()
        { return new Regen(actionName, cost, regenModifier, regenType); }

        #endregion
    }
}
