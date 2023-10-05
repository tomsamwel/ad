using System;
using System.Text;

namespace AD;

/// <summary>
///     Represents a binary tree data structure.
/// </summary>
/// <typeparam name="T">The type of data stored in the tree.</typeparam>
public class BinaryTree<T> : IBinaryTree<T>
{
    /// <summary>
    ///     The root node of the binary tree.
    /// </summary>
    public BinaryNode<T> root;

    //----------------------------------------------------------------------
    // Constructors
    //----------------------------------------------------------------------

    /// <summary>
    ///     Initializes an empty binary tree.
    /// </summary>
    public BinaryTree()
    {
        root = null;
    }

    /// <summary>
    ///     Initializes a binary tree with a specified root item.
    /// </summary>
    /// <param name="rootItem">The data for the root node.</param>
    public BinaryTree(T rootItem)
    {
        root = new BinaryNode<T>(rootItem, null, null);
    }

    //----------------------------------------------------------------------
    // Interface methods that have to be implemented for the exam
    //----------------------------------------------------------------------

    /// <summary>
    ///     Gets the root node of the binary tree.
    /// </summary>
    /// <returns>The root node.</returns>
    public BinaryNode<T> GetRoot()
    {
        return root;
    }

    /// <summary>
    ///     Computes the size (number of nodes) of the binary tree.
    /// </summary>
    /// <returns>The size of the binary tree.</returns>
    public int Size()
    {
        return Size(root);
    }

    /// <summary>
    ///     Computes the height of the binary tree.
    /// </summary>
    /// <returns>The height of the binary tree.</returns>
    public int Height()
    {
        if (IsEmpty()) return -1;
        return Height(root);
    }

    /// <summary>
    ///     Makes the binary tree empty by setting the root to null.
    /// </summary>
    public void MakeEmpty()
    {
        root = null;
    }

    /// <summary>
    ///     Checks if the binary tree is empty.
    /// </summary>
    /// <returns>True if the tree is empty, otherwise false.</returns>
    public bool IsEmpty()
    {
        return root == null;
    }

    /// <summary>
    ///     Merges two binary trees by creating a new root with the specified data and attaching the given trees as children.
    /// </summary>
    /// <param name="rootItem">The data for the new root.</param>
    /// <param name="t1">The left subtree to attach.</param>
    /// <param name="t2">The right subtree to attach.</param>
    public void Merge(T rootItem, BinaryTree<T> t1, BinaryTree<T> t2)
    {
        if (t1 == t2) throw new Exception();
        root = new BinaryNode<T>(rootItem, t1.root, t2.root);
    }

    /// <summary>
    ///     Converts the binary tree to a string representation using prefix notation.
    /// </summary>
    /// <returns>The string representation of the tree in prefix notation.</returns>
    public string ToPrefixString()
    {
        return ToPrefixString(root);
    }

    /// <summary>
    ///     Converts the binary tree to a string representation using infix notation.
    /// </summary>
    /// <returns>The string representation of the tree in infix notation.</returns>
    public string ToInfixString()
    {
        return ToInfixString(root);
    }

    /// <summary>
    ///     Converts the binary tree to a string representation using postfix notation.
    /// </summary>
    /// <returns>The string representation of the tree in postfix notation.</returns>
    public string ToPostfixString()
    {
        return ToPostfixString(root);
    }

    //----------------------------------------------------------------------
    // Interface methods: methods that have to be implemented for homework
    //----------------------------------------------------------------------

    /// <summary>
    ///     Counts the number of leaf nodes in the binary tree.
    /// </summary>
    /// <returns>The number of leaf nodes.</returns>
    public int NumberOfLeaves()
    {
        if (IsEmpty()) return 0;
        return NumberOfLeaves(root);
    }

    /// <summary>
    ///     Counts the number of nodes in the binary tree with exactly one child.
    /// </summary>
    /// <returns>The number of nodes with one child.</returns>
    public int NumberOfNodesWithOneChild()
    {
        return NumberOfNodesWithOneChild(root);
    }

    /// <summary>
    ///     Counts the number of nodes in the binary tree with exactly two children.
    /// </summary>
    /// <returns>The number of nodes with two children.</returns>
    public int NumberOfNodesWithTwoChildren()
    {
        return NumberOfNodesWithTwoChildren(root);
    }

    /// <summary>
    ///     Computes the size (number of nodes) of a binary tree rooted at the given node.
    /// </summary>
    /// <param name="node">The root of the subtree.</param>
    /// <returns>The size of the subtree.</returns>
    public static int Size(BinaryNode<T> node)
    {
        if (node == null) return 0;
        return 1 + Size(node.GetLeft()) + Size(node.GetRight());
    }

