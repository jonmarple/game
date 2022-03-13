using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Toast.Game
{
    /// <summary>
    /// Value with a variation.
    /// </summary>
    [System.Serializable]
    public struct Spread
    {
        /* Public Fields */
        public int Value { get; private set; }
        public int Variation { get; private set; }

        public Spread(int value, int variation)
        {
            Value = value;
            Variation = variation;
        }

        #region PUBLIC

        public int Roll()
        {
            return Random.Range(
                Mathf.Clamp(Value - Variation, 0, int.MaxValue),
                Mathf.Clamp(Value + Variation + 1, 0, int.MaxValue));
        }

        #endregion
    }
}
