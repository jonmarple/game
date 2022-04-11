using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Toast.UI
{
    /// <summary>
    /// Lerp a RectTransform towards a target.
    /// </summary>
    public class RectLerp : MonoBehaviour
    {
        /* Serialized Fields */
        [SerializeField] private float speed = 10f;
        [SerializeField] private RectTransform target;

        /* Private Fields */
        private RectTransform rect;
        private Vector3 pos;

        private void Awake()
        { rect = (RectTransform)transform; }

        private void Start()
        { if (target) SetTarget(target); }

        private void Update()
        { HandleLerp(); }

        #region PUBLIC

        /// <summary> Set RectTransform's Lerp target. </summary>
        public void SetTarget(RectTransform target)
        {
            this.target = target;
            pos = target.position;
        }

        #endregion

        #region PRIVATE

        private void HandleLerp()
        {
            if (target)
            {
                pos = Vector3.Lerp(pos, target.position, speed * Time.deltaTime);
                rect.position = pos;
            }
        }

        #endregion
    }
}
