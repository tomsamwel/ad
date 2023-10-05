using System;
using System.Text;

namespace AD;

/// <summary>
///     Represents a binary search tree.
/// </summary>
/// <typeparam name="T">The type of data stored in the tree.</typeparam>
public class BinarySearchTree<T> : BinaryTree<T>, IBinarySearchTree<T>
    where T : IComparable<T>
{
    //----------------------------------------------------------------------
    // Interface methods that have to be implemented for exam
    //----------------------------------------------------------------------

    /// <summary>
    ///     Inserts a new element into the binary search tree.
    /// </summary>
    /// <param name="x">The element to insert.</param>
    public void Insert(T x)
    {
        root = Insert(root, x);
    }

    /// <summary>
    ///     Finds the minimum element in the binary search tree.
    /// </summary>
    /// <returns>The minimum element.</returns>
    public T FindMin()
    {
        if (IsEmpty()) throw new BinarySearchTreeEmptyException();
        var (subject, parent) = FindMin(root, null);
        return subject.GetData();
    }

    /// <summary>
    ///     Removes the minimum element from the binary search tree.
    /// </summary>
    public void RemoveMin()
    {
        if (IsEmpty()) throw new BinarySearchTreeEmptyException();

        // If root has no left child, root is the minimum
        if (!root.HasLeft())
        {
            // If root has a right child, it becomes the new root
            if (root.HasRight()) root = root.GetRight();
            // Tree will be empty
            else MakeEmpty();
        }
        else
        {
            RemoveMin(root.GetLeft(), root);
        }
    }

    /// <summary>
    ///     Removes an element from the binary search tree.
    /// </summary>
    /// <param name="x">The element to remove.</param>
    public void Remove(T x)
    {
        if (IsEmpty()) throw new BinarySearchTreeElementNotFoundException();
        root = Remove(x, root);
    }

    /// <summary>
    ///     Returns a string representing the elements of the tree in in-order.
    /// </summary>
    /// <returns>The elements of the tree in in-order.</returns>
    public string InOrder()
    {
        var sb = InOrder(root, null);
        return sb.ToString().Trim();
    }

    private BinaryNode<T> Insert(BinaryNode<T> node, T x)
    {
        if (node == null) return new BinaryNode<T>(x, null, null);

        var comparisonResult = x.CompareTo(node.GetData());

        if (comparisonResult < 0)
            node.left = Insert(node.left, x);
        else if (comparisonResult > 0)
            node.right = Insert(node.right, x);
        else
            throw new BinarySearchTreeDoubleKeyException();

        return node;
    }

    private (BinaryNode<T> subject, BinaryNode<T> parent) FindMin(BinaryNode<T> node, BinaryNode<T> parent)
    {
        return node.HasLeft() ? FindMin(node.left, node) : (node, parent);
    }

    private BinaryNode<T> RemoveMin(BinaryNode<T> node, BinaryNode<T> parent)
    {
        var current = node;

        // Dig down to find the most left leaf node and its parent
        while (current.HasLeft())
        {
            parent = current;
            current = current.GetLeft();
        }

        // If the current node has a right child, link it to the parent
        if (current.HasRight())
        {
            if (parent.GetLeft() == current) parent.left = current.GetRight();
            else if (parent.GetRight() == current) parent.right = current.GetRight();
        }

        // The leaf node is removed
        else
        {
            if (parent.GetLeft() == current) parent.left = null;
            else if (parent.GetRight() == current) parent.right = null;
        }

        return current; // Return the removed node
    }

    private BinaryNode<T> Remove(T x, BinaryNode<T> node)
    {
        if (node == null) return null;

        var (subject, parent) = Find(x, node);
        if (subject == null) throw new BinarySearchTreeElementNotFoundException();

        var countChildren = subject.CountChildren();

        if (countChildren == 0)
            RemoveNodeWithNoChildren(subject, parent);
        else if (countChildren == 1)
            RemoveNodeWithOneChild(subject, parent);
        else if (countChildren == 2) RemoveNodeWithTwoChildren(subject);

        return node;
    }

    private void RemoveNodeWithNoChildren(BinaryNode<T> node, BinaryNode<T> parent)
    {
        // Handle removal of a node with no children
        if (parent.HasLeft() && node == parent.GetLeft()) parent.left = null;
        else if (parent.HasRight() && node == parent.GetRight()) parent.right = null;
    }

    private void RemoveNodeWithOneChild(BinaryNode<T> node, BinaryNode<T> parent)
    {
        // Handle removal of a node with one child
        var child = node.HasLeft() ? node.GetLeft() : node.GetRight();
        if (node == parent.GetLeft()) parent.left = child;
        else if (node == parent.GetRight()) parent.right = child;
    }

    private void RemoveNodeWithTwoChildren(BinaryNode<T> node)
    {
        // Handle removal of a node with two children
        var removedNode = RemoveMin(node.GetRight(), node);
        node.data = removedNode.GetData();
    }

    private (BinaryNode<T> subject, BinaryNode<T> parent) Find(T x, BinaryNode<T> node)
    {
        var current = node;
        var parent = current;

        while (x.CompareTo(current.GetData()) != 0)
        {
            parent = current;

            if (!current.HasChildren()) throw new BinarySearchTreeElementNotFoundException();

            if (current.HasLeft() && x.CompareTo(current.GetData()) < 0)
                current = current.GetLeft();
            else if (current.HasRight() && x.CompareTo(current.GetData()) > 0)
                current = current.GetRight();
            else
                throw new BinarySearchTreeElementNotFoundException();
        }

        return (current, parent);
    }

    /// <summary>
    ///     Returns a string representing the elements of the tree in in-order.
    /// </summary>
    /// <returns>The elements of the tree in in-order.</returns>
    public override string ToString()
    {
        return InOrder();
    }

    private StringBuilder InOrder(BinaryNode<T> node, StringBuilder sb)
    {
        if (sb == null) sb = new StringBuilder();
        if (node == null) return sb;

        if (node.HasLeft()) InOrder(node.GetLeft(), sb);
        sb.Append(' ').Append(node.GetData());
        if (node.HasRight()) InOrder(node.GetRight(), sb);

        return sb;
    }
}