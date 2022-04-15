using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Toast.Game.Actions;
using Toast.Game.Combat;

namespace Toast.Game.Characters
{
    /// <summary>
    /// Main interface for interacting with character GameObjects.
    /// </summary>
    public class CController : MonoBehaviour
    {
        /* Public Fields */
        public Character Character { get; private set; }
        public Faction Faction { get; private set; }

        /* Serialized Fields */
        [SerializeField] private SpriteRenderer sprite;
        [SerializeField] private Color factionAColor;
        [SerializeField] private Color factionBColor;
        [SerializeField] private Animator animator;

        private void Update()
        {
            animator?.SetBool("Selected", Character.Selected);
            animator?.SetBool("Hovered", Character.Hovered);
        }

        #region PUBLIC

        public void Initialize(Character character, Faction faction)
        {
            Character = character;
            Character.ThisCharacterKilled += Disable;
            Character.TurnProcessHandler = TurnProcessHandler;
            Faction = faction;
            sprite.color = faction == Faction.A ? factionAColor : factionBColor;
        }

        /// <summary> Disable this character. </summary>
        public void Disable()
        { gameObject.SetActive(false); }

        /// <summary> Set hover status. </summary>
        public void Hover(bool active)
        { CharacterSelector.Hover(active, Character); }

        /// <summary> Select this character. </summary>
        public void Select()
        {
            if (ActionHelper.Targeting)
                ActionHelper.Target(Character);
            else
                CharacterSelector.ToggleSelect(Character);
        }

        #endregion

        #region PRIVATE

        private void TurnProcessHandler()
        { StartCoroutine(RunTurnProcessHandler()); }

        private IEnumerator RunTurnProcessHandler()
        {
            if (Character.AI != null)
            {
                yield return new WaitForSeconds(0.5f);
                Character.AI.Process();
            }
            yield return new WaitForSeconds(0.5f);
            CombatFlow.FinishTurn();
        }

        #endregion
    }
}
