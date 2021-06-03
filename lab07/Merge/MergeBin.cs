using lab06_TP;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab6_TP.lab07
{
    class MergeBin
    {
        public void GO(List<int> merge)
        {
            var sort = MergeSort(merge);

            for (int i = 0; i < sort.Count; i++)
            {
                merge[i] = sort[i];
            }

            string file_name = "Merge";
            Start start = new Start();
            start.File_fin_bin(merge, file_name);
        }

        private List<int> MergeSort(List<int> merge)
        {
            if (merge.Count <= 1)
            {
                return merge;
            }

            var left = new List<int>();
            var right = new List<int>();

            for (int i = 0; i < merge.Count; i++)
            {
                if (i % 2 > 0)
                {
                    left.Add(merge[i]);
                }
                else
                {
                    right.Add(merge[i]);
                }
            }

            left = MergeSort(left);
            right = MergeSort(right);

            return MergeS(left, right);
        }

        private List<int> MergeS(List<int> left, List<int> right)
        {
            var result = new List<int>();

            while (left.Count > 0 && right.Count > 0)
            {
                if (left.First() <= right.First())
                {
                    Move(left, result);
                }
                else
                {
                    Move(right, result);
                }
            }

            while (left.Count > 0)
            {
                Move(left, result);
            }
            while (right.Count > 0)
            {
                Move(right, result);
            }

            return result;

        }

        private void Move(List<int> list, List<int> result)
        {
            result.Add(list.First());
            list.RemoveAt(0);
        }
    }
}

