using lab06_TP;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab6_TP
{
    class Bubble
    {
        public void Swop(List<string> Bubblee)
        {
            
            var count = Bubblee.Count;
            for (int j = 0; j < count; j++)
            {
                for (int i = 0; i < count - j - 1; i++)
                {
                    if (Bubblee[i].Length < count && Bubblee[i + 1].Length < count)
                    {
                        if (Bubblee[i].Length > Bubblee[i+1].Length)
                        {
                            var temp = Bubblee[i];
                            Bubblee[i] = Bubblee[i + 1];
                            Bubblee[i + 1] = temp;
                        }
                        
                    }
                }
            }
            string file_name = "Bubble";
            Start start = new Start();
            start.File_fin(Bubblee, file_name);
           
        }

        public void Swop_bin(List<int> Bubble)
        {
            int count = Bubble.Count;
            for (int j = 0; j < count; j++)
            {
                for (int i = 0; i < count - j - 1; i++)
                {
                    if (i < count && i + 1 < count)
                    {
                        if (Bubble[i]> Bubble[i + 1])
                        {
                            int temp = Bubble[i];
                            int temp1 = Bubble[i + 1];
                            Bubble[i] = temp1;
                            Bubble[i + 1] = temp;
                        }

                    }
                }
            }
            string file_name = "Bubble";

            Start start = new Start();
            start.File_fin_bin(Bubble, file_name);

        }


        public static void s(ref string a, ref string b)
        {
            string tmp = a;
            a = b;
            b = tmp;
        }


    }
}
