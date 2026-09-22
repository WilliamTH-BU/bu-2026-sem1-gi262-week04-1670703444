using UnityEngine;
using System.Collections.Generic;
using System.Linq;
using Solution;

namespace Assignment
{
    public class Assignment : MonoBehaviour
    {
        public void Start()
        {
            // AS01_CountWords();
            // AS02_CountNumber();
            // AS03_CheckValidBrackets();
            // AS04_PrintReverseLinkedList();
            // AS05_FindMiddleElement();
            // AS06_MergeDictionaries();
            // AS07_RemoveDuplicatesFromLinkedList();
            // AS08_TopFrequentNumber();
            // AS09_PlayerInventory();
            // AS10_GameEventQueue();
            // AS11_PlayerStatsTracker();
        }

        #region Assignment

        [Header("AS01 - Count Words")]
        [SerializeField] private string[] as01Words;

        public void AS01_CountWords()
        {
            string[] words = as01Words;
            Dictionary<string, int> wordCounts = new Dictionary<string, int>();
            foreach (string _word in words)
            {
                if (wordCounts.ContainsKey(_word))
                {
                    wordCounts[_word]++;
                }
                else
                {
                    wordCounts.Add(_word, 1);
                }
            }
            foreach (var pair in wordCounts)
            {
                Debug.Log($"word: '{pair.Key}' count: {pair.Value}");
            }
        }

        [Header("AS02 - Count Number")]
        [SerializeField] private int[] as02Numbers;

        public void AS02_CountNumber()
        {
            int[] numbers = as02Numbers;
            Dictionary<int,int> keyValuePairs = new Dictionary<int,int>();
            foreach (var pair in numbers)
            {
                if (keyValuePairs.ContainsKey(pair))
                {
                    keyValuePairs[pair]++;
                }
                else
                {
                    keyValuePairs.Add(pair, 1);
                }
            }
            foreach (var i  in keyValuePairs)
            {
                Debug.Log($"number: {i.Key} count: {i.Value}");
            }
        }

        [Header("AS03 - Check Valid Brackets")]
        [SerializeField] private string as03Input;

        public void AS03_CheckValidBrackets()
        {
            string input = as03Input;
            Dictionary<char, char> bracketPairs = new Dictionary<char, char>()
            {
                { '(', ')' },
                { '[', ']' },
                { '{', '}' }
            };
            LinkedList<char> list = new LinkedList<char>();
            foreach (var c in input)
            {
                if (bracketPairs.ContainsKey(c))
                {
                    list.AddLast(c);
                }
                else if (bracketPairs.ContainsValue(c))
                {
                    if (list.Count == 0)
                    {
                        Debug.Log("Invalid");
                        return;
                    }
                    
                    char lastBracket = list.Last.Value;
                    if (bracketPairs[lastBracket] == c)
                    {
                        list.RemoveLast();
                    }
                    else
                    {
                        Debug.Log("Invalid");
                        return;
                    }
                }
            }
            if (list.Count == 0)
            {
                Debug.Log("Valid");
            }
            else
            {
                Debug.Log("Invalid");
            }
        }

        [Header("AS04 - Print Reverse Linked List")]
        [SerializeField] private IntLinkedListInput as04List = new IntLinkedListInput();

        public void AS04_PrintReverseLinkedList()
        {
            LinkedList<int> list = as04List.GetLinkedList();
            if (list.Count == 0)
            {
                Debug.Log("List is empty");
                return;
            }
            LinkedListNode<int> currentNode = list.Last;
            while (currentNode != null)
            {
                Debug.Log(currentNode.Value);
                currentNode = currentNode.Previous;
            }

        }

        [Header("AS05 - Find Middle Element")]
        [SerializeField] private StringLinkedListInput as05List = new StringLinkedListInput();

        public void AS05_FindMiddleElement()
        {
            LinkedList<string> list = as05List.GetLinkedList();
            if (list.Count == 0)
            {
                Debug.Log("List is empty");
                return;
            }
            LinkedListNode<string> slowNode = list.First;
            LinkedListNode<string> fastNode = list.First;
            while (fastNode != null && fastNode.Next != null)
            {
                slowNode = slowNode.Next;
                fastNode = fastNode.Next.Next;
            }
            Debug.Log(slowNode.Value);
            //throw new System.NotImplementedException();
        }

        [Header("AS06 - Merge Dictionaries")]
        [SerializeField] private StringIntDictionaryInput as06FirstDictionary = new StringIntDictionaryInput();
        [SerializeField] private StringIntDictionaryInput as06SecondDictionary = new StringIntDictionaryInput();

