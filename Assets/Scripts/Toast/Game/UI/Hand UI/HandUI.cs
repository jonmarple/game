using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Toast.Game.Characters;
using Toast.Game.Combat;

namespace Toast.Game.UI
{
    /// <summary>
    /// Controller for the Hand UI.
    /// </summary>
    public class HandUI : MonoBehaviour
    {
        /* Serialized Fields */
        [SerializeField] private Image shardMultiplierContainer;
        [SerializeField] private TextMeshProUGUI shardMultiplierText;
        [SerializeField] private Image bagCountContainer;
        [SerializeField] private TextMeshProUGUI bagCountText;

        private void OnEnable()
        {
            CharacterSelector.SelectUpdated += Refresh;
            CombatHelper.ShardRolled += Refresh;
        }

        private void OnDisable()
        {
            CharacterSelector.SelectUpdated -= Refresh;
            CombatHelper.ShardRolled -= Refresh;
        }

        #region PUBLIC

        public void Refresh()
        {
            bool active = CharacterSelector.SelectedCharacter != null &&
                          CharacterSelector.SelectedCharacter.AI == null;

            shardMultiplierContainer.enabled = active;
            shardMultiplierText.enabled = active;
            bagCountContainer.enabled = active;
            bagCountText.enabled = active;

            if (active)
            {
                shardMultiplierText.SetText(CharacterSelector.SelectedCharacter.ShardBuffer.MBuffer.ToString() + "x");
                bagCountText.SetText(CharacterSelector.SelectedCharacter.Equipment.Shards.Bag.Count.ToString());
            }
        }

        #endregion
    }
}
