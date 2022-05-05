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
        public int Level { get { return level; } }

        /* Serialized Fields */
        [SerializeField] private bool groupAHasAI = false;
        [SerializeField] private bool groupBHasAI = false;
        [SerializeField] private int level = 1;

        /* Value Update Delegate/Event */
        public delegate void Updated();
        public event Updated LevelUpdated;

        #region PUBLIC

        public void SetAISettingA(bool ai)
        { groupAHasAI = ai; }

        public void SetAISettingB(bool ai)
        { groupBHasAI = ai; }

        public void IncLevel()
        { SetLevel(level + 1); }

        public void DecLevel()
        { SetLevel(level - 1); }

        public void SetLevel(int level)
        {
            this.level = Mathf.Clamp(level, 1, 100);
            LevelUpdated?.Invoke();
        }

        #endregion
    }
}
