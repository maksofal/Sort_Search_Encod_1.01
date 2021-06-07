using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab06_TP.lab09
{
    class LZ77
    {
        public List<Pair> output_list;
        public LZ77()
        {
            output_list = new List<Pair>();
        }

        public List<Pair> Compress(char[] data)
        {
            string s = null;
            List<string> s_go = new List<string>();
            int window_length = 255;           
            int array_lenght = data.Length;
            int look_ahead = 0;
            int c = 0;
            for (int i = 0; i < array_lenght; i++)
            {
                c = 0;
                if (i != 0)
                {
                    look_ahead = window_length;
                    if (i - look_ahead < 0)
                        look_ahead = i;
                    List<Matcher> match_list = new List<Matcher>(); //каждый раз создается новый
                    int lctr = 0;
                    for (int j = i - 1; j > i - look_ahead - 1; j--) //поиск одинаковых вхождений в строке 255
                    {
                        if (data[j] == data[i])
                            match_list.Add(new Matcher(lctr));
                        lctr++;
                    }
                    if (match_list.Count != 0)
                    {
                        foreach (Matcher item in match_list) // сопоставление словаря с исходной строкой 
                        {
                            int ctr = 0;
                            for (int n = i - item.start_index; n < i; n++) //проверка каждого стартового индекса в словаре с иходной строкой 
                            {
                                ctr++;
                                if (i + ctr < data.Length)
                                {
                                    if (data[n] == data[i + ctr]) //сравнение --> индекс [текущий индекс -(минус) из словаря совпадений] - позиция схожего символа  == текущая позиция в исходной строке + 1,2,3....
                                    {
                                        item.lenght++; c = item.lenght; // нужны как минимум слова с длиной 6 
                                       
                                    }
                                    else
                                        break;
                                }
                            }
                        }
                                                    
                            Matcher result = new Matcher();
                            int counter = 0;
                            foreach (Matcher item in match_list) //нахождение слова с большей длиной   
                            {
                                if (counter == 0)
                                    result = item; // первый элемент из результирующего листа
                                else
                                {
                                    if (item.lenght > result.lenght) // который сравнивается с длиной 
                                        result = item;
                                }
                                counter++;
                            }
                        if (c > 5)
                        {
                            if (i + result.lenght >= data.Length)
                            {                                
                                byte result_lenght = (byte)result.lenght;
                                byte result_start_index = (byte)result.start_index;
                                Add_pair(result_lenght, result_start_index, '.');

                                s_go.Add($"<{result_lenght} { result_start_index} ."); 
                            }
                            else
                            {
                                byte result_lenght = (byte)result.lenght;
                                byte result_start_index = (byte)result.start_index;
                                Add_pair(result_lenght, result_start_index, data[i + result.lenght]);
                                s_go.Add($"<{result_lenght} { result_start_index} {data[i + result.lenght]}>");
                            }
                            i = i + result.lenght;
                        }
                        else
                        {
                            Add_pair(0, 0, data[i]);

                            s_go.Add($"{data[i]}");

                        }
                    }
                    else
                    {
                        Add_pair(0, 0, data[i]);
                        s_go.Add($"{data[i]}");
                    }
                }
                else
                {
                    Add_pair(0, 0, data[i]);
                    s_go.Add($"{data[i]}");
                }
            }
           
            Start start = new Start();
            start.File_fin_lz(s_go, "LZ77_coding");

            return output_list;

        }

        public void Decompress()
        {
            byte[] b  = new byte[1];
            output_list = new List<Pair>();
            List<byte> vs = new List<byte>();
            string ind = null;
            string  len = null;
            char c = '\0';
            
                using (StreamReader fs = new StreamReader($"LZ77_coding.lz77", Encoding.GetEncoding(1251)))
                {                   
                    char[] s  = fs.ReadToEnd().ToArray();
                      
                    for(int i = 0; i < s.Length; i++)
                    {
                        if (s[i] == '<')
                        {
                            i++;
                            while (s[i] != ' ')
                            {
                                ind += s[i];
                                i++;
                            }

                            i++;

                            while (s[i] != ' ')
                            {
                                len += s[i];
                                i++;
                            }

                            i++;

                            while (s[i] != '>')
                            {
                                c = s[i];
                                i++;
                            }

                            Add_pair(Convert.ToByte(ind), Convert.ToByte(len), c);
                            ind = null;
                            len = null;
                            c = '\0';

                        }
                        else
                        {
                            Add_pair(0, 0, s[i]);
                        }
                    }
                   
                }
            

            List<Char> decoded = new List<char>();
            int counter = 0;
            foreach (Pair item in output_list)
            {
                if (item.lenght == 0)
                {
                    decoded.Add(item.letter);
                    counter++;
                }
                else
                {
                    int counter_temp = counter;
                    for (int i = counter_temp - item.start_index - 1; i < counter_temp - item.start_index + item.lenght - 1; i++)
                    {
                        decoded.Add(decoded[i]);
                        counter++;
                    }
                    decoded.Add(item.letter);
                    counter++;
                }
            }

            Start start = new Start();
            start.File_fin(decoded, "LZ77_coding_decoding");

           // return new string(decoded.ToArray());
        }

        private void Add_pair(byte lenght, byte start_index, char letter)
        {

            output_list.Add(new Pair(lenght, start_index, letter));
        }
    }

    class Pair //пары
    {
        public short lenght;
        public short start_index;
        public char letter;

        public Pair(byte lenght, byte start_index, char letter)
        {
            this.lenght = lenght;
            this.start_index = start_index;
            this.letter = letter;
        }
    }

    class Matcher // сопоставление
    {
        public int lenght;
        public int start_index;
        public Matcher()
        {
            this.lenght = 1;
        }
        public Matcher(int start_index)
        {
            this.start_index = start_index;
            this.lenght = 1;
        }
    }
}
