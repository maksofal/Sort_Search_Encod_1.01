using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab6_TP
{
    public class Quick 
    {
        public void Swap(List<string> arr, int left, int right)
        {
            string temp = arr[left];
            arr[left] = arr[right];
            arr[right] = temp;
        }

        public void Part(List<string> quick, int start, int end) 
        {
            int i = start;
            int j = end;

            var p = quick[start + (end - start) / 2];
            int pivot = p.Length;

            while (i < j )
            {
                while(quick[i].CompareTo(p) < 0)
                {
                    i++;
                }
                while (quick[j].CompareTo(p) > 0)
                {
                    j--;
                }

                if (i <= j)
                {
                    Swap(quick, i, j);
                    i++;
                    j--;
                }
            }

            if (start < j)
                Part(quick, start, j);

            if (i < end)
                Part(quick, i, end);

        }

        public void Swap(List<int> arr, int left, int right)
        {
            var temp = arr[left];
            arr[left] = arr[right];
            arr[right] = temp;
        }

        public void Part(List<int> quick, int start, int end)
        {
            int i = start;
            int j = end;

            var p = quick[start + (end - start) / 2];
            int pivot = p;

            while (i < j)
            {
                while (quick[i] < pivot)
                {
                    i++;
                }
                while (quick[j] > pivot)
                {
                    j--;
                }

                if (i <= j)
                {
                    Swap(quick, i, j);
                    i++;
                    j--;
                }
            }

            if (start < j)
                Part(quick, start, j);

            if (i < end)
                Part(quick, i, end);

        }

    }
}
