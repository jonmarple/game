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
        private float range = 0.33f;
        private float z = 1.33f;

        private void Start()
        { transform.position += (new Vector3(2f * Random.value - 1f, 2f * Random.value - 1f, 0f) * range) + (Vector3.up * z); }

        #region PUBLIC

        /// <summary> Run float animation. </summary>
        public void Float(string text, Color color)
        {
            this.text.text = text;
            this.text.color = color;
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
