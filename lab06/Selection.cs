using lab06_TP;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab6_TP
{
    class Selection
    {
        public void Select(List<string> select)
        {
            var count = select.Count;

            for (int i = 0; i < count; i++)
            {  
                int min = i;

                for (int j = i + 1; j < count; j++)
                {
                    if (select[j].Length < select[min].Length)
                    {
                        min = j;
                    }
                }
                
                var temp = select[i];
                select[i] = select[min];
                select[min] = temp;
            }
            
            string file_name = "Select";
            Start start = new Start();
            start.File_fin(select, file_name);

        }


        public void Select_bin(List<int> select)
        {
            var count = select.Count;

            for (int i = 0; i < count; i++)
            {
                int min = i;

                for (int j = i + 1; j < count; j++)
                {
                    if (select[j] < select[min])
                    {
                        min = j;
                    }
                }

                var temp = select[i];
                select[i] = select[min];
                select[min] = temp;
            }

            string file_name = "Select";
            Start start = new Start();
            start.File_fin_bin(select, file_name);

        }



    }
}
