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

        private void Awake()
        { GetComponent<Toggle>().isOn = value; }
    }
}
