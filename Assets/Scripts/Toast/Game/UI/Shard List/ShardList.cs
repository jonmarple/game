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
        [SerializeField] private ShardController shardControllerPrefab;
        [SerializeField] private RectTransform targetPrefab;
        [SerializeField] private RectTransform shardContainer;
        [SerializeField] private RectTransform targetContainer;

        /* Private Fields */
        private Dictionary<ShardController, RectTransform> shardTargets;

        private void Start()
        {
            CharacterSelector.SelectUpdated += Refresh;
            CombatHelper.ShardRolled += Refresh;
            shardTargets = new Dictionary<ShardController, RectTransform>();
            Refresh();
        }

        #region PUBLIC

        /// <summary> Clear list. </summary>
        public void Clear()
        {
            if (shardTargets != null)
            {
                foreach (ShardController shard in shardTargets.Keys)
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
                    ShardController sc = GetShard(shard);
                    if (sc) ((RectTransform)shardTargets[sc].transform).SetAsLastSibling();
                    else Add(shard);
                }
            }
            else Clear();
        }

        #endregion

        #region PRIVATE

        private ShardController GetShard(Shard shard)
        {
            foreach (ShardController sc in shardTargets.Keys)
                if (shard == sc.Shard)
                    return sc;
            return null;
        }

        private void Add(Shard shard)
        {
            ShardController sc = Instantiate(shardControllerPrefab, shardContainer.transform);
            RectTransform target = Instantiate(targetPrefab, targetContainer.transform);
            sc.Initialize(shard, target);
            shardTargets.Add(sc, target);
        }

        private void Remove(ShardController shard)
        {
            if (shardTargets[shard]) Destroy(shardTargets[shard].gameObject);
            shardTargets.Remove(shard);
            shard?.Destroy();
        }

        private void Trim()
        {
            List<ShardController> controllers = new List<ShardController>(shardTargets.Keys);
            foreach (ShardController sc in controllers)
                if (!CharacterSelector.SelectedCharacter.Equipment.Shards.Hand.Contains(sc.Shard))
                    Remove(sc);
        }

        #endregion
    }
}
