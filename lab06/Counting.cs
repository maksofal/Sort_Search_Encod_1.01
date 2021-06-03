using lab06_TP;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab6_TP
{
    public class Counting
    {
        public void Count_s(List<int> counting)
        {          
            List<int> vs = new List<int>();

            for(int i =0; i < counting.Count; i++)
            {
                vs.Add(0);
            }
            
            int k = 0;
            for (int i = 0; i < counting.Count; i++)
            {
                k = 0;
                for (int j = 0; j < counting[i]; j++)
                {    
                    k++;
                    vs[counting[i]] = k;

                }
                
            }
            counting.Clear();

            for(int i=0; i < vs.Count; i++)
            {
                for(int j =0; j < vs[i]; j++)
                {
                    counting.Add(vs[i]);
                }
            }

            string file_name = "Counting";
            Start start = new Start();
            start.File_fin_bin(counting, file_name);
        }

    }
}
