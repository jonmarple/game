using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using TMPro;
using Toast.Game.Actions;
using Toast.Game.Characters;
using Toast.Audio;

namespace Toast.Game.UI
{
    /// <summary>
    /// Action toggle button.
    /// </summary>
    public abstract class ActionButton : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
    {
        /* Serialized Fields */
        [Header("Components")]
        [SerializeField] protected Button button;
        [SerializeField] protected Outline outline;
        [SerializeField] protected TextMeshProUGUI label;
        [SerializeField] protected InfoPanel info;

        [Header("Status Image")]
        [SerializeField] protected Image status;
        [SerializeField] protected Sprite cooldown;

        /* Private Fields */
        protected Action action;
        private bool active = false;
        private bool destroying = false;

        private void OnEnable()
        { ActionHelper.SelectUpdated += Refresh; }

        private void OnDisable()
        { ActionHelper.SelectUpdated -= Refresh; }

        #region PUBLIC

        /// <summary> Toggle the associated action. </summary>
        public void ToggleAction()
        {
            if (!active) ActionHelper.Select(action);
            else ActionHelper.Deselect(true);
        }

        /// <summary> Set the associated action. </summary>
        public void SetAction(Action action)
        {
            if (CharacterSelector.SelectedCharacter != null &&
                CharacterSelector.SelectedCharacter.AI == null)
            {
                this.action = action;
                label.text = action?.ActionName ?? "";
            }

            Refresh();
        }

        /// <summary> Refresh the action's state. </summary>
        public virtual void Refresh()
        {
            if (!destroying)
            {
                button.interactable = CharacterSelector.SelectedCharacter != null &&
                                      CharacterSelector.SelectedCharacter.AI == null &&
                                      CharacterSelector.SelectedCharacter.CanPerformAction(action);
                active = button.interactable && action == ActionHelper.SelectedAction;
                outline.enabled = active;
                if (action != null && action.CooldownCounter > 0)
                {
                    status.sprite = cooldown;
                    status.CrossFadeAlpha(1f, 0f, true);
                }
                else
                {
                    status.CrossFadeAlpha(0f, 0f, true);
                    status.sprite = null;
                }
            }
        }

        /// <summary> Destroy controller. </summary>
        public void Destroy()
        {
            destroying = true;
            Destroy(gameObject);
        }

        public void OnPointerEnter(PointerEventData data)
        { OnHover(true); }

        public void OnPointerExit(PointerEventData data)
        { OnHover(false); }

        #endregion

        #region PRIVATE

        protected virtual void OnHover(bool active)
        {
            if (button.interactable) ActionHelper.Hover(active, action);
            info?.SetActive(active);
        }

        #endregion
    }
}
