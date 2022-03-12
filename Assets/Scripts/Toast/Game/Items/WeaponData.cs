using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityAtoms.BaseAtoms;
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
        [SerializeField] private IntReference damage;
        [SerializeField] private ActionData primaryAction;
        [SerializeField] private ActionData secondaryAction;

        #region PUBLIC

        public override Weapon Generate()
        { return new Weapon(itemName, damage, primaryAction.Generate(), secondaryAction.Generate()); }

        #endregion
    }
}
