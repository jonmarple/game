using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
using Toast.Game.Combat;
using Toast.Game.Characters;

namespace Toast.Game.Camera
{
    /// <summary>
    /// Controller used for selecting a target for an action.
    /// </summary>
    public class CombatCameraController : MonoBehaviour
    {
        /* Serialized Fields */
        [SerializeField] private CinemachineTargetGroup targetGroup;
        [SerializeField] private float full = 1f;
        [SerializeField] private float partial = 0.5f;
        [SerializeField] private float radius = 5f;

        private void OnEnable()
        {
            CombatFlow.CombatStart += Initialize;
            Character.CharacterKilled += Refresh;
            CharacterSelector.SelectUpdated += Refresh;
        }

        private void OnDisable()
        {
            CombatFlow.CombatStart -= Initialize;
            Character.CharacterKilled -= Refresh;
            CharacterSelector.SelectUpdated -= Refresh;
        }

        #region PUBLIC

        /// <summary> Initialize combat vcam. </summary>
        public void Initialize()
        {
            Reset();
            RunAction(AddMember);
            Refresh();
        }

        /// <summary> Refresh combat vcam. </summary>
        public void Refresh()
        { RunAction(RefreshMember); }

        /// <summary> Reset combat vcam. </summary>
        public void Reset()
        { RunAction(RemoveMember); }

        #endregion

        #region PRIVATE

        /// <summary> Run an action against Group A/B characters. </summary>
        private void RunAction(System.Action<Character> action)
        {
            if (CombatFlow.GroupA != null && CombatFlow.GroupA.Characters != null)
                foreach (Character character in CombatFlow.GroupA.Characters)
                    action(character);
            if (CombatFlow.GroupB != null && CombatFlow.GroupB.Characters != null)
                foreach (Character character in CombatFlow.GroupB.Characters)
                    action(character);
        }

        private void AddMember(Character character)
        { targetGroup.AddMember(character.Controller.transform, full, radius); }

        private void RemoveMember(Character character)
        { targetGroup.RemoveMember(character.Controller.transform); }

        private void RefreshMember(Character character)
        {
            if (character.Stats.Dead) RemoveMember(character);
            else
            {
                float weight = 0f;
                if (CharacterSelector.SelectedCharacter != null && !character.Selected)
                    weight = partial;
                else
                    weight = full;
                targetGroup.m_Targets[targetGroup.FindMember(character.Controller.transform)].weight = weight;
            }
        }

        #endregion
    }
}
