using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Toast.Game.Spawns;

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
        public CharacterGroupData GroupData { get { return groupData; } }

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
            int count = 0;
            foreach (Character character in Group.Characters)
            {
                CController controller;
                if (SpawnList.HasSpawns(Group.Faction))
                    controller = Instantiate(controllerPrefab, SpawnList.Get(Group.Faction)[count].transform.position, Quaternion.identity, controllerContainer);
                else
                    controller = Instantiate(controllerPrefab, controllerContainer);
                controller.Initialize(character, Group.Faction);
                Controllers.Add(controller);
                count = (count + 1) % SpawnList.Get(Group.Faction).Count;
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
