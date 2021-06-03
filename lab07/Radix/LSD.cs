using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab6_TP.lab07.Radix
{
    public class LSD 
    {
        public void Lsd_sort(List<string> list)
        {
            var group = new List<List<string>>();

            for(int i =0; i<list.Count; i++) 
            {
                group.Add(new List<string>());
            }
            int length = GetMaxLeng(list);

            for(int i = 0; i < list.Count; i++)
            {
                for (int j = 0; j < length; j++)
                {
                    if (list[i].Length != length)
                    {
                        list[i] = list[i].Insert(0, "0");
                    }
                }
            }

            var items = list.Select(i => i);

            for (int step = 0; step < length; step++)
            {
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

                list.Clear();

                foreach(var g in group)
                {
                    foreach(var item in g)
                    {
                        list.Add(item);
                    }
                }

                foreach(var g in group)
                {
                    g.Clear();
                }

            }
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
