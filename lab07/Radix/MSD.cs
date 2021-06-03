using lab06_TP;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab6_TP.lab07.Radix
{
    public class MSD 
    {
        public int length = 0;
        public void Msd_sort(List<string> list)
        {
            length = GetMaxLeng(list);

            for (int i = 0; i < list.Count; i++)
            {
                for (int j = 0; j < length; j++)
                {
                    if (list[i].Length != length)
                    {
                        list[i] = list[i].Insert(0, "0");
                    }
                }
            }


            var result = Sort(list, length-1);

            Start start = new Start();
            start.File_fin_bin_radix(result, "MSD");
        }

        public List<string> Sort(List<string> list, int step )
        {
            var result = new List<string>();
            var group = new List<List<string>>();

            for (int i = 0; i < list.Count; i++)
            {
                group.Add(new List<string>());
            }            
                foreach (string item in list)
                {              
                    var s = int.Parse(item[(length-1) - step].ToString());
                    if(s == 0)
                    {
                        group[0].Add(item);
                    }
                    else
                    {
                        group[1].Add(item);
                    }
                }

                foreach (var g in group)
                {                    
                    if (g.Count > 1 && step > 0)
                    {
                      result.AddRange(Sort(g, step - 1));
                         continue;
                    }

                  result.AddRange(g);                    
                }
            return result;
        }

        public int GetMaxLeng(List<string> list)
        {
            var length = 0;
            
            foreach (var item in list)
            {
                var l = 0;
                if (item != null )
                {
                    l = item.Length;
                }

                if (l > length)
                {
                    length = l;
                }

            }

            return length;
        }

    }

  
    
}
