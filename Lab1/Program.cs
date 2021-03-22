using System;
using System.Collections;

namespace Lab1
{
    internal class Program
    {
        static int N = 10;
        public static void listOutput(List<int> list)
        {
            foreach (var item in list)
            {
                Console.Write(item + ", ");
            }
            Console.WriteLine();
        }
        public static void testSorting()
        {
            string[] strings = {"sort", "this", "words", "AAAA", "please", "friend"};
            InsertingSort<string>.InsertionSort(strings);
            foreach (var str in strings)
            {
                Console.Write(str + " ");
            }
            Console.WriteLine();
            int[] numbers = new[] {3, 6, 1, -5, 0, 7, 23, 7, -27, -75, 2};
            InsertingSort<int>.InsertionSort(numbers);
            foreach (var number in numbers)
            {
                Console.Write(number + " ");
            }
            Console.WriteLine();
        }
        public static void testList()
        {
            List<int> m_list = new List<int>();
            for(int i = 0; i < N; i++)
                m_list.Add(i);
            Console.Write("output: "); listOutput(m_list);
            int pos = 7, data = -5;
            m_list.insert(pos,data);
            Console.Write("insert " + data +" in pos "+ pos +": "); listOutput(m_list);
            pos = 3;
            m_list.Remove(pos);
            Console.Write("remove from pos " + pos +": "); listOutput(m_list);
            
            m_list.RemoveFirst();
            Console.Write("remove the first element: "); listOutput(m_list);
            
            m_list.RemoveLast();
            Console.Write("remove the last element: "); listOutput(m_list);
            data = -10;
            m_list.AddFirst(data);
            Console.Write("add the fisrt element " + data +": "); listOutput(m_list);
            
            m_list.Reverse();
            Console.Write("reverse list: "); listOutput(m_list);
            
            m_list.Reverse();
            Console.Write("reverse list: ");listOutput(m_list);
        }

        public static void testBinaryTree()
        {
            BinaryTree<int> m_tree = new BinaryTree<int>();
            for (var i = 0; i < N; i++)
            {
                m_tree.Add(i);
            }
            m_tree.Remove(1);
            m_tree.Add(-6);
            BinaryTreeNode<int> node;
            if ((node = m_tree.FindNode(1)) != null)
            {
                Console.WriteLine("1 is find");
                Console.WriteLine("data " + node.Data);
            }
            else 
                Console.WriteLine("1 is not find");

            if ((node = m_tree.FindNode(-6)) != null)
            {
                Console.WriteLine("-6 is find");
                Console.WriteLine("data " + node.Data);
            }
            else Console.WriteLine("-6 is not find");

            if ((node = m_tree.FindNode(8)) != null)
            {
                Console.WriteLine("8 is find");
                Console.WriteLine("data " + node.Data);
            }
            else Console.WriteLine("8 is not find");

        }
        public static void Main(string[] args)
        {
            testList();
            testBinaryTree();
            testSorting();
        }
    }
}