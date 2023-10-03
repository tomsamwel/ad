using System.Collections.Generic;


namespace AD
{
    public partial class InsertionSort : Sorter
    {
        public override void Sort(List<int> list)
        {
            Sort(list, 0, list.Count - 1);
        }

        public void Sort(List<int> list, int lo, int hi)
        {
            // Validate parameters
            if (list.Count < 2 || lo < 0 || hi >= list.Count || lo > hi) return;

            for (int i = lo + 1; i <= hi; i++)
            {
                int current = list[i];
                
                for (int j = i - 1; j >= lo; j--)
                {
                    int compare = list[j];

                    if (current < compare)
                    {
                        list[j + 1] = compare;
                        list[j] = current;
                    }
                    else break;
                }
                
            }
        }
    }
}
