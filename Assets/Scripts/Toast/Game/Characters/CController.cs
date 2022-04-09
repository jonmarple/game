using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Toast.Game.Combat;

namespace Toast.Game.Characters
{
    /// <summary>
    /// Main interface for interacting with character GameObjects.
    /// </summary>
    public class CController : MonoBehaviour
    {
        /* Public Fields */
        public Character Character { get; private set; }

        #region PUBLIC

        public void Initialize(Character character)
        {
            Character = character;
            Character.PostProcessCallback = PostProcessCallback;
        }

        #endregion

        #region PRIVATE

        private void PostProcessCallback()
        { StartCoroutine(HandlePostProcessCallback()); }

        private IEnumerator HandlePostProcessCallback()
        {
            yield return new WaitForSeconds(1f);
            CombatFlow.FinishTurn();
        }

        #endregion
    }
}
