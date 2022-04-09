using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityAtoms.BaseAtoms;
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
        public static LinkedList<Character> Order { get; private set; }
        public static CharacterGroup GroupA { get; private set; }
        public static CharacterGroup GroupB { get; private set; }
        public static Character CurrentCharacter { get { return Order.First(); } }
        public static bool Active { get; private set; }
        public static bool Finished { get; private set; }

        /* Private Fields */
        private static VoidEvent combatStart;
        private static VoidEvent combatFinish;
        private static VoidEvent turnStart;
        private static VoidEvent turnFinish;

        #region PUBLIC

        /// <summary> Reset values/state. </summary>
        public static void Reset()
        {
            Active = false;
            Finished = false;
            GroupA = null;
            GroupB = null;
            Order = null;
        }

        /// <summary> Initialize combat with specified groups. </summary>
        public static void Start(CharacterGroup groupA, CharacterGroup groupB, VoidEvent combatStart = null, VoidEvent combatFinish = null, VoidEvent turnStart = null, VoidEvent turnFinish = null)
        {
            Active = true;
            Finished = false;
            GroupA = groupA;
            GroupB = groupB;
            InitializeAI();
            DetermineOrder();
            CombatFlow.combatStart = combatStart;
            CombatFlow.combatFinish = combatFinish;
            CombatFlow.turnStart = turnStart;
            CombatFlow.turnFinish = turnFinish;
            Debug.Log("Starting Combat.");
            combatStart?.Raise();
            // move last character to first place so it is skipped in the first Step() call
            Order.AddFirst(Order.Last());
            Order.RemoveLast();
            Step();
        }

        /// <summary> Finish processing turn. </summary>
        public static void FinishTurn()
        {
            if (Active && !Finished)
            {
                turnFinish?.Raise();
                CheckFinished();
                if (Active && !Finished) Step();
            }
        }

        #endregion

        #region PRIVATE

        private static void Step()
        {
            CheckFinished();
            if (Active && !Finished)
            {
                do
                {
                    Order.AddLast(Order.First());
                    Order.RemoveFirst();
                } while (CurrentCharacter.Stats.Dead);
                ProcessTurn();
            }
        }

        private static void ProcessTurn()
        {
            Debug.Log("");
            Debug.Log("Processing turn for " + CurrentCharacter.CharacterName + ".");
            turnStart?.Raise();
            CurrentCharacter.Process();
        }

        private static void CheckFinished()
        {
            if (!GroupA.Active || !GroupB.Active)
                FinishCombat();
        }

        private static void FinishCombat()
        {
            Debug.Log("");
            Debug.Log("Finishing Combat.");
            combatFinish?.Raise();
            Finished = true;
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
            Order = new LinkedList<Character>(sortedCharacters);
        }

        #endregion
    }
}
