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

        /// <summary> Generates a Spread with Variation approximately 25%-50% of its Value. </summary>
        public static Spread Generate(int value)
        { return new Spread(value, Mathf.Clamp(Mathf.RoundToInt(RandomGaussian(value * 0.25f, value * 0.5f)), 0, int.MaxValue)); }

        public int Roll()
        { return Mathf.Clamp(Mathf.RoundToInt(RandomGaussian(value - variation, value + variation)), 0, int.MaxValue); }

        public int Roll(bool crit)
        {
            if (crit)
                return Roll() + Value + Variation;
            else
                return Roll();
        }

        #endregion

        #region PRIVATE

        /// <summary>
        /// Return random number from Normal Distribution.
        /// Author: Oneiros90
        /// Source: https://answers.unity.com/questions/421968/normal-distribution-random.html
        /// </summary>
        private static float RandomGaussian(float minValue = 0f, float maxValue = 1f)
        {
            float u, v, S;

            do
            {
                u = 2.0f * UnityEngine.Random.value - 1.0f;
                v = 2.0f * UnityEngine.Random.value - 1.0f;
                S = u * u + v * v;
            }
            while (S >= 1.0f);

            // Standard Normal Distribution
            float std = u * Mathf.Sqrt(-2.0f * Mathf.Log(S) / S);

            // Normal Distribution centered between the min and max value
            // and clamped following the "three-sigma rule"
            float mean = (minValue + maxValue) / 2.0f;
            float sigma = (maxValue - mean) / 3.0f;
            return Mathf.Clamp(std * sigma + mean, minValue, maxValue);
        }

        #endregion
    }
}
