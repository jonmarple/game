using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityAtoms.BaseAtoms;

namespace Toast.Game.Stats
{
    /// <summary>
    /// Data container for stat information.
    /// </summary>
    [CreateAssetMenu(fileName = "Stat Block", menuName = "Toast/Game/Stats/Stat Block")]
    public class StatBlockData : ScriptableObject, IData<StatBlock>
    {
        /* Serialized Fields */
        [SerializeField] private IntReference hp;
        [SerializeField] private IntReference ap;
        [SerializeField] private IntReference apRegen;
        [SerializeField] private IntReference crit;
        [SerializeField] private Spread initiative;

        #region PUBLIC

        public StatBlock Generate()
        { return new StatBlock(hp, hp, ap / 2, ap, apRegen, crit, initiative); }

        #endregion
    }
}
