using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Toast.Game.AI;
using Toast.Game.Combat;

namespace Toast.Game.Prototype
{
    /// <summary>
    /// Handles setting up prototype scene.
    /// </summary>
    public class PrototypeSetup : MonoBehaviour
    {
        /* Serialized Fields */
        [SerializeField] private PrototypeOption options;
        [SerializeField] private CombatController controller;
        [SerializeField] private CharacterAIData aiData;

        private void Awake()
        {
            controller?.FactionA.GroupData.ApplyAI(options.GroupAHasAI ? aiData : null);
            controller?.FactionB.GroupData.ApplyAI(options.GroupBHasAI ? aiData : null);
            controller?.FactionA.GroupData.ApplyLevel(options.Level);
            controller?.FactionB.GroupData.ApplyLevel(options.Level);
        }
    }
}
