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
        public int Value { get { return value; } }
        public int Variation { get { return variation; } }

        /* Serialized Fields */
        [SerializeField] private int value;
        [SerializeField] private int variation;

        public Spread(int value, int variation)
        {
            this.value = value;
            this.variation = variation;
        }

        #region PUBLIC

        public int Roll()
        {
            return Random.Range(
                Mathf.Clamp(value - variation, 0, int.MaxValue),
                Mathf.Clamp(value + variation + 1, 0, int.MaxValue));
        }

        public int Roll(bool crit)
        {
            if (crit)
                return Roll() + Value + Variation;
            else
                return Roll();
        }

        #endregion
    }
}
