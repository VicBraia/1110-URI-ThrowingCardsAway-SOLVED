using System;
using System.Collections.Generic;

namespace ThrowingCardsAway
{
    class Program
    {
        public static List<int> Discarded = new List<int>();
        public static List<int> Stack = new List<int>();
        public static List<int> Sequence = new List<int>();
        public static int N;

        public static void CreateStack(int n)
        {
            for (int i = 0; i < n; i++)
            {
                Stack.Add(i + 1);
            }
        }

        public static void Discard()
        {
            Discarded.Add(Stack[0]);
            Stack.RemoveAt(0);
        }

        public static void InsertInTheEnd()
        {
            int tmp = Stack[0];
            Stack.RemoveAt(0);
            Stack.Add(tmp);
        }

        public static void Execute()
        {
            while (Stack.Count > 1)
            {
                Discard();
                InsertInTheEnd();
            }
        }

        public static void Print()
        {
            int i;
            Console.Write("Discarded cards: ");
            if (Discarded.Count > 0)
            {
                for (i = 0; i < Discarded.Count - 1; i++)
                {
                    Console.Write(Discarded[i] + ", ");
                }
                Console.WriteLine(Discarded[i]);
            }
            else
            {
                Console.WriteLine();
            }
            Console.WriteLine("Remaining card: " + Stack[0]);
        }

        public static void ClearLists()
        {
            Discarded.Clear();
            Stack.Clear();
        }

        static void Main(string[] args)
        {
            while ((N = int.Parse(Console.ReadLine())) != 0)
            {
                Sequence.Add(N);
            }
            for (int i = 0; i < Sequence.Count; i++)
            {
                CreateStack(Sequence[i]);
                Execute();
                Print();
                ClearLists();
            }
        }
    }
}
