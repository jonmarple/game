using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Toast.Audio
{
    /// <summary>
    /// Trigger audio on hover.
    /// </summary>
    public class AudioHoverTrigger : MonoBehaviour, IPointerEnterHandler
    {
        /* Serialized Fields */
        [SerializeField] private AudioKey key;

        #region PUBLIC

        public void OnPointerEnter(PointerEventData data)
        { AudioManager.Play(key); }

        #endregion
    }
}
