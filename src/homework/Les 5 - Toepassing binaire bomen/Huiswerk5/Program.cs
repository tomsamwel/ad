using System;

namespace AD;

internal class Program
{
    private static void Opgave1()
    {
        BinarySearchTree<int> bst;

        Console.WriteLine("\n=====   Opgave 1 : BST   =====\n");

        bst = new BinarySearchTree<int>();
        Console.WriteLine(bst);
        bst.Insert(3);
        bst.Insert(1);
        bst.Insert(4);
        bst.Insert(6);
        bst.Insert(9);
        bst.Insert(2);
        bst.Insert(5);
        bst.Insert(7);
        Console.WriteLine(bst.ToInfixString());
        Console.WriteLine(bst);
        bst.Remove(6);

        Console.WriteLine();

        bst = new BinarySearchTree<int>();
        bst.Insert(6);
        Console.WriteLine(bst.ToInfixString());
        bst.Insert(4);
        bst.Insert(7);
        bst.Insert(2);
        bst.Insert(5);
        Console.WriteLine(bst.ToInfixString());
        Console.WriteLine(bst);
    }


    private static void Opgave2()
    {
        var pq = new PriorityQueue<int>();

        Console.WriteLine("\n=====   Opgave 2 : PriorityQueue   =====\n");

        pq.Add(1);
        pq.Add(2);
        pq.Add(3);
        pq.Add(7);
        pq.Add(5);
        pq.Add(6);
        pq.Add(12);
        pq.Add(14);
        pq.Add(9);
        pq.Add(13);
        pq.Add(8);
        Console.WriteLine(pq); // 1 2 3 7 5 6 12 14 9 13 8
        pq.Remove();
        Console.WriteLine(pq); // 2 5 3 7 8 6 12 14 9 13
        pq.Remove();
        Console.WriteLine(pq); // 3 5 6 7 8 13 12 14 9
        pq.Remove();
        Console.WriteLine(pq); // 5 7 6 9 8 13 12 14
        pq.Remove();
        Console.WriteLine(pq); // 6 7 12 9 8 13 14
    }

    private static void Opgave3()
    {
        var pq = new PriorityQueue<int>();

        Console.WriteLine("\n===== Opgave 3 : BuildHeap =====\n");

        int[] elements = { 20, 19, 18, 17, 16, 15, 14, 13, 12, 11, 10, 9, 8, 7, 6, 5, 4, 3, 2, 1 };
        foreach (var element in elements)
            pq.AddFreely(element);

        Console.WriteLine(pq); // 20 19 18 17 16 15 14 13 12 11 10 9 8 7 6 5 4 3 2 1
        pq.BuildHeap();
        Console.WriteLine("After BuildHeap");
        Console.WriteLine(pq); // 1 2 6 3 10 8 7 4 12 11 19 9 15 18 14 5 13 17 20 16
    }

    private static void Main(string[] args)
    {
        Opgave1();
        Opgave2();
        Opgave3();
    }
}