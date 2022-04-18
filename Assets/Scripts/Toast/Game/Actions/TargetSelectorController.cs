using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Toast.Game.Characters;
using Toast.Game.Combat;

namespace Toast.Game.Actions
{
    /// <summary>
    /// Controller used for selecting targets for actions.
    /// </summary>
    public class TargetSelectorController : MonoBehaviour
    {
        /* Serialized Fields */
        [SerializeField] private TargetSelector selectorPrefab;
        [SerializeField] private Transform selectorContainer;
        [SerializeField] private CombatController controller;

        /* Private Fields */
        private List<TargetSelector> selectors;

        private void Start()
        { selectors = new List<TargetSelector>(); }

        private void OnEnable()
        { ActionHelper.SelectUpdated += Refresh; }

        private void OnDisable()
        { ActionHelper.SelectUpdated -= Refresh; }

        #region PUBLIC

        /// <summary> Refresh placed target selectors. </summary>
        public void Refresh()
        {
            Clear();
            if (ActionHelper.Targeting)
                Place(CharacterSelector.SelectedCharacter, ActionHelper.SelectedAction);
        }

        #endregion

        #region PRIVATE

        private void Place(Character source, Action action)
        {
            switch (action)
            {
                case Attack attack:
                    Place(source.Faction == Faction.A ? controller.FactionB.Controllers : controller.FactionA.Controllers);
                    break;
                case Regen regen:
                case Roll roll:
                    Place(source.Faction == Faction.A ? controller.FactionA.Controllers : controller.FactionB.Controllers);
                    break;
            }
        }

        private void Place(List<CController> targets)
        {
            for (int i = selectors.Count; i < targets.Count; i++)
                selectors.Add(Instantiate(selectorPrefab, selectorContainer));

            for (int i = 0; i < targets.Count; i++)
            {
                if (!targets[i].Character.Stats.Dead)
                {
                    selectors[i].SetTarget(targets[i]);
                    selectors[i].SetActive(true);
                }
            }
        }

        private void Clear()
        {
            foreach (TargetSelector selector in selectors)
                selector.SetActive(false);
        }

        #endregion
    }
}
