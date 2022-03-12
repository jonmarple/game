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
    public class AttackActionData : ActionData<Attack>
    {
        /* Serialized Fields */
        [SerializeField] private IntReference damageModifier;

        #region PUBLIC

        public override Attack Generate()
        { return new Attack(actionName, cost, damageModifier); }

        #endregion
    }
}