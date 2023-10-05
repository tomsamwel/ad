namespace AD;

/// <summary>
///     Represents a node in a binary tree.
/// </summary>
/// <typeparam name="T">The type of data stored in the node.</typeparam>
public class BinaryNode<T> : IBinaryNode<T>
{
    /// <summary>
    ///     The data stored in this node.
    /// </summary>
    public T data;

    /// <summary>
    ///     The left child of this node.
    /// </summary>
    public BinaryNode<T> left;

    /// <summary>
    ///     The right child of this node.
    /// </summary>
    public BinaryNode<T> right;

    /// <summary>
    ///     Default constructor for BinaryNode. Initializes data, left, and right to default values.
    /// </summary>
    public BinaryNode() : this(default, null, null)
    {
    }

    /// <summary>
    ///     Constructor for BinaryNode with specified data, left child, and right child.
    /// </summary>
    /// <param name="data">The data to store in the node.</param>
    /// <param name="left">The left child node.</param>
    /// <param name="right">The right child node.</param>
    public BinaryNode(T data, BinaryNode<T> left, BinaryNode<T> right)
    {
        this.data = data;
        this.left = left;
        this.right = right;
    }

    //----------------------------------------------------------------------
    // Interface methods that have to be implemented for exam
    //----------------------------------------------------------------------

    /// <summary>
    ///     Gets the data stored in this node.
    /// </summary>
    /// <returns>The data stored in the node.</returns>
    public T GetData()
    {
        return data;
    }

    /// <summary>
    ///     Gets the left child node.
    /// </summary>
    /// <returns>The left child node or null if it doesn't exist.</returns>
    public BinaryNode<T> GetLeft()
    {
        return left;
    }

    /// <summary>
    ///     Gets the right child node.
    /// </summary>
    /// <returns>The right child node or null if it doesn't exist.</returns>
    public BinaryNode<T> GetRight()
    {
        return right;
    }

    /// <summary>
    ///     Checks if this node has a left child.
    /// </summary>
    /// <returns>True if a left child exists, otherwise false.</returns>
    public bool HasLeft()
    {
        return left != null;
    }

    /// <summary>
    ///     Checks if this node has a right child.
    /// </summary>
    /// <returns>True if a right child exists, otherwise false.</returns>
    public bool HasRight()
    {
        return right != null;
    }

    /// <summary>
    ///     Checks if this node has any children (either left or right child).
    /// </summary>
    /// <returns>True if it has at least one child, otherwise false.</returns>
    public bool HasChildren()
    {
        return HasLeft() || HasRight();
    }

    /// <summary>
    ///     Counts the number of children this node has (0, 1, or 2).
    /// </summary>
    /// <returns>The number of children.</returns>
    public int CountChildren()
    {
        var count = 0;
        if (HasLeft()) count++;
        if (HasRight()) count++;
        return count;
    }
}