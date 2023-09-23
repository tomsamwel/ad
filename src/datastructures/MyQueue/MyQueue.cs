using System.Collections.Generic;

namespace AD
{
    public partial class MyQueue<T> : IMyQueue<T>
    {
        private readonly MyLinkedList<T> _list = new MyLinkedList<T>();
        public bool IsEmpty()
        {
            return _list.Size() == 0;
        }

        public void Enqueue(T data)
        {
            _list.AddLast(data);
        }

        public T GetFront()
        {
            if (IsEmpty()) throw new MyQueueEmptyException();
            return _list.GetFirst();
        }

        public T Dequeue()
        {
            if (IsEmpty()) throw new MyQueueEmptyException();
            var node = GetFront();
            _list.RemoveFirst();
            return node;
        }

        public void Clear()
        {
            _list.Clear();
        }

    }
}