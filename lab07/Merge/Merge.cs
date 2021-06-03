using lab06_TP;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab6_TP.lab07
{
    public class Merge
    {
        public void GO(List<string> merge)
        {
            var sort = MergeSort(merge);

            for (int i = 0; i < sort.Count; i++)
            {
                merge[i] = sort[i];
            }

            string file_name = "Merge";
            Start start = new Start();
            start.File_fin(merge, file_name);
        }

        private List<string> MergeSort(List<string> merge)
        {
            if(merge.Count <=1)
            {
                return merge;
            }

            var left = new List<string>();
            var right = new List<string>();

            for(int i = 0; i < merge.Count; i++)
            {
                if(i%2>0)
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

        private List<string> MergeS(List<string> left, List<string> right)
        {
            var result = new List<string>();

            while(left.Count > 0 && right.Count > 0)
            {
                if(left.First().CompareTo(right.First()) < 0 )
                {
                    Move(left, result);
                }
                else
                {
                    Move(right, result);
                }
            }

            while(left.Count > 0)
            {
                Move(left, result);
            }
            while (right.Count > 0)
            {
                Move(right, result);
            }

            return result;

        }

        private void Move(List<string> list, List<string> result)
        {
            result.Add(list.First());
            list.RemoveAt(0);
        }
    }
}
