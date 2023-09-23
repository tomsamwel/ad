namespace AD
{
    public partial class MyLinkedListNode<T>
    {
        public T data;
        public MyLinkedListNode<T> next;
        
        public MyLinkedListNode(T data)
        {
            this.data = data;
            this.next = null;
        }
        
        public MyLinkedListNode(T data, MyLinkedListNode<T> next)
        {
            this.data = data;
            this.next = next;
        }
    }
    

}
