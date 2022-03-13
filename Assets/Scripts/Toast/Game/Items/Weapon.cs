using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Toast.Game.Actions;

namespace Toast.Game.Items
{
    /// <summary>
    /// Weapon item.
    /// </summary>
    [System.Serializable]
    public class Weapon : Item
    {
        /* Public Fields */
        public Spread Physical { get; private set; }
        public Spread Magical { get; private set; }
        public Action Primary { get; private set; }
        public Action Secondary { get; private set; }

        public Weapon(string name, Spread physical, Spread magical, Action primary, Action secondary)
        {
            ItemName = name;
            Physical = physical;
            Magical = magical;
            Primary = primary;
            Secondary = secondary;
        }
    }
}
