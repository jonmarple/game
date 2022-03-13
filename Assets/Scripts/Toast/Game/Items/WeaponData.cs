using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Toast.Game.Actions;

namespace Toast.Game.Items
{
    /// <summary>
    /// Data container for weapon information.
    /// </summary>
    [CreateAssetMenu(fileName = "Weapon", menuName = "Toast/Game/Items/Weapon")]
    public class WeaponData : ItemData<Weapon>
    {
        /* Serialized Fields */
        [SerializeField] private Spread physical;
        [SerializeField] private Spread magical;
        [SerializeField] private ActionData primaryAction;
        [SerializeField] private ActionData secondaryAction;

        #region PUBLIC

        public override Weapon Generate()
        { return new Weapon(itemName, physical, magical, primaryAction.Generate(), secondaryAction.Generate()); }

        #endregion
    }
}
