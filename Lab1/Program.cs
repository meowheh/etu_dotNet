using System;

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
        public static void Main(string[] args)
        {
            testList();
        }
    }
}