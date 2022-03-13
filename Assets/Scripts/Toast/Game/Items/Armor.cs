using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Toast.Game.Items
{
    /// <summary>
    /// Armor item.
    /// </summary>
    public class Armor : Item
    {
        /* Public Fields */
        public Spread Physical { get; private set; }
        public Spread Magical { get; private set; }

        public Armor(string name, Spread physical, Spread magical)
        {
            ItemName = name;
            Physical = physical;
            Magical = magical;
        }
    }
}
