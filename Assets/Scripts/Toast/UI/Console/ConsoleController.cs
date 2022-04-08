using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

namespace Toast.UI.Console
{
    /// <summary>
    /// Display UnityEditor log messages.
    /// </summary>
    public class ConsoleController : MonoBehaviour
    {
        /* Serialized Fields */
        [SerializeField] private int messageCountMax = 10;
        [SerializeField] private float messageDelay = 0f;
        [SerializeField] private VerticalLayoutGroup messageContainer;
        [SerializeField] private InactivityFader inactivityFader;
        [SerializeField] private RectTransform messagePrefab;

        /* Private Fields */
        private Queue<RectTransform> consoleMessages;
        private Queue<MSG> incomingMessages;

        private void Awake()
        {
            consoleMessages = new Queue<RectTransform>();
            incomingMessages = new Queue<MSG>();
        }

        private void Start()
        { StartCoroutine(HandleLogging()); }

        #region PUBLIC

        public void LogMessage(string message, DateTime time, LogType type)
        { incomingMessages.Enqueue(new MSG(message, time, type)); }

        #endregion

        #region PRIVATE

        private IEnumerator HandleLogging()
        {
            float t = 0f;
            while (true)
            {
                if (t > 0f)
                {
                    yield return new WaitForSeconds(t);
                    t = 0f;
                }
                else
                {
                    yield return new WaitUntil(() => incomingMessages.Count > 0);
                    LogMessage(incomingMessages.Dequeue());
                    t = messageDelay;
                }
            }
        }

        private void LogMessage(MSG msg)
        {
            RectTransform rect = Instantiate(messagePrefab, messageContainer.transform);
            TextMeshProUGUI tmp = rect.GetComponentInChildren<TextMeshProUGUI>();

            consoleMessages.Enqueue(rect);
            if (consoleMessages.Count > messageCountMax)
                Destroy(consoleMessages.Dequeue().gameObject);

            tmp.text = String.Format("[{0:00}:{1:00}:{2:00}] {3}", msg.Time.Hour, msg.Time.Minute, msg.Time.Second, msg.Message);
            tmp.color = GetColor(msg.Type);

            inactivityFader.RegisterEvent();
        }

        private Color GetColor(LogType type)
        {
            switch (type)
            {
                case LogType.Error:
                case LogType.Exception:
                    return Color.red;
                case LogType.Warning:
                    return Color.yellow;
                default:
                    return Color.white;
            }
        }

        #endregion

        /// <summary> Struct used for queueing messages for logging. </summary>
        private struct MSG
        {
            public string Message;
            public DateTime Time;
            public LogType Type;

            public MSG(string message, DateTime time, LogType type)
            {
                Message = message;
                Time = time;
                Type = type;
            }
        }
    }
}
