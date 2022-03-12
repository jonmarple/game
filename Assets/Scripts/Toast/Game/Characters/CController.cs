using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Toast.Game.Characters
{
    /// <summary>
    /// Main interface for interacting with character GameObjects.
    /// </summary>
    public class CController : MonoBehaviour
    {
        /* Public Fields */
        public Character Character { get; private set; }

        #region PUBLIC

        public void Initialize(CharacterData data)
        { Character = new Character(data); }

        #endregion
    }
}
