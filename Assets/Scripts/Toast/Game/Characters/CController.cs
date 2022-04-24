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

        private void OnEnable()
        {
            if (Character != null)
                Character.ThisCharacterKilled += Disable;
            CharacterSelector.SelectUpdated += Refresh;
            CharacterSelector.HoverUpdated += Refresh;
            ActionHelper.SelectUpdated += Refresh;
        }

        private void OnDisable()
        {
            if (Character != null)
                Character.ThisCharacterKilled -= Disable;
            CharacterSelector.SelectUpdated -= Refresh;
            CharacterSelector.HoverUpdated -= Refresh;
            ActionHelper.SelectUpdated -= Refresh;
        }

        #region PUBLIC

        public void Initialize(Character character, Faction faction)
        {
            Character = character;
            Character.Register(this);
            Character.TurnProcessHandler = TurnProcessHandler;
            Character.ThisCharacterKilled += Disable;
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
        { if (!ActionHelper.Targeting) CharacterSelector.ToggleSelect(Character); }

        /// <summary> Refresh this character selector. </summary>
        public void Refresh()
        {
            animator?.SetBool("Selected", Character.Selected);
            animator?.SetBool("Hovered", Character.Hovered);
            animator?.SetBool("Targeting", ActionHelper.Targeting);
        }

        /// <summary> Trigger action animation. </summary>
        public void AnimateAction()
        { animator?.SetTrigger("Action"); }

        /// <summary> Trigger damaged animation. </summary>
        public void AnimateDamage()
        { animator?.SetTrigger("Damaged"); }

        /// <summary> Trigger healed animation. </summary>
        public void AnimateHealing()
        { animator?.SetTrigger("Healed"); }

        #endregion

        #region PRIVATE

        private void TurnProcessHandler()
        { StartCoroutine(RunTurnProcessHandler()); }

        private IEnumerator RunTurnProcessHandler()
        {
            if (Character.AI != null)
            {
                yield return new WaitForSeconds(0.5f);
                while (Character.AI.ProcessStep())
                    yield return new WaitForSeconds(0.4f);
            }
            yield return new WaitForSeconds(0.5f);
            CombatFlow.FinishTurn();
        }

        #endregion
    }
}
