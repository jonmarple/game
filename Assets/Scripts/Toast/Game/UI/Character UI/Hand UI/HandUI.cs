using System.Collections;
using System.Collections.Generic;
using UnityEngine;
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
        [SerializeField] private TextMeshProUGUI shardMultiplier;
        [SerializeField] private TextMeshProUGUI bagCount;

        private void OnEnable()
        { CombatHelper.ShardRolled += Refresh; }

        private void OnDisable()
        { CombatHelper.ShardRolled -= Refresh; }

        #region PUBLIC

        /// <summary> Refresh UI. </summary>
        public void Refresh()
        {
            if (gameObject.activeInHierarchy && CharacterSelector.SelectedCharacter != null)
            {
                shardMultiplier.SetText(CharacterSelector.SelectedCharacter.ShardBuffer.MBuffer.ToString() + "x");
                bagCount.SetText(CharacterSelector.SelectedCharacter.Equipment.Shards.Bag.Count.ToString());
            }
        }

        #endregion
    }
}
