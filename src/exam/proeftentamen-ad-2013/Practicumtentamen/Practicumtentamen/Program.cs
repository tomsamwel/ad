// See https://aka.ms/new-console-template for more information

using AD;

static void printLetters(int n)
{
    if (n <= 0) return;
    Console.Write("A");
    printLetters(--n);
    Console.Write("Z");
}

static void printLetters2(int n, int q)
{
    if (n > 0)
    {
        Console.Write("A");
        printLetters2(--n, q);
        return;
    }
    if (q <= 0) return;
    
    Console.Write("Z");
    printLetters2(n, --q);
}

Console.WriteLine("Opgave 1 A");
Console.WriteLine("\nprintLetters(3) geeft AAAZZZ");
printLetters(3);
Console.WriteLine("\nprintLetters(0) print niks");
printLetters(0);

Console.WriteLine("\n");
Console.WriteLine("Opgave 1 B");
Console.WriteLine("\nprintLetters2(3, 5) geeft AAAZZZZZ");
printLetters2(3,5);

Console.WriteLine("\nprintLetters2(2,0) print AA");
printLetters2(2,0);

Console.WriteLine("\nOpgave 2 (Binary Search Tree, 20 punten)");
var bst = new BinarySearchTree<int>();
bst.BulkInsert(new List<int> { 6,2,8,1,4,3 });
Console.WriteLine("bst.FindMin() geeft 1: " + bst.FindMin());
Console.WriteLine("bst.FindMinParent() geeft 2: " + bst.FindSecondMin());
Console.WriteLine(bst.ToString());
Console.WriteLine("bst.RemoveMin()");
bst.RemoveMin();
Console.WriteLine(bst.ToString());
Console.WriteLine("bst.FindMin() geeft 2: " + bst.FindMin());
Console.WriteLine("bst.FindMinParent() geeft 3: " + bst.FindSecondMin());

