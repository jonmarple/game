using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Toast
{
    /// <summary>
    /// Stores options for a prototype scene.
    /// </summary>
    [CreateAssetMenu(fileName = "Transition Manager", menuName = "Toast/Transition/Transition Manager")]
    public class TransitionManager : ScriptableObject
    {
        #region PUBLIC

        public void Transition(string name)
        { SceneManager.LoadScene(name); }

        #endregion
    }
}
