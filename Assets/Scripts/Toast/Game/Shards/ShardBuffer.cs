using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Toast.Game.Shards
{
    /// <summary>
    /// Shard modification buffer.
    /// </summary>
    public class ShardBuffer
    {
        /* Public Fields */
        public int APBuffer { get; private set; }
        public int AMBuffer { get; private set; }
        public int DPBuffer { get; private set; }
        public int DMBuffer { get; private set; }
        public int MBuffer { get; private set; }

        public ShardBuffer()
        { Reset(); }

        #region PUBLIC

        /// <summary> Reset Shard Buffers. </summary>
        public void Reset()
        {
            APBuffer = 0;
            AMBuffer = 0;
            DPBuffer = 0;
            DMBuffer = 0;
            MBuffer = 1;
        }

        /// <summary> Get Attack Buffer. </summary>
        public int GetAttackBuffer(bool physical)
        { return physical ? APBuffer : AMBuffer; }

        /// <summary> Get Defend Buffer. </summary>
        public int GetDefendBuffer(bool physical)
        { return physical ? DPBuffer : DMBuffer; }

        /// <summary> Set Attack Buffer. </summary>
        public void SetAttackBuffer(bool physical, int value)
        {
            if (physical) APBuffer = value;
            else AMBuffer = value;
        }

        /// <summary> Set Defend Buffer. </summary>
        public void SetDefendBuffer(bool physical, int value)
        {
            if (physical) DPBuffer = value;
            else DMBuffer = value;
        }

        /// <summary> Apply shard roll to buffer. </summary>
        public int AddRoll(Shard shard)
        {
            int value = shard.Spread.Roll() * MBuffer;
            MBuffer = 1;
            switch (shard)
            {
                case APShard apShard:
                    APBuffer += value;
                    break;
                case AMShard amShard:
                    AMBuffer += value;
                    break;
                case DPShard dpShard:
                    DPBuffer += value;
                    break;
                case DMShard dmShard:
                    DMBuffer += value;
                    break;
                case MShard mShard:
                    MBuffer = value;
                    break;
            }
            return value;
        }

        #endregion
    }
}
