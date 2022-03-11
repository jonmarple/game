using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Toast.Game.Stats
{
    /// <summary>
    /// Character Stats.
    /// </summary>
    [System.Serializable]
    public class StatBlock
    {
        /* Public Fields */
        public int HP { get { return hp; } }
        public int HPMax { get { return hpMax; } }
        public int AP { get { return ap; } }
        public int APMax { get { return apMax; } }
        public int Shield { get { return shield; } }

        /* Private Fields */
        private int hp;
        private int hpMax;
        private int ap;
        private int apMax;
        private int shield;

        public StatBlock(int hp, int hpMax, int ap, int apMax)
        {
            this.hp = hp;
            this.hpMax = hpMax;
            this.ap = ap;
            this.apMax = apMax;
            this.shield = 0;
        }

        public StatBlock(int hp, int hpMax, int ap, int apMax, int shield)
        {
            this.hp = hp;
            this.hpMax = hpMax;
            this.ap = ap;
            this.apMax = apMax;
            this.shield = shield;
        }

        #region PUBLIC

        /// <summary> Set HP value. </summary>
        public void SetHP(int hp)
        { this.hp = Mathf.Clamp(hp, 0, hpMax); }

        /// <summary> Alter HP value. </summary>
        public void AlterHP(int diff)
        { SetHP(this.hp + diff); }

        /// <summary> Set AP value. </summary>
        public void SetAP(int ap)
        { this.ap = Mathf.Clamp(ap, 0, apMax); }

        /// <summary> Alter AP value. </summary>
        public void AlterAP(int diff)
        { SetAP(this.ap + diff); }

        /// <summary> Set Shield value. </summary>
        public void SetShield(int shield)
        { this.shield = Mathf.Clamp(shield, 0, int.MaxValue); }

        /// <summary> Alter Shield value. </summary>
        public void AlterShield(int diff)
        { SetShield(shield + diff); }

        #endregion

        #region PRIVATE
        #endregion
    }
}
