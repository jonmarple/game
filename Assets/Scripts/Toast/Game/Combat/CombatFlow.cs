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
        public static bool Finished { get; private set; }
        public static int Index { get; private set; }

        /* Private Fields */
        private static bool InRange { get { return Order != null && 0 <= Index && Index < Order.Count; } }

        #region PUBLIC

        /// <summary> Reset values/state. </summary>
        public static void Reset()
        {
            Active = false;
            Finished = false;
            Index = -1;
            GroupA = null;
            GroupB = null;
            Order = null;
        }

        /// <summary> Initialize combat with specified groups. </summary>
        public static void Initialize(CharacterGroup groupA, CharacterGroup groupB)
        {
            Active = true;
            Finished = false;
            Index = -1;
            GroupA = groupA;
            GroupB = groupB;
            InitializeAI();
            DetermineOrder();
        }

        /// <summary> Advance combat to next step. </summary>
        public static void Step()
        {
            if (Active && !Finished)
            {
                if (Index == -1) StartRound();
                else if (Index >= Order.Count) FinishRound();
                else if (InRange) ProcessTurn();
                Index += 1;

                CheckFinished();
            }
            else Debug.LogWarning("Failed to advance combat--no active instance of combat present.");
        }

        #endregion

        #region PRIVATE

        private static void StartRound()
        {
            Debug.Log("Starting combat round.");
        }

        private static void FinishRound()
        {
            Debug.Log("Finishing combat round.");
            Index = -1;
        }

        private static void ProcessTurn()
        {
            Debug.Log("Processing turn for " + Order[Index].CharacterName + ".");
            Order[Index].Process();
        }

        private static void CheckFinished()
        {
            if (!GroupA.Active || !GroupB.Active)
                FinishCombat();
        }

        private static void FinishCombat()
        {
            Finished = true;
            Index = -1;
        }

        /// <summary> Initialize Character AI modules. </summary>
        private static void InitializeAI()
        {
            foreach (Character character in GroupA.Characters)
                character.AI?.Initialize(character, GroupA, GroupB);
            foreach (Character character in GroupB.Characters)
                character.AI?.Initialize(character, GroupB, GroupA);
        }

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
            sortedInitiatives.Reverse();

            Character[] sortedCharacters = (from kvp in sortedInitiatives select kvp.Key).ToArray();
            Order = new List<Character>(sortedCharacters);
        }

        #endregion
    }
}
