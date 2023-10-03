namespace AD
{
    //
    // This class offers static methods to create datastructures.
    // It is called by unit tests.
    //
    public partial class DSBuilder
    {
        public static IBinaryTree<int> CreateBinaryTreeEmpty()
        {
            BinaryTree<int> tree = new BinaryTree<int>();
            return tree;
        }

        //
        //         5
        //       /   \
        //     2       6
        //    / \
        //   8   7
        //      /
        //     1
        //
        public static IBinaryTree<int> CreateBinaryTreeInt()
        {
            // Create the nodes
            BinaryNode<int> five = new BinaryNode<int>(5, null, null);
            BinaryNode<int> two = new BinaryNode<int>(2, null, null);
            BinaryNode<int> six = new BinaryNode<int>(6, null, null);
            BinaryNode<int> eight = new BinaryNode<int>(8, null, null);
            BinaryNode<int> seven = new BinaryNode<int>(7, null, null);
            BinaryNode<int> one = new BinaryNode<int>(1, null, null);

            // Connect the nodes to build the tree
            five.left = two;
            five.right = six;
            two.left = eight;
            two.right = seven;
            seven.left = one;

            // Create a BinaryTree and set its root
            BinaryTree<int> tree = new BinaryTree<int>();
            tree.root = five;

            return tree;
        }

        //
        //         t
        //       /   \
        //     w       a
        //    / \     / \
        //   q   g   o   p
        public static IBinaryTree<string> CreateBinaryTreeString()
        {
            BinaryTree<string> tq = new BinaryTree<string>("q");
            BinaryTree<string> tg = new BinaryTree<string>("g");
            BinaryTree<string> to = new BinaryTree<string>("o");
            BinaryTree<string> tp = new BinaryTree<string>("p");
            BinaryTree<string> tw = new BinaryTree<string>();
            BinaryTree<string> tt = new BinaryTree<string>();
            BinaryTree<string> ta = new BinaryTree<string>();

            tw.Merge("w", tq, tg);
            ta.Merge("a", to, tp);
            tt.Merge("t", tw, ta);

            return tt;
        }
    }
}