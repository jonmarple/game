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
        public int PhysicalMax { get; private set; }
        public int MagicalMax { get; private set; }
        public int Physical { get; private set; }
        public int Magical { get; private set; }

        /* Value Update Delegate/Event */
        public delegate void Updated();
        public event Updated ValueUpdated;

        public Armor(string name, int physical, int magical)
        {
            ItemName = name;
            PhysicalMax = physical;
            MagicalMax = magical;
            Physical = physical;
            Magical = magical;
            ValueUpdated?.Invoke();
        }

        #region PUBLIC

        /// <summary> Set Physical value. </summary>
        public void SetPhysical(int value)
        {
            Physical = Mathf.Clamp(value, 0, PhysicalMax);
            ValueUpdated?.Invoke();
        }

        /// <summary> Alter Physical value. </summary>
        public void AlterPhysical(int diff)
        { SetPhysical(Physical + diff); }

        /// <summary> Set Magical value. </summary>
        public void SetMagical(int value)
        {
            Magical = Mathf.Clamp(value, 0, MagicalMax);
            ValueUpdated?.Invoke();
        }

        /// <summary> Alter Magical value. </summary>
        public void AlterMagical(int diff)
        { SetMagical(Magical + diff); }

        #endregion
    }
}
