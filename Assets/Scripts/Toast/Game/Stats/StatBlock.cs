using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Toast.Game.Characters;
using Toast.Game.Combat;

namespace Toast.Game.Stats
{
    /// <summary>
    /// Character Stats.
    /// </summary>
    public class StatBlock
    {
        /* Public Fields */
        public int HP { get; private set; }
        public int HPMax { get; private set; }
        public int AP { get; private set; }
        public int APMax { get; private set; }
        public int APRegen { get; private set; }
        public int Crit { get; private set; }
        public Spread Initiative { get; private set; }
        public ModifierLevel PhysicalMod { get; private set; }
        public ModifierLevel MagicalMod { get; private set; }
        public bool Dead { get; private set; }

        /* Private Fields */
        private Character owner;

        /* Value Update Delegate/Event */
        public delegate void Updated();
        public event Updated ValueUpdated;

        public StatBlock(int hp, int hpMax, int ap, int apMax, int apRegen, int crit, Spread initiative, ModifierLevel physicalMod, ModifierLevel magicalMod)
        {
            HPMax = hpMax;
            APMax = apMax;
            APRegen = apRegen;
            SetHP(hp);
            SetAP(ap);
            Crit = crit;
            Initiative = initiative;
            PhysicalMod = physicalMod;
            MagicalMod = magicalMod;
            ValueUpdated?.Invoke();
        }

        #region PUBLIC

        /// <summary> Set HP value. </summary>
        public void SetHP(int hp)
        {
            HP = Mathf.Clamp(hp, 0, HPMax);

            bool prev = Dead;
            Dead = HP <= 0;
            bool curr = Dead;

            if (!prev && curr)
                owner?.Kill();

            ValueUpdated?.Invoke();
        }

        /// <summary> Alter HP value. </summary>
        public void AlterHP(int diff)
        { SetHP(HP + diff); }

        /// <summary> Set AP value. </summary>
        public void SetAP(int ap)
        {
            AP = Mathf.Clamp(ap, 0, APMax);
            ValueUpdated?.Invoke();
        }

        /// <summary> Alter AP value. </summary>
        public void AlterAP(int diff)
        { SetAP(AP + diff); }

        /// <summary> Check for a Critical. </summary>
        public bool RollCrit()
        { return Random.value <= Crit * 0.01f; }

        /// <summary> Register character owner. </summary>
        public void Register(Character owner)
        {
            this.owner = owner;
            ValueUpdated?.Invoke();
        }

        #endregion
    }
}
