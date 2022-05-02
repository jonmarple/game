using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Toast.Game.Characters;
using Toast.Game.Combat;
using Toast.UI;

namespace Toast.Game.UI
{
    /// <summary>
    /// Controller for a Party Card.
    /// </summary>
    public class PartyCard : MonoBehaviour
    {
        /* Serialized Fields */
        [SerializeField] private TextMeshProUGUI nameField;
        [SerializeField] private FillBar hpBar;
        [SerializeField] private FillBar apBar;
        [SerializeField] private FillBar amBar;
        [SerializeField] private Image pMod;
        [SerializeField] private Image mMod;
        [SerializeField] private Color resistantColor;
        [SerializeField] private Color weakColor;
        [SerializeField] private InfoPanel info;
        [SerializeField] private Animator animator;

        /* Private Fields */
        private Character character;

        private void Update()
        {
            animator?.SetBool("Selected", character.Selected);
            animator?.SetBool("Hovered", character.Hovered);
        }

        private void OnEnable()
        {
            if (character != null)
            {
                character.Stats.ValueUpdated += Refresh;
                character.Equipment.Armor.ValueUpdated += Refresh;
            }
        }

        private void OnDisable()
        {
            if (character != null)
            {
                character.Stats.ValueUpdated -= Refresh;
                character.Equipment.Armor.ValueUpdated -= Refresh;
            }
        }

        #region PUBLIC

        /// <summary> Initialize card with character info. </summary>
        public void Initialize(Character character)
        {
            this.character = character;
            character.Stats.ValueUpdated += Refresh;
            character.Equipment.Armor.ValueUpdated += Refresh;
            nameField.text = character.CharacterName;
            Refresh();
            RefreshModifiers();
        }

        /// <summary> Refresh card info. </summary>
        public void Refresh()
        {
            hpBar.SetFill(character.Stats.HP, character.Stats.HPMax);
            apBar.SetFill(character.Equipment.Armor.Physical, character.Equipment.Armor.PhysicalMax);
            amBar.SetFill(character.Equipment.Armor.Magical, character.Equipment.Armor.MagicalMax);
            info.SetText(string.Format("{0}\nHP: {1}/{2}\t AP: {3}/{4}\nP: {5}\nM: {6}\n\n{7}\nP: {8}/{9}\t M: {10}/{11}\n\n{12}\nP: {13}\t M: {14}",
                        character.CharacterName, character.Stats.HP, character.Stats.HPMax, character.Stats.AP, character.Stats.APMax, character.Stats.PhysicalMod, character.Stats.MagicalMod,
                        character.Equipment.Armor.ItemName, character.Equipment.Armor.Physical, character.Equipment.Armor.PhysicalMax, character.Equipment.Armor.Magical, character.Equipment.Armor.MagicalMax,
                        character.Equipment.Weapon.ItemName, character.Equipment.Weapon.Physical.ToString(), character.Equipment.Weapon.Magical.ToString()));
        }

        /// <summary> Refresh UI Modifiers. </summary>
        public void RefreshModifiers()
        {
            RefreshModifier(pMod, character.Stats.PhysicalMod);
            RefreshModifier(mMod, character.Stats.MagicalMod);
        }

        /// <summary> Hover Character. </summary>
        public void Hover(bool active)
        { CharacterSelector.Hover(active, character); }

        /// <summary> Select Character. </summary>
        public void Select()
        { CharacterSelector.ToggleSelect(character); }

        #endregion

        #region PRIVATE
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
                    image.color = weakColor;
                    image.enabled = true;
                    break;
            }
        }

        #endregion
    }
}
