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
        public CharacterGroup Group { get; private set; }
        public List<CController> Controllers { get; private set; }

        /* Serialized Fields */
        [SerializeField] private CharacterGroupData groupData;
        [SerializeField] private CController controllerPrefab;
        [SerializeField] private Transform controllerContainer;

        #region PUBLIC

        /// <summary> Generates CharacterGroup and instantiates CControllers for group members. </summary>
        public void Spawn()
        {
            Clear();
            Group = groupData.Generate();
            Controllers = new List<CController>();
            foreach (Character character in Group.Characters)
            {
                CController controller = Instantiate(controllerPrefab, controllerContainer);
                controller.Initialize(character);
                Controllers.Add(controller);
            }
        }

        /// <summary> Clears CharacterGroup and Destroys CControllers. </summary>
        public void Clear()
        {
            Group = null;
            if (Controllers != null)
            {
                foreach (CController controller in Controllers)
                    Destroy(controller.gameObject);
                Controllers.Clear();
            }
        }

        #endregion
    }
}
