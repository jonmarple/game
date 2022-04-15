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

        private void Awake()
        {
            ActionHelper.SelectUpdated += Refresh;
            CharacterSelector.SelectUpdated += UpdateAction;
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
        }

        #endregion
    }
}
