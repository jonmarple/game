using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Toast.Game.Actions
{
    /// <summary>
    /// Data container for movement action information.
    /// </summary>
    [CreateAssetMenu(fileName = "Movement", menuName = "Toast/Game/Actions/Movement")]
    public class MovementActionData : ActionData<Movement>
    {
        /* Serialized Fields */
        [SerializeField] private MovementType movementType;

        #region PUBLIC

        public override Movement Generate()
        { return new Movement(actionName, cost, movementType); }

        #endregion
    }
}
