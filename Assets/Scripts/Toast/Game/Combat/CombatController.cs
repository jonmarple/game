using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Toast.Game.Combat
{
    /// <summary>
    /// Direct CombatFlow in a Scene.
    /// </summary>
    public class CombatController : MonoBehaviour
    {
        private void Awake()
        { CombatFlow.Reset(); }
    }
}
