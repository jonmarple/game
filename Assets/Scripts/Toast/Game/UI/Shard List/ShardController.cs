using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Toast.Game.Shards;
using Toast.UI;

namespace Toast.Game.UI
{
    /// <summary>
    /// Controller for a Shard.
    /// </summary>
    public class ShardController : ActionButton
    {
        /* Public Fields */
        public Shard Shard { get; private set; }

        /* Serialized Fields */
        [SerializeField] private RectLerp lerp;
        [SerializeField] private Image bg;
        [SerializeField] private Color attackColor;
        [SerializeField] private Color defenseColor;
        [SerializeField] private Color multColor;
        [SerializeField] private TextMeshProUGUI title;
        [SerializeField] private TextMeshProUGUI value;

        #region PUBLIC

        /// <summary> Initialize shard info. </summary>
        public void Initialize(Shard shard, RectTransform target)
        {
            Shard = shard;
            switch (Shard)
            {
                case APShard s:
                    title.text = "Attack\nPhysical";
                    bg.color = attackColor;
                    break;
                case AMShard s:
                    title.text = "Attack\nMagical";
                    bg.color = attackColor;
                    break;
                case DPShard s:
                    title.text = "Defense\nPhysical";
                    bg.color = defenseColor;
                    break;
                case DMShard s:
                    title.text = "Defense\nMagical";
                    bg.color = defenseColor;
                    break;
                case MShard s:
                    title.text = "Multiplicative";
                    bg.color = multColor;
                    break;
                default:
                    title.text = "???";
                    break;
            }
            value.text = Shard.Spread.ToString();
            SetAction(Shard.Roll);
            lerp.SetTarget(target);
            Refresh();
        }

        public override void Refresh()
        {
            base.Refresh();
            Color c = bg.color;
            c.a = button.interactable ? 1f : 0.1f;
            bg.color = c;
        }

        #endregion
    }
}
