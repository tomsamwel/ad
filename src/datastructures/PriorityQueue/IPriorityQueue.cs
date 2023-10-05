using System;

namespace AD;

public interface IPriorityQueue<T>
    where T : IComparable<T>
{
    //----------------------------------------------------------------------
    // Methods that have to be implemented for exam
    //----------------------------------------------------------------------
    int Size();

    void Clear();

    void Add(T x);

    T Remove();

    //----------------------------------------------------------------------
    // Methods that have to be implemented for homework
    //----------------------------------------------------------------------

    // AddFreely adds a new item to the internal array. It will NOT use
    // the method "PercolateUp" to maintain the rules of a priority queue.
    // If you want to test BuildHeap, you can use AddFreely to build a non-prioritized
    // array and then run BuildHeap to create a proper heap
    void AddFreely(T x);

    void BuildHeap();
}

public class PriorityQueueEmptyException : Exception
{
    // Is thrown when Remove is called on an empty queue
}