    /// <summary>
    ///     Computes the height of a binary tree rooted at the given node.
    /// </summary>
    /// <param name="node">The root of the subtree.</param>
    /// <returns>The height of the subtree.</returns>
    public static int Height(BinaryNode<T> node)
    {
        if (node == null) return -1;
        var heightLeft = Height(node.GetLeft());
        var heightRight = Height(node.GetRight());

        return Math.Max(heightLeft, heightRight) + 1;
    }

    /// <summary>
    ///     Converts a binary tree rooted at the given node to a string representation using prefix notation.
    /// </summary>
    /// <param name="node">The root of the subtree to convert.</param>
    /// <returns>The string representation of the subtree in prefix notation.</returns>
    public string ToPrefixString(BinaryNode<T> node)
    {
        var sb = new StringBuilder();
        if (node == null)
        {
            sb.Append("NIL");
            ;
        }
        else
        {
            sb
                .Append("[ ")
                .Append(node.GetData())
                .Append(' ')
                .Append(ToPrefixString(node.left))
                .Append(' ')
                .Append(ToPrefixString(node.right))
                .Append(" ]");
        }

        return sb.ToString();
    }

    /// <summary>
    ///     Converts a binary tree rooted at the given node to a string representation using infix notation.
    /// </summary>
    /// <param name="node">The root of the subtree to convert.</param>
    /// <returns>The string representation of the subtree in infix notation.</returns>
    public string ToInfixString(BinaryNode<T> node)
    {
        var sb = new StringBuilder();
        if (node == null)
        {
            sb.Append("NIL");
            ;
        }
        else
        {
            sb
                .Append("[ ")
                .Append(ToInfixString(node.left))
                .Append(' ')
                .Append(node.GetData())
                .Append(' ')
                .Append(ToInfixString(node.right))
                .Append(" ]");
        }

        return sb.ToString();
    }

    /// <summary>
    ///     Converts a binary tree rooted at the given node to a string representation using postfix notation.
    /// </summary>
    /// <param name="node">The root of the subtree to convert.</param>
    /// <returns>The string representation of the subtree in postfix notation.</returns>
    public string ToPostfixString(BinaryNode<T> node)
    {
        var sb = new StringBuilder();
        if (node == null)
        {
            sb.Append("NIL");
            ;
        }
        else
        {
            sb
                .Append("[ ")
                .Append(ToPostfixString(node.left))
                .Append(' ')
                .Append(ToPostfixString(node.right))
                .Append(' ')
                .Append(node.GetData())
                .Append(" ]");
        }

        return sb.ToString();
    }

    /// <summary>
    ///     Counts the number of leaf nodes in a binary tree rooted at the given node.
    /// </summary>
    /// <param name="node">The root of the subtree to count leaves in.</param>
    /// <returns>The number of leaf nodes in the subtree.</returns>
    public int NumberOfLeaves(BinaryNode<T> node)
    {
        if (node == null) return 0;
        if (!node.HasLeft() && !node.HasRight()) return 1;
        return NumberOfLeaves(node.GetLeft()) + NumberOfLeaves(node.GetRight());
    }

    /// <summary>
    ///     Counts the number of nodes in a binary tree rooted at the given node with exactly one child.
    /// </summary>
    /// <param name="node">The root of the subtree to count nodes with one child in.</param>
    /// <returns>The number of nodes with one child in the subtree.</returns>
    public int NumberOfNodesWithOneChild(BinaryNode<T> node)
    {
        if (node == null) return 0;
        var oneChild = node.HasRight() ^ node.HasLeft() ? 1 : 0;
        return NumberOfNodesWithOneChild(node.left) + NumberOfNodesWithOneChild(node.right) + oneChild;
    }

    /// <summary>
    ///     Counts the number of nodes in a binary tree rooted at the given node with exactly two children.
    /// </summary>
    /// <param name="node">The root of the subtree to count nodes with two children in.</param>
    /// <returns>The number of nodes with two children in the subtree.</returns>
    public int NumberOfNodesWithTwoChildren(BinaryNode<T> node)
    {
        if (node == null) return 0;
        var twoChildren = node.HasRight() && node.HasLeft() ? 1 : 0;
        return NumberOfNodesWithTwoChildren(node.left) + NumberOfNodesWithTwoChildren(node.right) + twoChildren;
    }
}