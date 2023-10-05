using System;
using System.Text;

namespace AD;

/// <summary>
/// A generic Priority Queue class.
/// </summary>
/// <typeparam name="T">The type of elements in the queue. Must implement IComparable.</typeparam>
public class PriorityQueue<T> : IPriorityQueue<T>
    where T : IComparable<T>
{
    public static int DEFAULT_CAPACITY = 100;
    private int _capacity = DEFAULT_CAPACITY;
    public T[] array; // The heap array
    public int size; // Number of elements in the heap
    
    public PriorityQueue() : this(DEFAULT_CAPACITY)
    {
    }

    /// <summary>
    /// Initializes a new instance of the PriorityQueue class with specified capacity.
    /// </summary>
    /// <param name="capacity">The initial capacity.</param>
    private PriorityQueue(int capacity)
    {
        _capacity = capacity + 1;

        // Initialize the array
        array = new T[_capacity];

        size = 0;
    }

    /// <summary>
    /// Returns the current size of the priority queue.
    /// </summary>
    public int Size() => size;

    /// <summary>
    /// Clears the priority queue.
    /// </summary>
    public void Clear()
    {
        array = new T[_capacity];
        size = 0;
    }

    /// <summary>
    /// Adds an element to the PriorityQueue.
    /// </summary>
    /// <param name="x">The element to add.</param>
    public void Add(T x)
    {
        if (x == null) throw new ArgumentNullException();
        if (array.Length == size + 1) IncreaseSize();
        array[++size] = x;
        PercolateUp(x, size);
    }

    /// <summary>
    /// Removes and returns the smallest item in the PriorityQueue.
    /// </summary>
    /// <returns>The smallest item.</returns>
    public T Remove()
    {
        if (size == 0) throw new PriorityQueueEmptyException();

        var item = array[1];
        var lastItem = array[size];

        array[1] = lastItem;

        size--;

        PercolateDownRecursive(1);

        return item;
    }

    /// <summary>
    /// Adds an element to the priority queue without heapifying.
    /// </summary>
    /// <param name="x">Element to be added.</param>
    public void AddFreely(T x)
    {
        if (x == null) return;
        if (array.Length == size + 1) IncreaseSize();
        array[++size] = x;
    }

    /// <summary>
    /// Builds a heap from the internal array.
    /// </summary>
    public void BuildHeap()
    {
        for (var i = size / 2; i >= 1; i--)
            PercolateDown(i, true);
    }

    /// <summary>
    /// Increases the internal storage of the priority queue.
    /// </summary>
    public void IncreaseSize()
    {
        _capacity *= 2; // Double the capacity
        Array.Resize(ref array, _capacity);
    }

    /// <summary>
    /// Helper method to move the added element to its correct position upwards in the heap.
    /// </summary>
    /// <param name="x">The element to percolate up.</param>
    /// <param name="index">The starting index of the element.</param>
    /// <param name="recursive">Flag to choose between recursive or iterative method. Default is true.</param>
    private void PercolateUp(T x, int index, bool recursive = true)
    {
        if (recursive) PercolateUpRecursive(x, index);
        else PercolateUpIterative(x, index);
    }

    /// <summary>
    /// Recursively moves the element upwards to its correct position in the heap.
    /// </summary>
    /// <param name="x">The element to percolate up.</param>
    /// <param name="index">The starting index of the element.</param>
    public void PercolateUpRecursive(T x, int index)
    {
        // If we're at the top element, there's no need to recurse further.
        if (index <= 1) return;

        // Find the parent index
        var parentIndex = index / 2;

        // Grab the parent value
        var parent = array[parentIndex];

        // Compare the current value to its parent
        var comparison = x.CompareTo(parent);

        // Parent is equal or greater than value, so don't do anything
        if (comparison >= 0) return;

        // Else, swap values
        array[index] = array[parentIndex];
        array[parentIndex] = x;

        // Recursively percolate up
        PercolateUpRecursive(x, parentIndex);
    }

    /// <summary>
    /// Iteratively moves the element upwards to its correct position in the heap.
    /// </summary>
    /// <param name="x">The element to percolate up.</param>
    /// <param name="index">The starting index of the element.</param>
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

    /// <summary>
    /// Moves the element at the given index downwards to its correct position in the heap.
    /// </summary>
    /// <param name="index">The index of the element to be moved.</param>
    /// <param name="recursive">Flag to choose between recursive or iterative method. Default is true.</param>
    private void PercolateDown(int index, bool recursive = true)
    {
        if (recursive) PercolateDownRecursive(index);
        else PercolateDownIterative(index);
    }

    /// <summary>
    /// Recursively moves the element downwards to its correct position in the heap.
    /// </summary>
    /// <param name="index">The index of the element to be moved.</param>
    private void PercolateDownRecursive(int index)
    {
        var item = array[index];

        var leftChildIndex = index * 2;
        var rightChildIndex = index * 2 + 1;

        var leftChildComparison = 0;
        var rightChildComparison = 0;

        var smallerChildIndex = index;

        // If the item has a left child
        if (leftChildIndex <= size)
        {
            var leftChild = array[leftChildIndex];
            leftChildComparison = item.CompareTo(leftChild);
            if (leftChildComparison > 0) smallerChildIndex = leftChildIndex;

            // If the item has a right child
            if (rightChildIndex <= size)
            {
                var rightChild = array[rightChildIndex];
                rightChildComparison = item.CompareTo(rightChild);
                if (rightChildComparison > 0 && rightChild.CompareTo(leftChild) < 0)
                    smallerChildIndex = rightChildIndex;
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

    /// <summary>
    /// Iteratively moves the element downwards to its correct position in the heap.
    /// </summary>
    /// <param name="index">The index of the element to be moved.</param>
    private void PercolateDownIterative(int index)
    {
        while (index <= size / 2)
        {
            var leftChildIndex = index * 2;
            var rightChildIndex = leftChildIndex + 1;

            int smallerChildIndex;

            // Determine the index of the smaller child
            if (rightChildIndex <= size && array[rightChildIndex].CompareTo(array[leftChildIndex]) < 0)
                smallerChildIndex = rightChildIndex;
            else
                smallerChildIndex = leftChildIndex;

            // Compare the current element with the smaller child
            if (array[index].CompareTo(array[smallerChildIndex]) <= 0)
                // If the current element is smaller or equal to the smaller child, stop percolating down
                break;

            // Swap the current element with the smaller child
            (array[index], array[smallerChildIndex]) = (array[smallerChildIndex], array[index]);

            // Move to the child's position
            index = smallerChildIndex;
        }
    }

    /// <summary>
    /// Converts the priority queue to its string representation.
    /// </summary>
    /// <returns>String representation of the priority queue.</returns>
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