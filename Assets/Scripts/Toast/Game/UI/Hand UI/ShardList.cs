using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Toast.Game.Characters;
using Toast.Game.Combat;
using Toast.Game.Shards;

namespace Toast.Game.UI
{
    /// <summary>
    /// Controller for a Shard List.
    /// </summary>
    public class ShardList : MonoBehaviour
    {
        /* Serialized Fields */
        [SerializeField] private ShardButton shardButtonPrefab;
        [SerializeField] private RectTransform targetPrefab;
        [SerializeField] private RectTransform shardContainer;
        [SerializeField] private RectTransform targetContainer;

        /* Private Fields */
        private Dictionary<ShardButton, RectTransform> shardTargets;

        private void Start()
        {
            shardTargets = new Dictionary<ShardButton, RectTransform>();
            Refresh();
        }

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

        /// <summary> Clear list. </summary>
        public void Clear()
        {
            if (shardTargets != null)
            {
                foreach (ShardButton shard in shardTargets.Keys)
                {
                    if (shardTargets[shard]) Destroy(shardTargets[shard].gameObject);
                    shard?.Destroy();
                }
                shardTargets.Clear();
            }
        }

        /// <summary> Refresh shard list. </summary>
        public void Refresh()
        {
            bool active = CharacterSelector.SelectedCharacter != null &&
                          CharacterSelector.SelectedCharacter.AI == null;

            targetContainer.gameObject.SetActive(active);

            if (active)
            {
                Trim();
                foreach (Shard shard in CharacterSelector.SelectedCharacter.Equipment.Shards.Hand)
                {
                    ShardButton sb = GetShard(shard);
                    if (sb) ((RectTransform)shardTargets[sb].transform).SetAsLastSibling();
                    else Add(shard);
                }
            }
            else Clear();
        }

        #endregion

        #region PRIVATE

        private ShardButton GetShard(Shard shard)
        {
            foreach (ShardButton sb in shardTargets.Keys)
                if (shard == sb.Shard)
                    return sb;
            return null;
        }

        private void Add(Shard shard)
        {
            ShardButton sb = Instantiate(shardButtonPrefab, shardContainer.transform);
            RectTransform target = Instantiate(targetPrefab, targetContainer.transform);
            sb.Initialize(shard, target);
            shardTargets.Add(sb, target);
        }

        private void Remove(ShardButton shard)
        {
            if (shardTargets[shard]) Destroy(shardTargets[shard].gameObject);
            shardTargets.Remove(shard);
            shard?.Destroy();
        }

        private void Trim()
        {
            List<ShardButton> controllers = new List<ShardButton>(shardTargets.Keys);
            foreach (ShardButton sb in controllers)
                if (!CharacterSelector.SelectedCharacter.Equipment.Shards.Hand.Contains(sb.Shard))
                    Remove(sb);
        }

        #endregion
    }
}
