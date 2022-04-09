using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityAtoms.BaseAtoms;
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
        [SerializeField] private VoidEvent combatStart;
        [SerializeField] private VoidEvent combatFinish;
        [SerializeField] private VoidEvent combatTurn;

        private void Start()
        { Initialize(); }

        #region PUBLIC

        /// <summary> Initialize parties and CombatFlow. </summary>
        public void Initialize()
        {
            party.Clear();
            party.Spawn();
            mob.Clear();
            mob.Spawn();
            CombatFlow.Initialize(party.Group, mob.Group, combatStart, combatFinish, combatTurn);
        }

        /// <summary> Execute Combat Step. </summary>
        public void Step()
        { CombatFlow.Step(); }

        #endregion
    }
}
