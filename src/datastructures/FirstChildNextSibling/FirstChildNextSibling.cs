using System;

namespace AD
{
    public partial class FirstChildNextSibling<T> : IFirstChildNextSibling<T>
    {
        public FirstChildNextSiblingNode<T> root;

        public IFirstChildNextSiblingNode<T> GetRoot()
        {
            return root;
        }

        public int Size()
        {
            int size = 0;
            if (root == null) return size;
            if (root.GetFirstChild() == null) return 1;

            size = CountSize(root);

            return size;
        }

        // private int CountSize(FirstChildNextSiblingNode<T> node)
        // {
        //     int count = 1;
        //     
        //     if (node.GetFirstChild() != null)
        //     {
        //         count += CountSize(node.GetFirstChild());
        //     }
        //     if (node.GetNextSibling() != null)
        //     {
        //         count += CountSize(node.GetNextSibling());
        //     }
        //
        //     return count;
        // }
        
        private int CountSize(FirstChildNextSiblingNode<T>? node)
        {
            if (node == null) return 0;

            return 1 + CountSize(node.GetFirstChild()) + CountSize(node.GetNextSibling()) ;
        }

        public void PrintPreOrder()
        {
            PrintPreOrder(root);
        }

        private static void PrintPreOrder(FirstChildNextSiblingNode<T>? node, int depth = 0)
        {
            if (node == null) return;
            
            // Print tabs for the current depth
            for (int i = 0; i < depth; i++)
            {
                Console.Out.Write("\t");
            }
            Console.Out.WriteLine(node.GetData());

            
            if (node.HasFirstChild()) PrintPreOrder(node.GetFirstChild(), depth + 1);
            if (node.HasNextSibling()) PrintPreOrder(node.GetNextSibling(), depth);
        }

        public override string ToString()
        {
            return root == null ? "NIL" : ToString(root);
        }

        private static string ToString(FirstChildNextSiblingNode<T>? node)
        {
            if (node == null) return "";
            string s = node.GetData().ToString();

            s += node.HasFirstChild() ? ",FC(" + ToString(node.GetFirstChild()) + ")" : "";
            s += node.HasNextSibling() ? ",NS(" + ToString(node.GetNextSibling()) + ")" : "";
            
            return s;
        }
    }
}