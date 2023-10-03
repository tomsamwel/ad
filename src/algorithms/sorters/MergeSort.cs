using System.Collections.Generic;


namespace AD
{
    public partial class MergeSort : Sorter
    {
        public override void Sort(List<int> list)
        {
            if (list.Count < 2) return;

            SplitList(list, out List<int> left, out List<int> right);
            
            Sort(left);
            Sort(right);
            
            MergeLists(list, left, right);
        }
        
        private void SplitList(List<int> list, out List<int> left, out List<int> right, int splitIndex = 0)
        {
            // if no split index is given, the middle is used
            if(splitIndex == 0) splitIndex = list.Count / 2;

            left = list.GetRange(0, splitIndex);
            right = list.GetRange(splitIndex, list.Count - splitIndex);
        }

        private void MergeLists(List<int> mergedList, List<int> leftList, List<int> rightList)
        {
            int leftIndex = 0;
            int rightIndex = 0;

            // Loop through the mergedList
            for (int i = 0; i < mergedList.Count; i++)
            {
                // Check if we've exhausted all elements in the leftList
                if (leftIndex >= leftList.Count)
                {
                    mergedList[i] = rightList[rightIndex];
                    rightIndex++;
                }
                // Check if we've exhausted all elements in the rightList
                else if (rightIndex >= rightList.Count)
                {
                    mergedList[i] = leftList[leftIndex];
                    leftIndex++;
                }
                // Compare elements from both lists and merge them in sorted order
                else if (leftList[leftIndex] <= rightList[rightIndex])
                {
                    mergedList[i] = leftList[leftIndex];
                    leftIndex++;
                }
                else
                {
                    mergedList[i] = rightList[rightIndex];
                    rightIndex++;
                }
            }
        }

    }
}
