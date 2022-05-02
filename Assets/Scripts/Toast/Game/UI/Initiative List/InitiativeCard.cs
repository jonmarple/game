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
    /// Controller for an Initiative Card.
    /// </summary>
    public class InitiativeCard : MonoBehaviour
    {
        /* Public Fields */
        public Character Character { get; private set; }

        /* Serialized Fields */
        [SerializeField] private Color factionAColor;
        [SerializeField] private Color factionBColor;
        [SerializeField] private Image factionOutline;
        [SerializeField] private TextMeshProUGUI nameField;
        [SerializeField] private FillBar hpBar;
        [SerializeField] private FillBar apBar;
        [SerializeField] private FillBar amBar;
        [SerializeField] private Image pMod;
        [SerializeField] private Image mMod;
        [SerializeField] private Color resistantColor;
        [SerializeField] private Color weakColor;
        [SerializeField] private RectTransform container;
        [SerializeField] private Animator animator;
        [SerializeField] private RectLerp lerp;
        [SerializeField] private InfoPanel info;

        private void Update()
        {
            animator?.SetBool("Selected", Character.Selected);
            animator?.SetBool("Hovered", Character.Hovered);
        }

        private void OnEnable()
        {
            if (Character != null)
            {
                Character.Stats.ValueUpdated += Refresh;
                Character.Equipment.Armor.ValueUpdated += Refresh;
            }
        }

        private void OnDisable()
        {
            if (Character != null)
            {
                Character.Stats.ValueUpdated -= Refresh;
                Character.Equipment.Armor.ValueUpdated -= Refresh;
            }
        }

        #region PUBLIC

        /// <summary> Initialize card with character info. </summary>
        public void Initialize(Character character, Faction faction, RectTransform target)
        {
            Character = character;
            nameField.text = Character.CharacterName;
            factionOutline.color = faction == Faction.A ? factionAColor : factionBColor;
            lerp.SetTarget(target);
            character.Stats.ValueUpdated += Refresh;
            character.Equipment.Armor.ValueUpdated += Refresh;
            Refresh();
            RefreshModifiers();
        }

        /// <summary> Refresh card info. </summary>
        public void Refresh()
        {
            hpBar.SetFill(Character.Stats.HP, Character.Stats.HPMax);
            apBar.SetFill(Character.Equipment.Armor.Physical, Character.Equipment.Armor.PhysicalMax);
            amBar.SetFill(Character.Equipment.Armor.Magical, Character.Equipment.Armor.MagicalMax);
            info.SetText(string.Format("{0}\nHP: {1}/{2}\nAP: {3}/{4}\nP: {5}\nM: {6}\n\n{7}\nP: {8}/{9}\nM: {10}/{11}\n\n{12}\nP: {13}\nM: {14}",
                        Character.CharacterName, Character.Stats.HP, Character.Stats.HPMax, Character.Stats.AP, Character.Stats.APMax, Character.Stats.PhysicalMod, Character.Stats.MagicalMod,
                        Character.Equipment.Armor.ItemName, Character.Equipment.Armor.Physical, Character.Equipment.Armor.PhysicalMax, Character.Equipment.Armor.Magical, Character.Equipment.Armor.MagicalMax,
                        Character.Equipment.Weapon.ItemName, Character.Equipment.Weapon.Physical.ToString(), Character.Equipment.Weapon.Magical.ToString()));
        }

        /// <summary> Refresh UI Modifiers. </summary>
        public void RefreshModifiers()
        {
            RefreshModifier(pMod, Character.Stats.PhysicalMod);
            RefreshModifier(mMod, Character.Stats.MagicalMod);
        }

        /// <summary> Hover Character. </summary>
        public void Hover(bool active)
        { CharacterSelector.Hover(active, Character); }

        /// <summary> Select Character. </summary>
        public void Select()
        { CharacterSelector.ToggleSelect(Character); }

        /// <summary> Show Card. </summary>
        public void Show()
        { container.gameObject.SetActive(true); }

        /// <summary> Hide Card. </summary>
        public void Hide()
        { container.gameObject.SetActive(false); }

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
