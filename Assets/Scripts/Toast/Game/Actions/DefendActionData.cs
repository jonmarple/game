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
    public class DefendActionData : ActionData<Defend>
    {
        /* Serialized Fields */
        [SerializeField] private IntReference defenseModifier;

        #region PUBLIC

        public override Defend Generate()
        { return new Defend(actionName, cost, defenseModifier); }

        #endregion
    }
}
