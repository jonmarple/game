using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Toast.Game.Characters;

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
        [SerializeField] private TextMeshProUGUI pModField;
        [SerializeField] private TextMeshProUGUI mModField;

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
            SetCharListeners(true);
        }

        private void OnDisable()
        {
            CharacterSelector.SelectUpdated -= Refresh;
            CharacterSelector.HoverUpdated -= Refresh;
            SetCharListeners(false);
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
            SetCharListeners(false);
            this.character = character;
            SetCharListeners(true);

            if (character != null)
            {
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
                pModField.SetText(character.Stats.PhysicalMod.ToString());
                mModField.SetText(character.Stats.MagicalMod.ToString());
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

        private void SetCharListeners(bool active)
        {
            if (character != null)
            {
                if (active)
                {
                    character.Stats.ValueUpdated += Refresh;
                    character.Equipment.Armor.ValueUpdated += Refresh;
                    character.ShardBuffer.BufferUpdated += Refresh;
                }
                else
                {
                    character.Stats.ValueUpdated -= Refresh;
                    character.Equipment.Armor.ValueUpdated -= Refresh;
                    character.ShardBuffer.BufferUpdated -= Refresh;
                }
            }
        }

        #endregion
    }
}
