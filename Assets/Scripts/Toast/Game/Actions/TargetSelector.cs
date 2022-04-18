using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Toast.Game.Characters;

namespace Toast.Game.Actions
{
    /// <summary>
    /// Controller used for selecting a target for an action.
    /// </summary>
    public class TargetSelector : MonoBehaviour
    {
        /* Public Fields */
        public bool Active { get; private set; }

        /* Serialized Fields */
        [SerializeField] private SpriteRenderer sprite;
        [SerializeField] private Animator animator;

        /* Private Fields */
        private bool hovered = false;
        private CController target;

        private void Awake()
        { SetActive(false); }

        #region PUBLIC

        /// <summary> Enable/Disable target selector. </summary>
        public void SetTarget(CController target)
        {
            this.target = target;
            transform.position = target.transform.position;
        }

        /// <summary> Enable/Disable target selector. </summary>
        public void SetActive(bool active)
        {
            Active = active;
            Refresh();
        }

        /// <summary> Refresh target selector status. </summary>
        public void Refresh()
        {
            animator?.SetBool("Active", Active);
            animator?.SetBool("Hovered", hovered);
        }

        /// <summary> Hover target. </summary>
        public void Hover(bool active)
        {
            CharacterSelector.Hover(active, target.Character);
            hovered = active;
            Refresh();
        }

        /// <summary> Select target. </summary>
        public void Select()
        { ActionHelper.Target(target.Character); }

        #endregion
    }
}
