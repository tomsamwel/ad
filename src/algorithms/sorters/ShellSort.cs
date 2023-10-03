using System.Collections.Generic;


namespace AD
{
    public partial class ShellSort : Sorter
    {
        public override void Sort(List<int> list)
        {
            int n = list.Count;
            int gap = n / 2;
            RecursiveShellSort(list, n, gap);
        }

        private void RecursiveShellSort(List<int> list, int n, int gap)
        {
            if (gap <= 0)
            {
                return;
            }

            // Perform the sorting for this gap
            for (int i = gap; i < n; i++)
            {
                int temp = list[i];
                int j;
                for (j = i; j >= gap && list[j - gap] > temp; j -= gap)
                {
                    list[j] = list[j - gap];
                }
                list[j] = temp;
            }

            // Recursively reduce the gap and sort
            RecursiveShellSort(list, n, gap / 2);
        }
    }
}
