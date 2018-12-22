using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LRUCacheLeetCodeSubmission
{
    /// <summary>
    /// Small class with some routines to debug leet code test cases.
    /// </summary>
    public static class DebuggingTests
    {
        /// <summary>
        /// Test 1
        /// </summary>
        public static void Test1()
        {
            LRUCache cache = new LRUCache(3 /* capacity */ );

            cache.Put(1, 1);
            cache.Put(2, 2);
            cache.Get(1);       // returns 1
            cache.Put(3, 3);    // evicts key 2
            cache.Get(2);       // returns -1 (not found)
            cache.Put(4, 4);    // evicts key 1
            cache.Get(1);       // returns -1 (not found)
            cache.Get(3);       // returns 3
            cache.Get(4);       // returns 4*/
        }

        /// <summary>
        /// Test 2
        /// </summary>
        public static void Test2()
        {
            LRUCache cache = new LRUCache(2 /* capacity */ );
            cache.Get(2);
            cache.Put(2, 6);
            cache.Get(1);
            cache.Put(1, 5);
            cache.Put(1, 2);
            cache.Get(1);
            cache.Get(2);
        }

        /// <summary>
        /// Test 3
        /// </summary>
        public static void Test3()
        {
            LRUCache cache = new LRUCache(2 /* capacity */ );
            cache.Put(2, 1);
            cache.Put(1, 1);
            cache.Put(2, 3);
            cache.Put(4, 1);
            cache.Get(1);
            cache.Get(2);
        }

        /// <summary>
        /// Test 4
        /// </summary>
        public static void Test4()
        {
            LRUCache cache = new LRUCache(3 /* capacity */ );
            cache.Put(1, 1);
            cache.Put(2, 2);
            cache.Put(3, 3);
            cache.Put(4, 4);
            cache.Get(4);
            cache.Get(3);
            cache.Get(2);
            cache.Get(1);
            cache.Put(5, 5);
            cache.Get(1);
            cache.Get(2);
            cache.Get(3);
            cache.Get(4);
            cache.Get(5);
        }
    }
}
