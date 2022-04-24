using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Toast.Game.Camera;
using Toast.Game.Characters;

namespace Toast.Game.Combat
{
    /// <summary>
    /// Direct CombatFlow in a Scene.
    /// </summary>
    public class CombatController : MonoBehaviour
    {
        /* Static Fields */
        public static CombatController Instance;

        /* Public Fields */
        public GroupController FactionA { get { return factionA; } }
        public GroupController FactionB { get { return factionB; } }

        /* Serialized Fields */
        [SerializeField] private CombatCameraController cameraController;
        [SerializeField] private GroupController factionA;
        [SerializeField] private GroupController factionB;

        private void Awake()
        { Instance = this; }

        private void Start()
        { StartCombat(); }

        #region PUBLIC

        /// <summary> Initialize parties and start CombatFlow. </summary>
        public void StartCombat()
        {
            cameraController.Reset();
            factionA.Spawn();
            factionB.Spawn();
            CombatFlow.Start(factionA.Group, factionB.Group);
        }

        /// <summary> End current combat turn. </summary>
        public void FinishTurn()
        { CombatFlow.FinishTurn(); }

        /// <summary> Perform action with minor delay prior. </summary>
        public void PerformAction(System.Action<ActionInfo> handler, ActionInfo info)
        { StartCoroutine(RunAction(handler, info)); }

        #endregion

        #region PRIVATE

        private IEnumerator RunAction(System.Action<ActionInfo> handler, ActionInfo info)
        {
            yield return new WaitForSeconds(0.15f);
            handler(info);
        }

        #endregion
    }
}
