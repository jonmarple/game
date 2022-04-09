using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using Toast.Game.Combat;

namespace Toast.Game.Utility
{
    /// <summary>
    /// Runs UnityEvent based on whether Current Character has an AI.
    /// </summary>
    public class AIChecker : MonoBehaviour
    {
        /* Serialized Field */
        [SerializeField] private UnityEvent active;
        [SerializeField] private UnityEvent inactive;

        #region PUBLIC

        public void Invoke()
        {
            if (CombatFlow.Active)
            {
                if (CombatFlow.CurrentCharacter.AI != null)
                    active.Invoke();
                else
                    inactive.Invoke();
            }
        }

        #endregion
    }
}
