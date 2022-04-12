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
    public class InitiativeCardController : MonoBehaviour
    {
        /* Public Fields */
        public Character Character { get; private set; }

        /* Serialized Fields */
        [SerializeField] private Color factionAColor;
        [SerializeField] private Color factionBColor;
        [SerializeField] private Image factionOutline;
        [SerializeField] private TextMeshProUGUI nameField;
        [SerializeField] private TextMeshProUGUI hpField;
        [SerializeField] private TextMeshProUGUI paField;
        [SerializeField] private TextMeshProUGUI maField;
        [SerializeField] private TextMeshProUGUI apField;
        [SerializeField] private RectTransform container;
        [SerializeField] private Animator animator;
        [SerializeField] private RectLerp lerp;

        private void Update()
        {
            animator?.SetBool("Selected", Character.Selected);
            animator?.SetBool("Hovered", Character.Hovered);
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

        /// <summary> Select Character. </summary>
        public void Refresh()
        {
            hpField.SetText(string.Format("{0,3} / {1,-3}", Character.Stats.HP, Character.Stats.HPMax));
            paField.SetText(string.Format("{0,3} / {1,-3}", Character.Equipment.Armor.Physical, Character.Equipment.Armor.PhysicalMax));
            maField.SetText(string.Format("{0,3} / {1,-3}", Character.Equipment.Armor.Magical, Character.Equipment.Armor.MagicalMax));
            apField.SetText(string.Format("{0,3} / {1,-3}", Character.Stats.AP, Character.Stats.APMax));
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
