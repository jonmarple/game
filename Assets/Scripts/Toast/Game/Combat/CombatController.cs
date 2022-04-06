using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Toast.Game.Characters;

namespace Toast.Game.Combat
{
    /// <summary>
    /// Direct CombatFlow in a Scene.
    /// </summary>
    public class CombatController : MonoBehaviour
    {
        /* Serialized Fields */
        [SerializeField] private GroupController party;
        [SerializeField] private GroupController mob;

        private void Awake()
        { CombatFlow.Reset(); }

        private void Start()
        { StartCombat(); }

        #region PUBLIC

        /// <summary> Execute Combat Step. </summary>
        public void Step()
        { CombatFlow.Step(); }

        #endregion

        #region PRIVATE

        private void StartCombat()
        {
            party.Spawn();
            mob.Spawn();
            CombatFlow.Initialize(party.Group, mob.Group);
        }

        #endregion
    }
}
