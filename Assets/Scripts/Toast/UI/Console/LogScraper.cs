using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Toast.UI.Console
{
    /// <summary>
    /// Scrape logs from the editor console and send to a ConsoleController.
    /// </summary>
    public class LogScraper : MonoBehaviour
    {
        /* Serialized Fields */
        [SerializeField] private ConsoleController controller;

        private void OnEnable()
        { Application.logMessageReceived += HandleLog; }

        private void OnDisable()
        { Application.logMessageReceived -= HandleLog; }

        private void HandleLog(string logString, string stackTrace, LogType type)
        { controller?.LogMessage(logString, type); }
    }
}
