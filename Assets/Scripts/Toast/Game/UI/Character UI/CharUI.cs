using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Toast.UI;
using Toast.Game.Characters;
using Toast.Game.Combat;

namespace Toast.Game.UI
{
    /// <summary>
    /// Character UI controller.
    /// </summary>
    public class CharUI : MonoBehaviour
    {
        /* Serialized Fields */
        [SerializeField] private FillBar hpBar;
        [SerializeField] private FillBar apBar;
        [SerializeField] private FillBar amBar;
        [SerializeField] private Image pMod;
        [SerializeField] private Image mMod;
        [SerializeField] private Color resistantColor;
        [SerializeField] private Color weak;

        /* Private Fields */
        private Character character;

        private void OnEnable()
        { SetCharListeners(true); }

        private void OnDisable()
        { SetCharListeners(false); }

        #region PUBLIC

        /// <summary> Register associated character. </summary>
        public void Register(Character character)
        {
            SetCharListeners(false);
            this.character = character;
            RefreshModifiers();
            SetCharListeners(true);
            Refresh();
        }

        /// <summary> Refresh UI. </summary>
        public void Refresh()
        {
            hpBar.SetFill(character.Stats.HP, character.Stats.HPMax);
            apBar.SetFill(character.Equipment.Armor.Physical, character.Equipment.Armor.PhysicalMax);
            amBar.SetFill(character.Equipment.Armor.Magical, character.Equipment.Armor.MagicalMax);
        }

        /// <summary> Refresh UI Modifiers. </summary>
        public void RefreshModifiers()
        {
            RefreshModifier(pMod, character.Stats.PhysicalMod);
            RefreshModifier(mMod, character.Stats.MagicalMod);
        }

        #endregion

        #region PRIVATE

        private void SetCharListeners(bool active)
        {
            if (character != null)
            {
                if (active)
                {
                    character.Stats.ValueUpdated += Refresh;
                    character.Equipment.Armor.ValueUpdated += Refresh;
                }
                else
                {
                    character.Stats.ValueUpdated -= Refresh;
                    character.Equipment.Armor.ValueUpdated -= Refresh;
                }
            }
        }

        private void RefreshModifier(Image image, ModifierLevel modifier)
        {
            switch (modifier)
            {
                case ModifierLevel.NONE:
                    image.enabled = false;
                    break;
                case ModifierLevel.RESISTANT:
                    image.color = resistantColor;
                    image.enabled = true;
                    break;
                case ModifierLevel.WEAK:
                    image.color = weak;
                    image.enabled = true;
                    break;
            }
        }

        #endregion
    }
}
