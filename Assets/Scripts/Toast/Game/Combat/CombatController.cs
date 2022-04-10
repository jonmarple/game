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
        [SerializeField] private GroupController factionA;
        [SerializeField] private GroupController factionB;
        [SerializeField] private VoidEvent combatStart;
        [SerializeField] private VoidEvent combatFinish;
        [SerializeField] private VoidEvent turnStart;
        [SerializeField] private VoidEvent turnFinish;

        private void Start()
        { StartCombat(); }

        #region PUBLIC

        /// <summary> Initialize parties and start CombatFlow. </summary>
        public void StartCombat()
        {
            factionA.Spawn();
            factionB.Spawn();
            CombatFlow.Start(factionA.Group, factionB.Group, combatStart, combatFinish, turnStart, turnFinish);
        }

        /// <summary> End current combat turn. </summary>
        public void FinishTurn()
        { CombatFlow.FinishTurn(); }

        #endregion
    }
}
