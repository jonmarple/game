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
        [SerializeField] private TextMeshProUGUI apBuffer;
        [SerializeField] private TextMeshProUGUI amBuffer;
        [SerializeField] private TextMeshProUGUI dpBuffer;
        [SerializeField] private TextMeshProUGUI dmBuffer;

        /* Private Fields */
        private Character character;

        private void OnEnable()
        {
            SetCharListeners(true);
            CombatHelper.ShardRolled += Refresh;
        }

        private void OnDisable()
        {
            SetCharListeners(false);
            CombatHelper.ShardRolled -= Refresh;
        }

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
            if (gameObject.activeInHierarchy && character != null)
            {
                shardMultiplier.SetText(character.ShardBuffer.MBuffer.ToString() + "x");
                bagCount.SetText(character.Equipment.Shards.Bag.Count.ToString());
                apBuffer.SetText(character.ShardBuffer.APBuffer.ToString());
                amBuffer.SetText(character.ShardBuffer.AMBuffer.ToString());
                dpBuffer.SetText(character.ShardBuffer.DPBuffer.ToString());
                dmBuffer.SetText(character.ShardBuffer.DMBuffer.ToString());
            }
        }

        #endregion


        #region PRIVATE

        private void SetCharListeners(bool active)
        {
            if (character != null)
            {
                if (active) character.ShardBuffer.BufferUpdated += Refresh;
                else character.ShardBuffer.BufferUpdated -= Refresh;
            }
        }

        #endregion
    }
}
