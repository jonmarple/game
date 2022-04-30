using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Toast.UI;
using Toast.Game.Characters;

namespace Toast.Game.UI
{
    /// <summary>
    /// Controller for the Stat Bar UI.
    /// </summary>
    public class StatBar : MonoBehaviour
    {
        /* Serialized Fields */
        [SerializeField] private FillBar hpBar;
        [SerializeField] private FillBar apBar;
        [SerializeField] private FillBar amBar;

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
            SetCharListeners(true);
            Refresh();
        }

        /// <summary> Refresh UI. </summary>
        public void Refresh()
        {
            if (character != null)
            {
                hpBar.SetFill(character.Stats.HP, character.Stats.HPMax);
                apBar.SetFill(character.Equipment.Armor.Physical, character.Equipment.Armor.PhysicalMax);
                amBar.SetFill(character.Equipment.Armor.Magical, character.Equipment.Armor.MagicalMax);
            }
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

        #endregion
    }
}
