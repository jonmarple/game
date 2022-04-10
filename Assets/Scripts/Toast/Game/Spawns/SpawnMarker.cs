using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Toast.Game.Characters;

namespace Toast.Game.Spawns
{
    /// <summary>
    /// CController Spawn marker.
    /// </summary>
    public class SpawnMarker : MonoBehaviour
    {
        /* Public Fields */
        public Faction Faction { get { return faction; } }

        /* Serialized Fields */
        [SerializeField] private Faction faction;
        [SerializeField] private SpriteRenderer sprite;

        private void OnEnable()
        {
            SpawnList.Register(this);
            sprite.gameObject.SetActive(false);
        }

        private void OnDisable()
        {
            SpawnList.Deregister(this);
            sprite.gameObject.SetActive(true);
        }
    }
}
