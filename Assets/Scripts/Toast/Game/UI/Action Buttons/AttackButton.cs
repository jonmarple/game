using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Toast.Game.Actions;
using Toast.Game.Characters;

namespace Toast.Game.UI
{
    public enum AttackSource
    {
        PRIMARY_ATTACK,
        SECONDARY_ATTACK
    }

    /// <summary>
    /// Attack toggle button.
    /// </summary>
    public class AttackButton : ActionButton
    {
        /* Serialized Fields */
        [Header("Attack Info")]
        [SerializeField] private AttackSource source;
        [SerializeField] private InfoPanel info;

        private void OnEnable()
        {
            ActionHelper.SelectUpdated += Refresh;
            CharacterSelector.SelectUpdated += UpdateAction;
        }

        private void OnDisable()
        {
            ActionHelper.SelectUpdated -= Refresh;
            CharacterSelector.SelectUpdated -= UpdateAction;
        }

        #region PRIVATE

        /// <summary> Update button's action. </summary>
        private void UpdateAction()
        {
            switch (source)
            {
                case AttackSource.PRIMARY_ATTACK:
                    SetAction(CharacterSelector.SelectedCharacter?.Equipment?.Weapon?.Primary);
                    break;
                case AttackSource.SECONDARY_ATTACK:
                    SetAction(CharacterSelector.SelectedCharacter?.Equipment?.Weapon?.Secondary);
                    break;
                default:
                    SetAction(null);
                    break;
            }

            switch (action)
            {
                case Attack attack:
                    info?.SetText(string.Format("{0}\n   P:\t{1}\n   M:\t{2}", attack.ActionName,
                                    CharacterSelector.SelectedCharacter?.Equipment?.Weapon?.Physical.Scale(attack.Modifier),
                                    CharacterSelector.SelectedCharacter?.Equipment?.Weapon?.Magical.Scale(attack.Modifier)));
                    break;
                case Regen regen:
                    info?.SetText(string.Format("{0}\n   P:\t{1}\n   M:\t{2}", regen.ActionName,
                                    CharacterSelector.SelectedCharacter?.Equipment?.Weapon?.Physical.Scale(regen.Modifier),
                                    CharacterSelector.SelectedCharacter?.Equipment?.Weapon?.Magical.Scale(regen.Modifier)));
                    break;
            }
        }

        #endregion
    }
}
