using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Toast.Game.Characters;

namespace Toast.Game.Spawns
{
    /// <summary>
    /// List of active spawns.
    /// </summary>
    public static class SpawnList
    {
        /* Private Fields */
        private static Dictionary<Faction, List<SpawnMarker>> spawns;

        #region PUBLIC

        /// <summary> Register new spawn marker. </summary>
        public static void Register(SpawnMarker marker)
        {
            if (spawns == null)
                spawns = new Dictionary<Faction, List<SpawnMarker>>();
            if (!spawns.ContainsKey(marker.Faction))
                spawns.Add(marker.Faction, new List<SpawnMarker>());
            spawns[marker.Faction].Insert(0, marker);
        }

        /// <summary> Deregister existing spawn marker. </summary>
        public static void Deregister(SpawnMarker marker)
        {
            if (spawns != null && spawns.ContainsKey(marker.Faction))
                spawns[marker.Faction].Remove(marker);
        }

        /// <summary> Get spawns for a certain faction. </summary>
        public static List<SpawnMarker> Get(Faction group)
        {
            if (spawns != null && spawns.ContainsKey(group))
                return spawns[group];
            return null;
        }

        /// <summary> Whether specified faction has spawns. </summary>
        public static bool HasSpawns(Faction group)
        { return spawns != null && spawns.ContainsKey(group) && spawns[group].Count > 0; }

        #endregion
    }
}
