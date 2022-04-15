using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Toast.Game.Actions;
using Toast.Game.Characters;

namespace Toast.Game.UI
{
    /// <summary>
    /// Action toggle button.
    /// </summary>
    public abstract class ActionButton : MonoBehaviour
    {
        /* Serialized Fields */
        [Header("Components")]
        [SerializeField] private Button button;
        [SerializeField] private Outline outline;
        [SerializeField] private TextMeshProUGUI label;

        /* Private Fields */
        private Action action;
        private bool active = false;

        private void Awake()
        { ActionHelper.SelectUpdated += Refresh; }

        #region PUBLIC

        /// <summary> Toggle the associated action. </summary>
        public void ToggleAction()
        {
            if (!active) ActionHelper.Select(action);
            else ActionHelper.Deselect();
        }

        /// <summary> Set the associated action. </summary>
        public void SetAction(Action action)
        {
            this.action = action;
            label.text = action?.ActionName ?? "";

            Refresh();
        }

        /// <summary> Refresh the action's state. </summary>
        public void Refresh()
        {
            button.interactable = CharacterSelector.SelectedCharacter != null &&
                                  CharacterSelector.SelectedCharacter.Active &&
                                  CharacterSelector.SelectedCharacter.AI == null &&
                                  CharacterSelector.SelectedCharacter.HasAction(action);
            active = button.interactable && action == ActionHelper.SelectedAction;
            outline.enabled = active;
        }

        #endregion
    }
}
