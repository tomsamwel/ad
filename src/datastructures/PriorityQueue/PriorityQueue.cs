using System;
using System.Text;

namespace AD;

public partial class PriorityQueue<T> : IPriorityQueue<T>
    where T : IComparable<T>
{
    public static int DEFAULT_CAPACITY = 100;
    private int _capacity = DEFAULT_CAPACITY;
    public int size;   // Number of elements in the heap
    public T[] array;  // The heap array

    //----------------------------------------------------------------------
    // Constructor
    //----------------------------------------------------------------------

    public PriorityQueue() : this(DEFAULT_CAPACITY) { }

    private PriorityQueue(int capacity)
    {
        _capacity = capacity + 1;

        // Initialize the array
        array = new T[_capacity];

        size = 0;
    }

    //----------------------------------------------------------------------
    // Interface methods that have to be implemented for the exam
    //----------------------------------------------------------------------

    public int Size()
    {
        return size;
    }

    public void Clear()
    {
        array = new T[_capacity];
        size = 0;
    }

    public void Add(T x)
    {
        if (x == null) throw new ArgumentNullException();
        if (array.Length == size + 1) IncreaseSize();
        array[++size] = x;
        PercolateUp(x, size);
    }

    public void IncreaseSize()
    {
        _capacity *= 2; // Double the capacity
        Array.Resize(ref array, _capacity);
    }
    private void PercolateUp(T x, int index, bool recursive = true)
    {
        if (recursive) PercolateUpRecursive(x, index);
        else PercolateUpIterative(x, index);
    }
    public void PercolateUpRecursive(T x, int index)
    {
        // If we're at the top element, there's no need to recurse further.
        if (index <= 1) return;

        // Find the parent index
        int parentIndex = index / 2;

        // Grab the parent value
        T parent = array[parentIndex];

        // Compare the current value to its parent
        int comparison = x.CompareTo(parent);

        // Parent is equal or greater than value, so don't do anything
        if (comparison >= 0) return;

        // Else, swap values
        array[index] = array[parentIndex];
        array[parentIndex] = x;

        // Recursively percolate up
        PercolateUpRecursive(x, parentIndex);
    }
    
    private void PercolateUpIterative(T x, int index)
    {
        int parentIndex;
        T parent;
    
        while (index > 1)
        {
            parentIndex = index / 2;
            parent = array[parentIndex];
        
            if (x.CompareTo(parent) < 0)
            {
                // If the current element is smaller than its parent, swap them
                array[index] = parent;
                array[parentIndex] = x;
                index = parentIndex;
            }
            else
            {
                // If the current element is in the correct position, stop percolating up
                break;
            }
        }
    }

    // Removes the smallest item in the priority queue
    public T Remove()
    {
        if (size == 0)
        {
            throw new PriorityQueueEmptyException();
        }

        var item = array[1];
        var lastItem = array[size];

        array[1] = lastItem;

        size--;

        PercolateDownRecursive(1);

        return item;
    }

    private void PercolateDown(int index, bool recursive)
    {
        if(recursive) PercolateDownRecursive(index);
        else PercolateDown(index);
    }

    private void PercolateDownRecursive(int index)
    {
        T item = array[index];

        int leftChildIndex = index * 2;
        int rightChildIndex = (index * 2) + 1;

        int leftChildComparison = 0;
        int rightChildComparison = 0;

        int smallerChildIndex = index;

        // If the item has a left child
        if (leftChildIndex <= size)
        {
            T leftChild = array[leftChildIndex];
            leftChildComparison = item.CompareTo(leftChild);
            if (leftChildComparison > 0) smallerChildIndex = leftChildIndex;

            // If the item has a right child
            if (rightChildIndex <= size)
            {
                T rightChild = array[rightChildIndex];
                rightChildComparison = item.CompareTo(rightChild);
                if (rightChildComparison > 0 && rightChild.CompareTo(leftChild) < 0) smallerChildIndex = rightChildIndex;
            }
        }

        // If a smaller child is found 
        if (smallerChildIndex != index)
        {
            // Swap the smallest with the current
            (array[index], array[smallerChildIndex]) = (array[smallerChildIndex], array[index]);
            PercolateDownRecursive(smallerChildIndex);
        }
    }
    
    private void PercolateDown(int index)
    {
        while (index <= size / 2)
        {
            int leftChildIndex = index * 2;
            int rightChildIndex = leftChildIndex + 1;

            int smallerChildIndex;

            // Determine the index of the smaller child
            if (rightChildIndex <= size && array[rightChildIndex].CompareTo(array[leftChildIndex]) < 0)
            {
                smallerChildIndex = rightChildIndex;
            }
            else
            {
                smallerChildIndex = leftChildIndex;
            }

            // Compare the current element with the smaller child
            if (array[index].CompareTo(array[smallerChildIndex]) <= 0)
            {
                // If the current element is smaller or equal to the smaller child, stop percolating down
                break;
            }

            // Swap the current element with the smaller child
            (array[index], array[smallerChildIndex]) = (array[smallerChildIndex], array[index]);

            // Move to the child's position
            index = smallerChildIndex;
        }
    }
    
    public void AddFreely(T x)
    {
        if (x == null) return;
        array[++size] = x;
    }

    public void BuildHeap()
    {
        for (int i = size; i >= 1; i--)
        { 
            if(i * 2 > size) continue;
            PercolateDownRecursive(i);
        }
    }

    public override string ToString()
    {
        var sb = new StringBuilder();
        for (var i = 1; i <= size; i++)
        {
            sb.Append(array[i]);
            sb.Append(' ');
        }

        return sb.ToString().Trim();
    }
}

