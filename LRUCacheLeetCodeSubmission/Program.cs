using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LRUCacheLeetCodeSubmission
{
    /// <summary>
    /// Main Class
    /// </summary>
    class Program
    {
        /// <summary>
        /// Starting Method
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            
            DebuggingTests.Test1();
            DebuggingTests.Test2();
            DebuggingTests.Test3();
            DebuggingTests.Test4();

            Console.ReadLine();
        }
    }

    /// <summary>
    /// LRUCache
    /// </summary>
    public class LRUCache
    {
        private Dictionary<int, Node> _memory;
        private int _capacity;
        private int _currentMemoryInUse;
        private Node _head;
        private Node _tail;

        /// <summary>
        /// Ctor
        /// </summary>
        /// <param name="capacity"></param>
        public LRUCache(int capacity)
        {
            _capacity = capacity;
            _memory = new Dictionary<int, Node>();
            _currentMemoryInUse = 0;
        }

        /// <summary>
        /// Get
        /// </summary>
        /// <param name="key">Key</param>
        /// <returns>Value</returns>
        public int Get(int key)
        {
            Node result;
            if (_memory.ContainsKey(key))
            {
                result = _memory[key];

                //Move node to head
                MoveToHead(result);

                return result.value;
             }
            
            return -1;
        }

        /// <summary>
        /// Put
        /// </summary>
        /// <param name="key">Key</param>
        /// <param name="value">Value</param>
        public void Put(int key, int value)
        {
            Node node;
  
            if (_memory.ContainsKey(key))
            {
                //Parameter key exists in hashmap
                node = _memory[key];
                node.value = value;
                MoveToHead(node);

                return;
            }
            
            node = new Node(key, value)
            {
                key = key,
                value = value
            };

            //Parameter key is new and there is capacity
            if (_currentMemoryInUse < _capacity)
            {               
                if (_head == null)
                {
                    _head = node;
                    _tail = node;
                    
                }
                else
                {
                    InsertAtHead(node);
                }

                _memory[key] = node;
                _currentMemoryInUse++;
            }
            //Parameter key is new and there is no capacity.
            else
            {
                var keyToRemove = _tail.key;

                if (_head != _tail)
                {
                    _tail.previous.next = null;
                    _tail = _tail.previous;
                }

                _memory.Remove(keyToRemove);
                _currentMemoryInUse--;
                InsertAtHead(node);
                _memory[key] = node;
                _currentMemoryInUse++;
            }
        }

        /// <summary>
        /// InsertAtHead
        /// </summary>
        /// <param name="node">Node</param>
        private void InsertAtHead(Node node)
        {
            node.previous = null;
            node.next = _head;
            _head.previous = node;
            _head = node;
        }

        /// <summary>
        /// MoveToHead
        /// </summary>
        /// <param name="node">Node</param>
        private void MoveToHead(Node node)
        {
            if (node.previous != null)
            {
                if (node.next == null)
                {
                    _tail = node.previous;
                }
                else
                {
                    node.next.previous = node.previous;
                }

                node.previous.next = node.next;
                InsertAtHead(node);
            }
        }

        /// <summary>
        /// Node
        /// </summary>
        protected class Node
        {
            public int value;
            public int key;
            public Node next;
            public Node previous;

            /// <summary>
            /// ctor
            /// </summary>
            /// <param name="key">Key</param>
            /// <param name="value">Value</param>
            public Node(int key, int value)
            {
                this.key = key;
                this.value = value;
                next = null;
                previous = null;
            }
        }
    }
}
