using lab06_TP;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab6_TP
{
    class Insertion
    {
        public void Insert(List<string> insert)
        {
            var count = insert.Count();

            for(var i=1; i < count; i++)
            {
                var key = insert[i];
                var j = i-1;

                while((j>=0) && (insert[j].Length > key.Length))
                {
                    insert[j + 1] = insert[j];  
                    j--;
                }
                insert[j+1] = key;
            }

            string file_name = "Insertion";
            Start start = new Start();
            start.File_fin(insert, file_name);
        }

        public void Insert(List<int> insert)
        {
            var count = insert.Count();

            for (var i = 1; i < count; i++)
            {
                var key = insert[i];
                var j = i - 1;

                while ((j >= 0) && (insert[j] > key))
                {
                    insert[j + 1] = insert[j];
                    j--;
                }
                insert[j + 1] = key;
            }

            string file_name = "Insertion";
            Start start = new Start();
            start.File_fin_bin(insert, file_name);


        }


    }
}
