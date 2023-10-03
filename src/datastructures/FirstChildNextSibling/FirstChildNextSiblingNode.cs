namespace AD
{
    public partial class FirstChildNextSiblingNode<T> : IFirstChildNextSiblingNode<T>
    {
        public FirstChildNextSiblingNode<T>? firstChild;
        public FirstChildNextSiblingNode<T>? nextSibling;
        public T data;

        public FirstChildNextSiblingNode(T data, FirstChildNextSiblingNode<T> firstChild, FirstChildNextSiblingNode<T> nextSibling)
        {
            this.data = data;
            this.firstChild = firstChild;
            this.nextSibling = nextSibling;
        }

        public FirstChildNextSiblingNode(T data)
        {
            this.data = data;
        }

        public T GetData()
        {
            return data;
        }

        public FirstChildNextSiblingNode<T> GetFirstChild()
        {
            if (firstChild == null) return null;
            return firstChild;
        }

        public FirstChildNextSiblingNode<T> GetNextSibling()
        {
            if (nextSibling == null) return null;
            return nextSibling;
        }

        public bool HasFirstChild()
        {
            return firstChild != null;
        }
        
        public bool HasNextSibling()
        {
            return nextSibling != null;
        }
    }
}