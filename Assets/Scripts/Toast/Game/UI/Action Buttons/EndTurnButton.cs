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
            CombatFlow.CombatStart += Refresh;
            CombatFlow.CombatFinish += Refresh;
            CombatFlow.TurnStart += Refresh;
            CombatFlow.TurnFinish += Refresh;
        }

        private void OnDisable()
        {
            CombatFlow.CombatStart -= Refresh;
            CombatFlow.CombatFinish -= Refresh;
            CombatFlow.TurnStart -= Refresh;
            CombatFlow.TurnFinish -= Refresh;
        }

        #region PUBLIC

        public void Refresh()
        {
            button.interactable = CombatFlow.Active && !CombatFlow.Finished &&
                                  CombatFlow.CurrentCharacter != null &&
                                  CombatFlow.CurrentCharacter.AI == null;
        }

        #endregion
    }
}
