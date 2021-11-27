using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Toast.Game.Stats
{
    /// <summary>
    /// System-serializable stat information container.
    /// </summary>
    [System.Serializable]
    public class StatBlock
    {
        /* Public Fields */
        public int HP { get { return hp; } }
        public int HPMax { get { return hpMax; } }
        public int AP { get { return ap; } }
        public int APMax { get { return apMax; } }

        /* Private Fields */
        private int hp;
        private int hpMax;
        private int ap;
        private int apMax;

        #region PUBLIC

        public StatBlock(int hp, int hpMax, int ap, int apMax)
        {
            this.hp = hp;
            this.hpMax = hpMax;
            this.ap = ap;
            this.apMax = apMax;
        }

        /// <summary>
        /// Set HP value.
        /// Limited to {0 - HPMax}.
        /// </summary>
        public void SetHP(int hp)
        {
            this.hp = Mathf.Clamp(hp, 0, hpMax);
        }

        /// <summary>
        /// Set AP value.
        /// Limited to {0 - APMax}.
        /// </summary>
        public void SetAP(int ap)
        {
            this.ap = Mathf.Clamp(ap, 0, apMax);
        }

        #endregion

        #region PRIVATE
        #endregion
    }
}