        public void AS06_MergeDictionaries()
        {
            Dictionary<string, int> dict1 = as06FirstDictionary.GetDictionary();
            Dictionary<string, int> dict2 = as06SecondDictionary.GetDictionary();

            Dictionary<string, int> mergedDictionary = new Dictionary<string, int>(dict1);
            foreach (KeyValuePair<string, int> pair in dict2)
            {
                if (mergedDictionary.ContainsKey(pair.Key))
                {
                    mergedDictionary[pair.Key] += pair.Value;
                }
                else
                {
                    mergedDictionary.Add(pair.Key, pair.Value);
                }
            }
            foreach (var pair in mergedDictionary)
            {
                Debug.Log($"key: {pair.Key}, value: {pair.Value}");
            }
        }

        [Header("AS07 - Remove Duplicates From Linked List")]
        [SerializeField] private IntLinkedListInput as07List = new IntLinkedListInput();

        public void AS07_RemoveDuplicatesFromLinkedList()
        {
            LinkedList<int> list = as07List.GetLinkedList();
            if (list.Count <= 1)
            {
                foreach (var val in list)
                {
                    Debug.Log(val);
                }
                return;
            }
            Dictionary<int, bool> seenDict = new Dictionary<int, bool>();
            LinkedListNode<int> currentNode = list.First;
            while (currentNode != null)
            {
                LinkedListNode<int> nextNode = currentNode.Next;
                if (seenDict.ContainsKey(currentNode.Value))
                {
                    list.Remove(currentNode);
                }
                else
                {
                    seenDict.Add(currentNode.Value, true);
                }
                currentNode = nextNode;
            }
            foreach (int val in list)
            {
                Debug.Log(val);
            }
        }

        [Header("AS08 - Top Frequent Number")]
        [SerializeField] private int[] as08Numbers;

        public void AS08_TopFrequentNumber()
        {
            int[] numbers = as08Numbers;
            if (numbers == null || numbers.Length == 0)
            {
                Debug.Log("Input array is empty");
                return;
            }
            Dictionary<int, int> frequency = new Dictionary<int ,int>();
            foreach (var num  in numbers)
            {
                if (frequency.ContainsKey(num))
                {
                    frequency[num]++;
                }
                else
                {
                    frequency.Add(num, 1);
                }
            }
            int topNumber = numbers[0];
            int maxCount = frequency[topNumber];

            foreach (int num in numbers)
            {
                if (frequency[num] > maxCount)
                {
                    maxCount = frequency[num];
                    topNumber = num;
                }
            }
            Debug.Log($"{topNumber} count: {maxCount}");
        }

        [Header("AS09 - Player Inventory")]
        [SerializeField] private StringIntDictionaryInput as09Inventory = new StringIntDictionaryInput();
        [SerializeField] private string as09ItemName;
        [SerializeField] private int as09Quantity;

        public void AS09_PlayerInventory()
        {
            Dictionary<string, int> inventory = as09Inventory.GetDictionary();
            string itemName = as09ItemName;
            int quantity = as09Quantity;

            if (inventory.ContainsKey(itemName))
            {
                inventory[itemName] += quantity;
            }
            else
            {
                inventory.Add(itemName, quantity);
            }
            foreach (var pair in inventory)
            {
                Debug.Log($"{pair.Key}: {pair.Value}");
            }
        }

        [Header("AS10 - Game Event Queue")]
        [SerializeField] private GameEventLinkedListInput as10EventQueue = new GameEventLinkedListInput();

        public void AS10_GameEventQueue()
        {
            LinkedList<GameEvent> eventQueue = as10EventQueue.GetLinkedList();
            if (eventQueue.Count == 0)
            {
                Debug.Log("Event queue is empty");
                return;
            }
            while (eventQueue.Count > 0)
            {
                GameEvent currentEvent = eventQueue.First.Value;

                eventQueue.RemoveFirst();
                Debug.Log($"Processing event: {currentEvent.Name}");
                Debug.Log($"Remaining events in queue: {eventQueue.Count}");

                switch (currentEvent.EventType.ToLower())
                {
                    case "enemy":
                        Debug.Log($"Enemy event processed - {currentEvent.Name}");
                        break;
                    case "powerup":
                        Debug.Log($"Power-up event processed - {currentEvent.Name}");
                        break;
                    case "level":
                        Debug.Log($"Level event processed - {currentEvent.Name}");
                        break;
                }
            }
        }

        [Header("AS11 - Player Stats Tracker")]
        [SerializeField] private StringIntDictionaryInput as11PlayerStats = new StringIntDictionaryInput();
        [SerializeField] private string as11StatName;
        [SerializeField] private int as11Value;

        public void AS11_PlayerStatsTracker()
        {
            Dictionary<string, int> playerStats = as11PlayerStats.GetDictionary();
            string statName = as11StatName;
            int value = as11Value;

            if (playerStats.ContainsKey(statName))
            {
                playerStats[statName] += value;
            }
            else
            {
                playerStats.Add(statName, value);
            }

            Debug.Log($"Updated {statName}: {playerStats[statName]}");
            Debug.Log("Current player statistics:");

            foreach (var pair in playerStats)
            {
                Debug.Log($"{pair.Key}: {pair.Value}");
            }
        }

        #endregion
    }
}
