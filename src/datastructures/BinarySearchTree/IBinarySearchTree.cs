using System;

namespace AD;

public interface IBinarySearchTree<T> : IBinaryTree<T>
    where T : IComparable<T>
{
    void Insert(T x);
    T FindMin();
    void RemoveMin();
    void Remove(T x);
    string InOrder();
}

public class BinarySearchTreeElementNotFoundException : Exception
{
    // Is thrown when Remove gets parameter that is not in the tree
}

public class BinarySearchTreeEmptyException : Exception
{
    // Is thrown when RemoveMin or FindMin is called on empty tree
}

public class BinarySearchTreeDoubleKeyException : Exception
{
    // Is thrown when same element is inserted twice
}