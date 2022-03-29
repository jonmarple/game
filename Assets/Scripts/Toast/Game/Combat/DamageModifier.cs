using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Toast.Game.Combat
{
    /// <summary>
    /// Damage resistance/weakness.
    /// </summary>
    [System.Serializable]
    public struct DamageModifier
    {
        /* Public Fields */
        public DamageType Type { get { return type; } }
        public ModifierLevel Modifier { get { return modifier; } }

        /* Serialized Fields */
        [SerializeField] private DamageType type;
        [SerializeField] private ModifierLevel modifier;

        public DamageModifier(DamageType type, ModifierLevel modifier)
        {
            this.type = type;
            this.modifier = modifier;
        }
    }
}
