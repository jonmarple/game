using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Toast.Utility
{
    /// <summary>
    /// Helpers for handling collections.
    /// </summary>
    public static class CollectionHelper
    {
        /* Private Fields */
        private static System.Random random = new System.Random();

        #region PUBLIC

        /// <summary> Shuffle list values. </summary>
        public static void Shuffle<T>(this IList<T> list)
        {
            int n = list.Count;
            while (n > 1)
            {
                n--;
                int k = random.Next(n + 1);
                T value = list[k];
                list[k] = list[n];
                list[n] = value;
            }
        }

        #endregion
    }
}
