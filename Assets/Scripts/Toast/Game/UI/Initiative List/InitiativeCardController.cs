using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Toast.Game.Characters;

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
        [SerializeField] private Outline selectOutline;
        [SerializeField] private TextMeshProUGUI nameField;

        private void Start()
        { RefreshOutline(); }

        #region PUBLIC

        /// <summary> Initialize card with character info. </summary>
        public void Initialize(Character character, Faction faction)
        {
            Character = character;
            nameField.text = Character.CharacterName;
            factionOutline.color = faction == Faction.A ? factionAColor : factionBColor;
        }

        /// <summary> Refresh card outline. </summary>
        public void RefreshOutline()
        {
            if (Character.Selected)
                SetOutline(1.0f);
            else if (Character.Hovered)
                SetOutline(0.5f);
            else
                SetOutline(0.0f);
        }

        /// <summary> Hover Character. </summary>
        public void Hover(bool active)
        { CharacterSelector.Hover(active, Character); }

        /// <summary> Select Character. </summary>
        public void Select()
        { CharacterSelector.ToggleSelect(Character); }

        #endregion

        #region PRIVATE

        private void SetOutline(float alpha)
        {
            if (selectOutline)
            {
                Color c = selectOutline.effectColor;
                c.a = alpha;
                selectOutline.effectColor = c;
            }
        }

        #endregion
    }
}
