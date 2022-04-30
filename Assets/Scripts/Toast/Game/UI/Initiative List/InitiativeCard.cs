using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Toast.Game.Characters;
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
        [SerializeField] private RectTransform container;
        [SerializeField] private Animator animator;
        [SerializeField] private RectLerp lerp;

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
        }

        /// <summary> Refresh card info. </summary>
        public void Refresh()
        {
            hpBar.SetFill(Character.Stats.HP, Character.Stats.HPMax);
            apBar.SetFill(Character.Equipment.Armor.Physical, Character.Equipment.Armor.PhysicalMax);
            amBar.SetFill(Character.Equipment.Armor.Magical, Character.Equipment.Armor.MagicalMax);
        }

        /// <summary> Show Card. </summary>
        public void Show()
        { container.gameObject.SetActive(true); }

        /// <summary> Hide Card. </summary>
        public void Hide()
        { container.gameObject.SetActive(false); }

        /// <summary> Hover Character. </summary>
        public void Hover(bool active)
        { CharacterSelector.Hover(active, Character); }

        /// <summary> Select Character. </summary>
        public void Select()
        { CharacterSelector.ToggleSelect(Character); }

        #endregion
    }
}
