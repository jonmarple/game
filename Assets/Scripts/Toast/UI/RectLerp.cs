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
        private Coroutine lerp;

        private void Awake()
        { rect = (RectTransform)transform; }

        private void Start()
        { if (target) SetTarget(target); }

        #region PUBLIC

        /// <summary> Set RectTransform's Lerp target. </summary>
        public void SetTarget(RectTransform target)
        {
            this.target = target;
            if (lerp == null)
                lerp = StartCoroutine(HandleLerp());
        }

        #endregion

        #region PRIVATE

        private IEnumerator HandleLerp()
        {
            yield return null;
            pos = target.position;
            while (target)
            {
                yield return new WaitForEndOfFrame();
                pos = Vector3.Lerp(pos, target.position, speed * Time.deltaTime);
                rect.position = pos;
            }
        }

        #endregion
    }
}
