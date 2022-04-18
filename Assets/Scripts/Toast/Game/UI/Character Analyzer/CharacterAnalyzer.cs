using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Toast.Game.Characters;
using Toast.Game.Shards;

namespace Toast.Game.UI
{
    /// <summary>
    /// Character Analysis Console.
    /// </summary>
    public class CharacterAnalyzer : MonoBehaviour
    {
        /* Serialized Fields */
        [SerializeField] private CanvasGroup canvasGroup;
        [SerializeField] private float fadeSpeed = 10f;

        [Header("Text Fields")]
        [SerializeField] private TextMeshProUGUI nameField;
        [SerializeField] private TextMeshProUGUI hpField;
        [SerializeField] private TextMeshProUGUI apField;
        [SerializeField] private TextMeshProUGUI armorField;
        [SerializeField] private TextMeshProUGUI paField;
        [SerializeField] private TextMeshProUGUI maField;
        [SerializeField] private TextMeshProUGUI weaponField;
        [SerializeField] private TextMeshProUGUI pdField;
        [SerializeField] private TextMeshProUGUI mdField;
        [SerializeField] private TextMeshProUGUI smField;
        [SerializeField] private TextMeshProUGUI sapField;
        [SerializeField] private TextMeshProUGUI samField;
        [SerializeField] private TextMeshProUGUI sdpField;
        [SerializeField] private TextMeshProUGUI sdmField;

        /* Private Fields */
        private Character character;
        private float targetAlpha = 0f;

        private void Start()
        {
            StartCoroutine(HandleAlpha());
            Refresh();
        }

        private void OnEnable()
        {
            CharacterSelector.SelectUpdated += Refresh;
            CharacterSelector.HoverUpdated += Refresh;

            if (character != null)
            {
                character.Stats.ValueUpdated += Refresh;
                character.Equipment.Armor.ValueUpdated += Refresh;
                character.ShardBuffer.BufferUpdated += Refresh;
            }
        }

        private void OnDisable()
        {
            CharacterSelector.SelectUpdated -= Refresh;
            CharacterSelector.HoverUpdated -= Refresh;

            if (character != null)
            {
                character.Stats.ValueUpdated -= Refresh;
                character.Equipment.Armor.ValueUpdated -= Refresh;
                character.ShardBuffer.BufferUpdated -= Refresh;
            }
        }

        #region PUBLIC

        public void Refresh()
        {
            if (CharacterSelector.HoveredCharacter != null)
                SetInfo(CharacterSelector.HoveredCharacter);
            else if (CharacterSelector.SelectedCharacter != null)
                SetInfo(CharacterSelector.SelectedCharacter);
            else
                SetInfo(null);

            targetAlpha = CharacterSelector.HoveredCharacter != null || CharacterSelector.SelectedCharacter != null ? 1f : 0f;
        }

        #endregion

        #region PRIVATE

        private void SetInfo(Character character)
        {
            if (this.character != null)
            {
                this.character.Stats.ValueUpdated -= Refresh;
                this.character.Equipment.Armor.ValueUpdated -= Refresh;
                this.character.ShardBuffer.BufferUpdated -= Refresh;
            }

            this.character = character;

            if (character != null)
            {
                character.Stats.ValueUpdated += Refresh;
                character.Equipment.Armor.ValueUpdated += Refresh;
                character.ShardBuffer.BufferUpdated += Refresh;

                nameField.SetText(character.CharacterName);
                hpField.SetText(string.Format("{0,3} / {1,-3}", character.Stats?.HP, character.Stats?.HPMax));
                apField.SetText(string.Format("{0,3} / {1,-3}", character.Stats?.AP, character.Stats?.APMax));
                armorField.SetText(character.Equipment?.Armor?.ItemName);
                paField.SetText(string.Format("{0,3} / {1,-3}", character.Equipment?.Armor?.Physical, character.Equipment?.Armor?.PhysicalMax));
                maField.SetText(string.Format("{0,3} / {1,-3}", character.Equipment?.Armor?.Magical, character.Equipment?.Armor?.MagicalMax));
                weaponField.SetText(character.Equipment?.Weapon?.ItemName);
                pdField.SetText(string.Format("{0,6}", character.Equipment?.Weapon?.Physical.ToString()));
                mdField.SetText(string.Format("{0,6}", character.Equipment?.Weapon?.Magical.ToString()));
                smField.SetText(string.Format("{0,2}", character.ShardBuffer?.MBuffer.ToString()));
                sapField.SetText(string.Format("{0,2}", character.ShardBuffer?.APBuffer.ToString()));
                samField.SetText(string.Format("{0,2}", character.ShardBuffer?.AMBuffer.ToString()));
                sdpField.SetText(string.Format("{0,2}", character.ShardBuffer?.DPBuffer.ToString()));
                sdmField.SetText(string.Format("{0,2}", character.ShardBuffer?.DMBuffer.ToString()));
            }
        }

        private IEnumerator HandleAlpha()
        {
            while (true)
            {
                yield return new WaitForEndOfFrame();
                canvasGroup.alpha = Mathf.Lerp(canvasGroup.alpha, targetAlpha, fadeSpeed * Time.deltaTime);
            }
        }

        #endregion
    }
}
