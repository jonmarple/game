using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Toast.Audio;

namespace Toast.Game.Actions
{
    /// <summary>
    /// Data container for movement action information.
    /// </summary>
    [CreateAssetMenu(fileName = "Movement", menuName = "Toast/Game/Actions/Movement")]
    public class MovementActionData : ActionData
    {
        /* Serialized Fields */
        [SerializeField] private MovementType movementType;

        #region PUBLIC

        public override Action Generate()
        { return new Movement(actionName, cost, cooldown, movementType, audio); }

        #endregion
    }
}
