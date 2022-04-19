using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

namespace Toast.Game.UI
{
    /// <summary>
    /// Make text fly away.
    /// </summary>
    public class FloatingText : MonoBehaviour
    {
        /* Serialized Fields */
        [SerializeField] private TextMeshProUGUI text;
        [SerializeField] private Animator animator;

        /* Private Fields */
        private float range = 0.5f;

        private void Start()
        { transform.position += new Vector3(2f * Random.value - 1f, 2f * Random.value - 1f, 0f) * range; }

        #region PUBLIC

        /// <summary> Run float animation. </summary>
        public void Float(string text)
        {
            this.text.text = text;
            animator.SetTrigger("Float");
            Invoke("Kill", 5f);
        }

        #endregion

        #region PRIVATE

        private void Kill()
        { Destroy(gameObject); }

        #endregion
    }
}
