namespace AD
{
    public partial class MyLinkedList<T> : IMyLinkedList<T>
    {
        public MyLinkedListNode<T>? first;
        public MyLinkedListNode<T>? last;
        private int size;

        public MyLinkedList()
        {
            // Write implementation here
            size = 0;
            first = null;
            last = null;
        }

        public void AddFirst(T data)
        {
            MyLinkedListNode<T>? newFirst = new MyLinkedListNode<T>(data);
            if (first != null)
            {
                newFirst.next = first;
            }
            else
            {
                last = newFirst; // If the list was empty, then the new node is also the last node.
            }

            first = newFirst;
            size++;
        }

        public void AddLast(T data)
        {
            MyLinkedListNode<T>? newLast = new MyLinkedListNode<T>(data);

            if (last != null)
            {
                last.next = newLast;
            }
            else
            {
                first = newLast; // If the list was empty, then the new node is also the first node.
            }

            last = newLast; // Update last to point to the new node
            size++;
        }

        public T GetFirst()
        {
            if (first == null) throw new MyLinkedListEmptyException();
            return first.data;
        }

        public void RemoveFirst()
        {
            if (first == null) throw new MyLinkedListEmptyException();
            first = first.next;
            size--;
            UpdateLast();
        }

        public int Size()
        {
            return size;
        }

        public void Clear()
        {
            first = null;
            size = 0;
        }

        public void Insert(int index, T data)
        {
            if (index < 0 || index > size) throw new MyLinkedListIndexOutOfRangeException();
            MyLinkedListNode<T>? newNode = new MyLinkedListNode<T>(data);
            if (index == 0)
            {
                newNode.next = first;
                first = newNode;
            }
            else if (index == size)
            {
                last.next = newNode;
                last = newNode;
            }
            else
            {
                MyLinkedListNode<T>? current = first;
                for (int i = 0; i < index - 1; i++)
                {
                    current = current.next;
                }

                newNode.next = current.next;
                current.next = newNode;
            }

            size++;
        }

        private void UpdateLast()
        {
            if (first == null)
            {
                last = null;
            }
            else
            {
                MyLinkedListNode<T>? current = first;
                while (current.next != null)
                {
                    current = current.next;
                }

                last = current;
            }
        }

        public override string ToString()
        {
            if (size == 0) return "NIL";

            string s = "[";
            MyLinkedListNode<T>? current = first;
            while (current.next != null)
            {
                s += current.data + ",";
                current = current.next;
            }

            s += current.data + "]";
            return s;
        }
    }
}