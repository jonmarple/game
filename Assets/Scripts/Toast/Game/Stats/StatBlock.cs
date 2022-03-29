using System.Collections;
using System.Collections.Generic;
using UnityEngine;
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
        public List<DamageModifier> DamageModifiers { get; private set; }
        public bool Dead { get { return HP <= 0; } }

        public StatBlock(int hp, int hpMax, int ap, int apMax, int apRegen, int crit, Spread initiative, List<DamageModifier> modifiers)
        {
            HPMax = hpMax;
            APMax = apMax;
            APRegen = apRegen;
            SetHP(hp);
            SetAP(ap);
            Crit = crit;
            Initiative = initiative;
            DamageModifiers = modifiers;
        }

        #region PUBLIC

        /// <summary> Set HP value. </summary>
        public void SetHP(int hp)
        { HP = Mathf.Clamp(hp, 0, HPMax); }

        /// <summary> Alter HP value. </summary>
        public void AlterHP(int diff)
        { SetHP(HP + diff); }

        /// <summary> Set AP value. </summary>
        public void SetAP(int ap)
        { AP = Mathf.Clamp(ap, 0, APMax); }

        /// <summary> Alter AP value. </summary>
        public void AlterAP(int diff)
        { SetAP(AP + diff); }

        /// <summary> Check for a Critical. </summary>
        public bool RollCrit()
        { return Random.value <= Crit * 0.01f; }

        #endregion
    }
}
