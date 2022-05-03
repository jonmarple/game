using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Toast.Transition
{
    /// <summary>
    /// Scene transition manager.
    /// </summary>
    [CreateAssetMenu(fileName = "Transition Manager", menuName = "Toast/Transition/Transition Manager")]
    public class TransitionManager : ScriptableObject
    {
        /* Private Fields */
        private const string QUIT = "QUIT";

        #region PUBLIC

        /// <summary> Transition to specified scene. </summary>
        public void Transition(string scene)
        {
            if (TransitionController.Instance)
                TransitionController.Instance.TransitionTo(scene);
            else
                Load(scene);
        }

        /// <summary> Load specified scene. </summary>
        public void Load(string scene)
        {
            if (scene == QUIT)
#if UNITY_EDITOR
                UnityEditor.EditorApplication.isPlaying = false;
#else
                Application.Quit();
#endif
            else
                SceneManager.LoadScene(scene);
        }

        /// <summary> Transition out of application. </summary>
        public void Quit()
        { Transition(QUIT); }

        #endregion
    }
}
