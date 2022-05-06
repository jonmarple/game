using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Toast.UI
{
    /// <summary>
    /// Initializes a toggle to call onvaluechanged.
    /// </summary>
    [RequireComponent(typeof(Toggle))]
    public class ToggleInitializer : MonoBehaviour
    {
        /* Serialized Fields */
        [SerializeField] private bool value = false;

        /* Private Fields */
        private Toggle toggle;

        private void Awake()
        {
            toggle = GetComponent<Toggle>();
            toggle.isOn = !value;
            toggle.isOn = value;
        }
    }
}
