using System;
using System.Collections.Generic;
using System.Linq;


namespace AD
{
    public partial class QuickSort : Sorter
    {
        private static int CUTOFF = 3;

        public override void Sort(List<int> list)
        {
            if (list.Count < 2) return;
            Partition(list, 0, list.Count-1);
            
        }

        private void Partition(List<int> list, int begin, int end)
        {
            if (begin >= end) return;
            if (end - begin <= CUTOFF)
            {
                new InsertionSort().Sort(list, begin, end);
                return;
            }
            
            // get the pivot
            int pivotIndex = GeneratePivotIndex(list, begin, end);
            int pivotValue = list[pivotIndex];
            
            // swap pivot with last item
            list[pivotIndex] = list[end];
            list[end] = pivotValue;

            int leftPointer = begin;
            int rightPointer = end-1;

            while (leftPointer <= rightPointer)
            {
                if (list[leftPointer] < pivotValue) leftPointer++;
                else if (list[rightPointer] > pivotValue) rightPointer--;
                else 
                {
                    // swap values
                    (list[leftPointer], list[rightPointer]) = (list[rightPointer], list[leftPointer]);
                    leftPointer++;
                    rightPointer--;
                }
                
            }
 
            list[end] = list[leftPointer];
            list[leftPointer] = pivotValue;
            
            Partition(list, begin, leftPointer-1);
            Partition(list, leftPointer+1, end);
        }

        private int GeneratePivotIndex(List<int> list ,int begin, int end)
        {
            return GenerateRandomPivotIndex(list, begin, end);
        }
        private int GenerateRandomPivotIndex(List<int> list ,int begin, int end)
        {
            // Generate a random index within the range [begin, end]
            Random rand = new Random();
            return rand.Next(begin, end + 1);
        }

        private int GenerateMedianOfThreePivotIndex(List<int> list, int begin, int end)
        {
            int pivotIndex;

            int firstIndex = begin;
            int middleIndex = (end-begin) / 2 + begin;
            int lastIndex = end - 1;

            int first = list[firstIndex];
            int middle = list[middleIndex];
            int last = list[lastIndex];

            if (first > middle)
            {
                if (first < last)
                    pivotIndex = firstIndex;
                else
                    pivotIndex = (middle > last) ? middleIndex : lastIndex;
            }
            else
            {
                if (first > last)
                    pivotIndex = firstIndex;
                else
                    pivotIndex = (middle < last) ? middleIndex : lastIndex;
            }

            return pivotIndex;
        }
    }
}
