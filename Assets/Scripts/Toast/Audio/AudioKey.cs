using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Toast.Audio
{
    /// <summary>
    /// Keys to Clips.
    /// </summary>
    public enum AudioKey
    {   // ALWAYS ADD TO BOTTOM OF LIST
        NONE,
        CHARACTER_HOVER,
        CHARACTER_SELECT,
        CHARACTER_DESELECT,
        ACTION_HOVER,
        ACTION_SELECT,
        ACTION_DESELECT,
        TURN_END,
        RESET_PROTOTYPE,
        LIGHT_ATTACK,
        HEAVY_ATTACK,
        REGEN,
        SHARD_ROLL,
        DAMAGE_DEALT,
        DAMAGE_DEALT_CRIT,
        HEALING_DEALT,
        HEALING_DEALT_CRIT,
        SHARD_BUFF_DEALT
    }   // ALWAYS ADD TO BOTTOM OF LIST
}
