using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
        public int Shield { get; private set; }
        public Spread Initiative { get; private set; }
        public bool Dead { get { return HP <= 0; } }

        public StatBlock(int hp, int hpMax, int ap, int apMax, Spread initiative)
        {
            HPMax = hpMax;
            APMax = apMax;
            SetHP(hp);
            SetAP(ap);
            Initiative = initiative;
            Shield = 0;
        }

        public StatBlock(int hp, int hpMax, int ap, int apMax, Spread initiative, int shield)
        {
            HPMax = hpMax;
            APMax = apMax;
            SetHP(hp);
            SetAP(ap);
            Initiative = initiative;
            Shield = shield;
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

        /// <summary> Set Shield value. </summary>
        public void SetShield(int shield)
        { Shield = Mathf.Clamp(shield, 0, int.MaxValue); }

        /// <summary> Alter Shield value. </summary>
        public void AlterShield(int diff)
        { SetShield(Shield + diff); }

        #endregion

        #region PRIVATE
        #endregion
    }
}
