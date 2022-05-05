using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Toast.Utility
{
    public static class Gaussian
    {
        #region PUBLIC

        /// <summary>
        /// Return random number from Normal Distribution.
        /// Author: Oneiros90
        /// Source: https://answers.unity.com/questions/421968/normal-distribution-random.html
        /// </summary>
        public static float Random(float minValue = 0f, float maxValue = 1f)
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
