using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Toast.Game.Characters;
using Toast.Utility;

namespace Toast.Game.Combat
{
    /// <summary>
    /// Orchestrate combat.
    /// </summary>
    public static class CombatFlow
    {
        /* Public Fields */
        public static List<Character> Order { get; private set; }
        public static CharacterGroup GroupA { get; private set; }
        public static CharacterGroup GroupB { get; private set; }
        public static bool Active { get; private set; }
        public static int Index { get; private set; }

        /* Private Fields */
        private static bool InRange { get { return Order != null && 0 <= Index && Index < Order.Count; } }

        #region PUBLIC

        /// <summary> Reset values/state. </summary>
        public static void Reset()
        {
            Active = false;
            Order = null;
            GroupA = null;
            GroupB = null;
            Index = -1;
        }

        /// <summary> Initialize combat with specified groups. </summary>
        public static void Initialize(CharacterGroup groupA, CharacterGroup groupB)
        {
            Active = true;
            GroupA = groupA;
            GroupB = groupB;
            Index = -1;
            DetermineOrder();
        }

        /// <summary> Advance combat to next step. </summary>
        public static void Step()
        {
            if (Active)
            {
                if (Index == -1) StartRound();
                else if (Index >= Order.Count) FinishRound();
                else if (InRange) StartTurn();
                else Debug.LogError("This code should be unreachable.");
                Index += 1;
            }
            else Debug.LogWarning("Failed to advance combat--no active instance of combat present.");
        }

        #endregion

        #region PRIVATE

        private static void StartRound()
        { Debug.Log("Starting combat round."); }

        private static void FinishRound()
        { Index = -1; Debug.Log("Finishing combat round."); }

        private static void StartTurn()
        { Debug.Log("Starting turn for " + Order[Index].CharacterName + "."); }

        /// <summary> Determine order of combat based on initiative. </summary>
        private static void DetermineOrder()
        {
            Dictionary<Character, int> initiatives = new Dictionary<Character, int>();
            foreach (Character character in GroupA.Characters)
                initiatives.Add(character, character.Stats.Initiative.Roll());
            foreach (Character character in GroupB.Characters)
                initiatives.Add(character, character.Stats.Initiative.Roll());

            List<KeyValuePair<Character, int>> sortedInitiatives = initiatives.ToList();
            sortedInitiatives.Shuffle();
            sortedInitiatives.Sort((pair1, pair2) => pair1.Value.CompareTo(pair2.Value));

            Character[] sortedCharacters = (from kvp in sortedInitiatives select kvp.Key).ToArray();
            Order = new List<Character>(sortedCharacters);
        }

        #endregion
    }
}
