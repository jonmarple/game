using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Toast.Audio;

namespace Toast.Game.Actions
{
    /// <summary>
    /// Base action.
    /// </summary>
    public abstract class Action
    {
        /* Public Fields */
        public string ActionName { get; protected set; }
        public int Cost { get; protected set; }
        public int Cooldown { get; protected set; }
        public int CooldownCounter { get; protected set; }
        public AudioKey Audio { get; protected set; }

        #region PUBLIC

        /// <summary> Whether action is available. </summary>
        public bool CanPerform()
        { return CooldownCounter <= 0; }

        /// <summary> Perform action. </summary>
        public void Perform()
        {
            if (CanPerform())
            {
                CooldownCounter = Cooldown;
                AudioManager.Play(Audio);
            }
        }

        /// <summary> Process action turn. </summary>
        public void Turn()
        { CooldownCounter = Mathf.Clamp(CooldownCounter - 1, 0, int.MaxValue); }

        #endregion

        #region PRIVATE

        protected void InitBaseFields(string actionName, int cost, int cooldown, AudioKey audio)
        {
            ActionName = actionName;
            Cost = cost;
            Cooldown = cooldown;
            CooldownCounter = 0;
            Audio = audio;
        }

        #endregion
    }
}
