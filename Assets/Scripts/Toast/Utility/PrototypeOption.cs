using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Toast.Game.Prototype
{
    /// <summary>
    /// Stores options for a prototype scene.
    /// </summary>
    [CreateAssetMenu(fileName = "Prototype Options", menuName = "Toast/Game/Prototype/Prototype Options")]
    public class PrototypeOption : ScriptableObject
    {
        /* Public Fields */
        public bool GroupAHasAI { get { return groupAHasAI; } }
        public bool GroupBHasAI { get { return groupBHasAI; } }

        /* Serialized Fields */
        [SerializeField] private bool groupAHasAI = false;
        [SerializeField] private bool groupBHasAI = false;

        #region PUBLIC

        public void SetAISettingA(bool ai)
        { groupAHasAI = ai; }

        public void SetAISettingB(bool ai)
        { groupBHasAI = ai; }

        #endregion
    }
}
