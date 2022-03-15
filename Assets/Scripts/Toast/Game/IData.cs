using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Toast.Game
{
    /// <summary>
    /// ScriptableObject Data Generator.
    /// </summary>
    public interface IData<T>
    {
        /// <summary> Generate Class Object of this Data. </summary>
        T Generate();
    }
}
