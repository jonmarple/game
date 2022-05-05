using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Toast.Game.Actions;

namespace Toast.Game.Items
{
    /// <summary>
    /// Weapon item.
    /// </summary>
    public class Weapon : Item
    {
        /* Public Fields */
        public Spread Physical { get; private set; }
        public Spread Magical { get; private set; }
        public Action Primary { get; private set; }
        public Action Secondary { get; private set; }

        public Weapon(string name, int level, Spread physical, Spread magical, Action primary, Action secondary)
        {
            ItemName = name;
            Level = level;
            Physical = physical.Scale(level);
            Magical = magical.Scale(level);
            Primary = primary;
            Secondary = secondary;
        }
    }
}
