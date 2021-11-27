using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Toast.Game.Characters
{
    /// <summary>
    /// Main interface for interacting with a character group.
    /// </summary>
    public class GroupController : MonoBehaviour
    {
        /* Public Fields */

        /* Serialized Fields */
        [SerializeField] private CharacterGroup group;
        [SerializeField] private CController controllerPrefab;
        [SerializeField] private Transform controllerContainer;

        /* Private Fields */
        private List<CController> controllers;

        private void Start()
        {
            Spawn();
        }

        #region PUBLIC

        /// <summary>
        /// Instantiates and initializes CControllers for group members.
        /// </summary>
        public void Spawn()
        {
            controllers = new List<CController>();
            foreach (CharacterData character in group.Characters)
            {
                CController controller = Instantiate(controllerPrefab, controllerContainer);
                controller.Initialize(character);
                controllers.Add(controller);
            }
        }

        #endregion

        #region PRIVATE
        #endregion
    }
}
