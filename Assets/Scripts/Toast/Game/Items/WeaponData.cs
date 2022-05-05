using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Toast.Game.Actions;
using Toast.Utility;

namespace Toast.Game.Items
{
    /// <summary>
    /// Data container for weapon information.
    /// </summary>
    [CreateAssetMenu(fileName = "Weapon", menuName = "Toast/Game/Items/Weapon")]
    public class WeaponData : ItemData
    {
        /* Serialized Fields */
        [SerializeField] private Spread physical;
        [SerializeField] private Spread magical;
        [SerializeField] private ActionData primaryAction;
        [SerializeField] private ActionData secondaryAction;

        #region PUBLIC

        public Weapon Generate(int level)
        { return new Weapon(itemName, Mathf.Clamp(Mathf.CeilToInt(Gaussian.Random(level - 2, level + 2)), 1, int.MaxValue), physical, magical, primaryAction.Generate(), secondaryAction.Generate()); }

        #endregion
    }
}
