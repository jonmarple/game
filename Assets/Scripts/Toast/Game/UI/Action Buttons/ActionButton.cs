using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Toast.Game.Actions;
using Toast.Game.Characters;

namespace Toast.Game.UI
{
    public enum ActionSource
    {
        PRIMARY_ATTACK,
        SECONDARY_ATTACK
    }

    /// <summary>
    /// Action toggle button.
    /// </summary>
    [RequireComponent(typeof(Toggle))]
    public class ActionButton : MonoBehaviour
    {
        /* Serialized Fields */
        [SerializeField] private ActionSource source;
        [SerializeField] private Toggle toggle;
        [SerializeField] private Outline outline;
        [SerializeField] private TextMeshProUGUI label;

        /* Private Fields */
        private Action action;

        private void Awake()
        {
            CharacterSelector.SelectUpdated += UpdateAction;
            ActionHelper.SelectUpdated += Refresh;
        }

        #region PUBLIC

        /// <summary> Toggle button's action. </summary>
        public void SetToggle(bool active)
        {
            if (active) ActionHelper.Select(action);
            else ActionHelper.Deselect();
        }

        /// <summary> Refresh toggle and outline state. </summary>
        public void Refresh()
        { StartCoroutine(HandleRefresh(action == ActionHelper.SelectedAction)); }

        /// <summary> Set button's action. </summary>
        public void SetAction(Action action)
        {
            this.action = action;
            label.text = action?.ActionName ?? "";
        }

        /// <summary> Update button's action. </summary>
        public void UpdateAction()
        {
            switch (source)
            {
                case ActionSource.PRIMARY_ATTACK:
                    SetAction(CharacterSelector.SelectedCharacter?.Equipment?.Weapon?.Primary);
                    break;
                case ActionSource.SECONDARY_ATTACK:
                    SetAction(CharacterSelector.SelectedCharacter?.Equipment?.Weapon?.Secondary);
                    break;
                default:
                    SetAction(null);
                    break;
            }

            Refresh();
        }

        #endregion

        #region PRIVATE

        private IEnumerator HandleRefresh(bool active)
        {
            toggle.interactable = CharacterSelector.SelectedCharacter != null &&
                                  CharacterSelector.SelectedCharacter.Active &&
                                  CharacterSelector.SelectedCharacter.AI == null;
            if (!toggle.interactable) SetAction(null);
            yield return null;
            toggle.isOn = active && toggle.interactable;
        }

        #endregion
    }
}
