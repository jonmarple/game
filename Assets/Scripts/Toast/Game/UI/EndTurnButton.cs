using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Toast.Game.Combat;

namespace Toast.Game.UI
{
    /// <summary>
    /// Enables/Disables Button based on Selected Character conditions.
    /// </summary>
    public class EndTurnButton : MonoBehaviour
    {
        /* Serialized Field */
        [SerializeField] private Button button;

        private void OnEnable()
        {
            CombatFlow.TurnStart += Refresh;
            CombatFlow.TurnFinish += Refresh;
        }

        private void OnDisable()
        {
            CombatFlow.TurnStart -= Refresh;
            CombatFlow.TurnFinish -= Refresh;
        }

        #region PUBLIC

        public void Refresh()
        {
            button.interactable = CombatFlow.CurrentCharacter != null &&
                                  CombatFlow.CurrentCharacter.AI == null;
        }

        #endregion
    }
}
