using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Toast.Game.Actions
{
    /// <summary>
    /// Type of movement.
    /// </summary>
    public enum MovementType
    {
        FOUR,
        EIGHT
    }

    /// <summary>
    /// Data container for movement action information.
    /// </summary>
    [CreateAssetMenu(fileName = "Movement", menuName = "Toast/Game/Actions/Movement")]
    public class MovementActionData : ActionData
    {
        /* Public Fields */

        /* Serialized Fields */
        [SerializeField] private MovementType movementType;

        /* Private Fields */

        #region PUBLIC
        #endregion

        #region PRIVATE
        #endregion
    }
}
