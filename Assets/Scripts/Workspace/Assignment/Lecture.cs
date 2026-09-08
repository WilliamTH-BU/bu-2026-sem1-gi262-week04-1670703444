using UnityEngine;
using System.Collections.Generic;
using System.Linq;

namespace Assignment
{
    public class Lecture : MonoBehaviour
    {
        public void Start()
        {
            // LCT01_SyntaxList();
            //LCT02_SyntaxLinkedList();
            // LCT03_SyntaxHashTable();
            LCT04_SyntaxDictionary();
        }

        #region Lecture

        public void LCT01_SyntaxList()
        {
            throw new System.NotImplementedException();
        }

        public void LCT02_SyntaxLinkedList()
        {
            LinkedList<string> linkedlist = new LinkedList<string>();
            // [Node 1]
            linkedlist.AddLast("Node1");
            // [Node 1] [Node 2]
            linkedlist.AddLast("Node2");
            // [Node 0] [Node 1] [Node 2]
            linkedlist.AddFirst("Node0");

            LinkedListNode<string> firstNode = linkedlist.First;
            Debug.Log("first: " +  firstNode.Value);

            LinkedListNode<string> lastNode = linkedlist.Last;
            Debug.Log("last: " +  lastNode.Value);

            Debug.Log("firstNode.Next: " + firstNode.Next.Value);
            Debug.Log("firstNode.Next.Next: " + firstNode.Next.Next.Value);

            Debug.Log("lastNode.Previous: " + lastNode.Previous.Value);
            Debug.Log("lastNode.Previous.Previous: " + lastNode.Previous.Previous.Value);
            Debug.Log("lastNode.Previous.Previous.Previous: " + lastNode.Previous.Previous.Previous.Value);

            if (firstNode.Previous.Value == null) Debug.Log("firstNode.Previous == null");
            if (lastNode.Next.Value == null) Debug.Log("lastNode.Next.Value == null");

            linkedlist.AddAfter(firstNode, "Node 0.5");
            linkedlist.AddBefore(lastNode, "Node 1.5");

            LinkedListNode<string> node1 = linkedlist.Find("Node 1");

            linkedlist.Remove("Node 1");
            linkedlist.Remove(node1);
            linkedlist.RemoveLast();
            linkedlist.RemoveFirst();

            linkedlist.Clear();
        }

        public void LCT03_SyntaxHashTable()
        {
            throw new System.NotImplementedException();
        }

        public void LCT04_SyntaxDictionary()
        {
            Dictionary<string, int> inv = new Dictionary<string, int>();
            var inv2 = new Dictionary<string, int>();

            // "Potion": 1
            inv.Add("Potion", 1);

            // "Potion": 1
            // "Apple": 10
            inv.Add("Apple", 10);

            // "Potion": 1
            // "Apple": 10
            // "Banana": 5
            inv["Banana"] = 5;

            // "Potion": 5
            // "Apple": 10
            // "Banana": 5
            inv["Potion"] = 5;

            var pickupItem = "Sword";
            inv[pickupItem] = 1;

            foreach (KeyValuePair<string, int> pair in inv)
            {
                string key = pair.Key;
                int value = pair.Value;
                Debug.Log($"Key: {key} value; {value}");
            }

            bool appleExits = inv.ContainsKey("Apple");
            Debug.Log(appleExits);

            bool keyExits = inv.ContainsKey("Key");
            Debug.Log(appleExits);

            inv.Remove("Apple");
            foreach (KeyValuePair<string, int> pair in inv)
            {
                string key = pair.Key;
                int value = pair.Value;
                Debug.Log($"Key: {key} value; {value}");
            }


        }
        #endregion
    }
}
