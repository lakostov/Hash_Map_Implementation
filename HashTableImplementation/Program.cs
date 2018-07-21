using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HashTableImplementation
{
    class Program
    {
        public class Node
        {
            public long Hash { get; set; }
            public string Key { get; set; }
            public int Value { get; set; }
            public Node Next { get; set; }
        }

        public class LinkedList
        {
            public Node Head { get; set; }

            public LinkedList()
            {
                Head = null;
            }

            public void AddNode(Node newNode)
            {
                Node currentNode;
                if (Head == null)
                {
                    Head = newNode;
                    newNode.Next = null;
                }
                else
                {
                    currentNode = Head;
                    while (currentNode.Next != null)
                    {
                        currentNode = currentNode.Next;
                    }

                    currentNode.Next = newNode;
                    newNode.Next = null;
                }
            }
        }

        public static LinkedList[] Map;

        static void Main(string[] args)
        {
            InitMap();
            Put("Jim", 1000);
            Put("John", 1040);
            Put("Sam", 5010);
            Put("Alice", 2000);

            Console.WriteLine(Get("Alice"));
            Console.WriteLine(Get("John"));
            Console.WriteLine(Get("Sam"));
            Console.WriteLine(Get("Jim"));
        }

        private static void InitMap()
        {
            Map = new LinkedList[16];
            for (int i = 0; i < Map.Length; i++)
            {
                Map[i] = new LinkedList();
            }
        }

        private static void Put(string k, int v)
        {
            var hash = Hash(k);
            var index = hash % (Map.Length - 1);
            Node newNode = new Node
            {
                Hash = hash,
                Key = k,
                Value = v,
                Next = null
            };

            Map[index].AddNode(newNode);
        }

        private static int Get(string k)
        {
            long hash = Hash(k);
            var index = hash % (Map.Length - 1);
            
            Node node = new Node();
            if (Map[index].Head.Key == k && Map[index].Head.Hash == hash)
            {
                node = Map[index].Head;
            }
            else
            {
                Node currentNode = Map[index].Head;
                while (currentNode.Next != null)
                {
                    if (currentNode.Key == k && currentNode.Hash == hash)
                    {
                        node = currentNode;
                    }
                    currentNode = currentNode.Next;
                }
            }
            
            return node.Value;
        }


        private static long Hash(string k)
        {
            StringBuilder sb = new StringBuilder();
            foreach (var ch in k.ToCharArray())
            {
                sb.Append((int)ch);
            }
            return long.Parse(sb.ToString());
        }
    }
}
