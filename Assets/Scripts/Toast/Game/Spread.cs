using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Toast.Utility;

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

        /// <summary> Generates a Spread with Variation approximately 25%-50% of its Value. </summary>
        public static Spread Generate(int value)
        { return new Spread(value, Mathf.Clamp(Mathf.RoundToInt(Gaussian.Random(value * 0.25f, value * 0.5f)), 0, int.MaxValue)); }

        public int Roll()
        { return Mathf.Clamp(Mathf.RoundToInt(Gaussian.Random(value - variation, value + variation)), 0, int.MaxValue); }

        public int Roll(bool crit)
        {
            if (crit)
                return Roll() + Value + Variation;
            else
                return Roll();
        }

        /// <summary> Generates a new spread of equal value scaled by specified value. </summary>
        public Spread Scale(int scale)
        { return new Spread(Value * scale, Variation * scale); }

        public override string ToString()
        { return Value + ":" + Variation; }

        #endregion
    }
}
