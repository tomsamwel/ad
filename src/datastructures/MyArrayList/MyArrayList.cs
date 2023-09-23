using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace AD
{
    public partial class MyArrayList : IMyArrayList
    {
        private int[] data;
        private int size;

        public override string ToString()
        {
            if (size == 0)
            {
                return "NIL";
            }

            // return the string representation of the array
            string s = "[";
            for (int i = 0; i < size; i++)
            {
                s += data[i];
                if (i < size - 1)
                {
                    s+= ",";
                }
            }
            s += "]";
            return s;
        }
        public MyArrayList(int capacity) 
        {
            // Write implementation here
            if (capacity < 0)
                throw new System.ArgumentException("Capacity must be at least 1");
            
            data = new int[capacity];
            size = 0;
        }

        public void Add(int n)
        {
            // Write implementation here
            // if data is full, throw exception
            if (size == data.Length)
                throw new MyArrayListFullException();
            
            data[size] = n;
            size++;
        }

        public int Get(int index)
        {
            if (index < 0 || index >= size)
            {
                throw new MyArrayListIndexOutOfRangeException();
            }
            return data[index];
        }

        public void Set(int index, int n)
        {
            // Write implementation here
            if (index < 0 || index >= size)
            {
                throw new MyArrayListIndexOutOfRangeException();
            }
            
            data[index] = n;
        }

        public int Capacity()
        {
            return data.Length;
        }

        public int Size()
        {
            // Write implementation here
            return size;
        }

        public void Clear()
        {
            // Write implementation here
            // empty the data array
            data = new int[data.Length];
            size = 0;
        }

        public int CountOccurences(int n)
        {
            // Write implementation here
            bool Predicate(int x) => x == n;
            return data.Count(Predicate);
        }
    }
}
