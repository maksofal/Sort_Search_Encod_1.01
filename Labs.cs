using lab06_TP.lab09;
using lab06_TP.lab09.Huffmen;
using lab6_TP;
using lab6_TP.lab07;
using lab6_TP.lab07.Radix;
using lab6_TP.lab09;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace lab06_TP
{
    public partial class Labs : Form
    {
        public Labs()
        {
            InitializeComponent();

        }
        Start txt = new Start();
        Start txt_bin = new Start();

        private void Bubble_sort_Click(object sender, EventArgs e)
        {
            Bubble bubble = new Bubble();

            DateTime d = DateTime.Now;
            txt.File();
            bubble.Swop(txt.Items);
            TimeSpan ime = DateTime.Now - d;
            label1.Text += ime.ToString();

            DateTime dd = DateTime.Now;
            txt_bin.File_bin();
            bubble.Swop_bin(txt_bin.Items_bin);
            TimeSpan ime2 = DateTime.Now - dd;
            label1.Text += $" Bin:{ime2.ToString()}";

            MessageBox.Show("Загрузка в файл завершена");
        }

        private void Selection_sort_Click(object sender, EventArgs e)
        {
            Selection selection = new Selection();

            DateTime d = DateTime.Now;
            txt.File();
            selection.Select(txt.Items);
            TimeSpan ime = DateTime.Now - d;
            label2.Text += ime.ToString();

            DateTime dd = DateTime.Now;
            txt_bin.File_bin();
            selection.Select_bin(txt_bin.Items_bin);
            TimeSpan ime2 = DateTime.Now - dd;
            label2.Text += $" Bin:{ime2.ToString()}";

            MessageBox.Show("Загрузка в файл завершена");
        }

        private void Insertion_sort_Click(object sender, EventArgs e)
        {
            Insertion insertion = new Insertion();

            DateTime d = DateTime.Now;
            txt.File();
            insertion.Insert(txt.Items);
            TimeSpan ime = DateTime.Now - d;
            label3.Text += ime.ToString();

            DateTime dd = DateTime.Now;
            txt_bin.File_bin();
            insertion.Insert(txt_bin.Items_bin);
            TimeSpan ime2 = DateTime.Now - dd;
            label3.Text += $" Bin:{ime2.ToString()}";

            MessageBox.Show("Загрузка в файл завершена");
        }

        private void Counting_sort_Click(object sender, EventArgs e)
        {
            Counting counting = new Counting();
            txt_bin.File_bin();
            DateTime d = DateTime.Now;
            counting.Count_s(txt_bin.Items_bin);
            TimeSpan ime = DateTime.Now - d;
            label4.Text += ime.ToString();
        }

        private void Quick_sort_Click(object sender, EventArgs e)
        {
            txt.File();
            Quick quick = new Quick();

            DateTime d = DateTime.Now;
            quick.Part(txt.Items, 0, txt.Items.Count - 1);
            txt.File_fin(txt.Items, "QuickSort");
            TimeSpan ime = DateTime.Now - d;
            label5.Text += ime.ToString();

            txt_bin.File_bin();

            DateTime dd = DateTime.Now;
            quick.Part(txt_bin.Items_bin, 0, txt_bin.Items_bin.Count - 1);
            TimeSpan ime2 = DateTime.Now - dd;
            label5.Text += $" Bin:{ime2.ToString()}";
            txt.File_fin_bin(txt_bin.Items_bin, "QuickSort");
        }

        private void Merge_sort_Click(object sender, EventArgs e)
        {
            txt.File();
            Merge merge = new Merge();

            DateTime d = DateTime.Now;
            merge.GO(txt.Items);
            TimeSpan ime = DateTime.Now - d;
            label6.Text += ime.ToString();

            txt_bin.File_bin();
            DateTime dd = DateTime.Now;
            MergeBin mergeBin = new MergeBin();
            mergeBin.GO(txt_bin.Items_bin);
            TimeSpan ime2 = DateTime.Now - dd;
            label6.Text += $" Bin:{ime2.ToString()}";
        }

        private void BinarySort_Click(object sender, EventArgs e)
        {
            DateTime d = DateTime.Now;
            txt.File_BinarySort_txt();
            TimeSpan ime = DateTime.Now - d;
            label7.Text += ime.ToString();

            DateTime dd = DateTime.Now;
            txt_bin.File_BinarySort();
            TimeSpan ime2 = DateTime.Now - dd;
            label7.Text += $" Bin:{ime2.ToString()}";
        }

        private void LSD_Sort_Click(object sender, EventArgs e)
        {
            txt_bin.File_radix();
            LSD lsd = new LSD();
            DateTime dd = DateTime.Now;
            lsd.Lsd_sort(txt_bin.Items_radix);
            TimeSpan ime2 = DateTime.Now - dd;
            label8.Text += $" Bin:{ime2.ToString()}";
            txt.File_fin_bin_radix(txt_bin.Items_radix, "LSD");
        }

        private void MSD_Sort_Click(object sender, EventArgs e)
        {
            txt_bin.File_radix();
            MSD msd = new MSD();

            DateTime dd = DateTime.Now;
            msd.Msd_sort(txt_bin.Items_radix);

            TimeSpan ime2 = DateTime.Now - dd;
            label9.Text += $" Bin:{ime2.ToString()}";
        }

        private void KMP_search_Click(object sender, EventArgs e)
        {
            char[] slovo = textBox1.Text.ToLower().ToCharArray();
            int[] pi = new int[textBox1.Text.Length];

            int j = 0;
            int i = 1;
            DateTime dd = DateTime.Now;
            while (i < slovo.Length)
            {
                if (slovo[j] == slovo[i])
                {
                    pi[i] = j + 1;
                    i += 1;
                    j += 1;
                }
                else
                {
                    if (j == 0)
                    {
                        pi[i] = 0;
                        i += 1;
                    }
                    else
                    {
                        j = pi[j - 1];
                    }
                }
            }

            string s = null;
            foreach (int c in pi)
            {
                s += c;
            }
            MessageBox.Show(s);

            char[] str = richTextBox1.Text.ToLower().ToArray();

            var temp = new List<int>();
            int[] mas = new int[str.Length];

            i = 0; j = 0;
            int value = 0; 
            while(i< str.Length)
            { 
                if(str[i] == slovo[j])
                {
                    i++;
                    j++;
                    mas[i] = j;
                    if (mas[i] == pi.Length)
                    {
                        value++;
                        temp.Add(i - 1);
                        richTextBox1.SelectionStart = i - j;
                        richTextBox1.SelectionLength = j;
                        richTextBox1.SelectionColor = Color.Red;
                        j = 0;
                    }
                }
                else
                {
                    if (j > 0)
                        j = pi[j - 1];
                    else
                        i++;
                }
            }

            TimeSpan ime2 = DateTime.Now - dd;
            label10.Text = $"{ime2.ToString()}, Слов: {value.ToString()}";
            txt.File_fin(temp, "KMP");
        }

        private void voinaimir_open_Click(object sender, EventArgs e)
        {
            richTextBox1.Text = txt.Voinaimir();
        }

        private void BMH_search_Click(object sender, EventArgs e)
        {
            char[] slovo = textBox1.Text.ToLower().ToCharArray();

            var s = new List<char>();
            int m = slovo.Length;

            Dictionary<char, int> d = new Dictionary<char, int>();

            for (int i = m - 2; i > -1; i--)
            {
                if (!s.Contains(slovo[i]))
                {
                    d[slovo[i]] = m - i - 1;
                    s.Add(slovo[i]);
                }
            }

            if (!s.Contains(slovo[m - 1]))
            {
                d[slovo[m - 1]] = m;
            }

            d['*'] = m;

            string v = null;
            foreach (KeyValuePair<char, int> k in d)
            {
                v += (k.Key + " - " + k.Value) + "\n";
            }
            MessageBox.Show(v);

            char[] str = richTextBox1.Text.ToLower().ToCharArray();
            int n = str.Length;
            int off = 0;

            var temp = new List<int>();

            int count = 0;

            DateTime dd = DateTime.Now;

            if (n >= m)
            {
                var i = m - 1;

                while (i < n)
                {
                    int k = 0;
                    int j = 0;
                    bool brek = false;
                    for (j = m - 1; j > -1; j--)
                    {
                        if (str[i - k] != slovo[j])
                        {
                            if (j == m - 1)
                            {
                                if (s.Contains(str[i]))
                                {
                                    off = d[str[i]];
                                }
                                else
                                {
                                    off = d['*'];
                                }
                            }
                            else
                            {
                                off = d[slovo[j]];
                            }

                            i += off;
                            brek = true;
                            break;
                        }
                        k++;
                    }

                    if (!brek)
                    {
                        temp.Add(i);
                        richTextBox1.SelectionStart = i - k + 1;
                        richTextBox1.SelectionLength = textBox1.Text.Length;
                        richTextBox1.SelectionColor = Color.Red;
                        i += slovo.Length;
                        count++;
                    }
                }
            }

            TimeSpan ime2 = DateTime.Now - dd;
            label11.Text = $"{ime2.ToString()}, Слов: {count.ToString()}";
            txt.File_fin(temp, "BMH");
        }

        private void Rabin_search_Click(object sender, EventArgs e)
        {
            string nom = "";
            char[] slovo = textBox1.Text.ToLower().ToCharArray();
            char[] str = richTextBox1.Text.ToLower().ToCharArray();

            int slovolen = slovo.Length;
            int strlen = str.Length;

            int slovoHash = Hash(slovo);

            char[] str_ = new char[slovo.Length];
            for (int i = 0; i < slovo.Length; i++)
            {
                str_[i] = str[i];
            }
            int strHash = Hash(str_);

            bool flag;
            int j = 0;
            int count = 0;
            var temp = new List<int>();

            DateTime dd = DateTime.Now;
            for (int i = 0; i < strlen - slovolen; i++)
            {
                if (slovoHash == strHash)
                {
                    flag = true;
                    j = 0;
                    while ((flag == true) && (j < slovolen))
                    {
                        if (slovo[j] != str[i + j])
                        {
                            flag = false;
                        }
                        j++;
                    }
                    if (flag == true)
                    {
                        temp.Add(i);
                        richTextBox1.SelectionStart = i;
                        richTextBox1.SelectionLength = textBox1.Text.Length;
                        richTextBox1.SelectionColor = Color.Red;
                        count++;
                    }
                }
                else
                {
                    strHash = (strHash - (int)Math.Pow(31, slovo.Length - 1) * (int)(str[i])) * 31 + (int)(str[i + slovo.Length]);
                }

            }
            TimeSpan ime2 = DateTime.Now - dd;
            label12.Text = $"{ime2.ToString()}, Слов: {count.ToString()}";
            txt.File_fin(temp, "Rabin");
        }

        int Hash(char[] str)
        {
            int p = 31;
            int rez = 0;
            for (int i = 0; i < str.Length; i++)
            {
                rez += (int)Math.Pow(p, str.Length - 1 - i) * (int)(str[i]);//РџРѕРґСЃС‡РµС‚ С…РµС€-С„СѓРЅРєС†РёРё
            }
            return rez;
        }
        double num = 0;
        private void RLE_coding_Click(object sender, EventArgs e)
        {
            var fileSize = new System.IO.FileInfo("войнаимир.txt").Length;
             num = Math.Round(fileSize / Math.Pow(2, 20), 4);
            label14.Text = $" Исходный: {num.ToString()} KB ";

            txt.Voinaimi_coder();

            RLE rle = new RLE();
            DateTime dd = DateTime.Now;
            rle.RLE_Coder(txt.convert);
            TimeSpan ime2 = DateTime.Now - dd;
            label13.Text += $"Coding^ {ime2.ToString()} ";

            DateTime d = DateTime.Now;
            rle.RLE_decoding("RLE_cod");
            TimeSpan ime = DateTime.Now - dd;
            label13.Text += $"Decoding^ {ime.ToString()}";

            var cod = new System.IO.FileInfo("RLE_cod.bin").Length;
            double coding = Math.Round(cod / Math.Pow(2, 20), 4);
            label14.Text += $" Coding^ {coding.ToString()} KB ";

            var dec = new System.IO.FileInfo("RLE_cod_decoder.txt").Length;
            double decoder = Math.Round(dec / Math.Pow(2, 20), 4);
            label14.Text += $" Decoding^ {decoder.ToString()} KB ";

            double sieze = Math.Round((1 - (coding / num)) * 100, 4);
            label15.Text = $"Степень: {sieze.ToString()}";           
        }

        private void LZ77_coding_Click(object sender, EventArgs e)
        {
            string s = txt.Voinaimir();

            LZ77 lz = new LZ77();
            DateTime dd = DateTime.Now;
            lz.Compress(s.ToArray());
            TimeSpan ime2 = DateTime.Now - dd;
            label18.Text += $"Coding^ {ime2.ToString()} ";

            DateTime d = DateTime.Now;
            lz.Decompress(lz.output_list);
            TimeSpan ime = DateTime.Now - d;

            label18.Text += $"Decoding^ {ime.ToString()}";

            var cod = new System.IO.FileInfo("LZ77_coding.txt").Length;
            double coding = Math.Round(cod / Math.Pow(2, 20), 4);
            label17.Text = $" Coding^ {coding.ToString()} KB ";

            var dec = new System.IO.FileInfo("LZ77_coding_decoding.txt").Length;
            double decoder = Math.Round(dec / Math.Pow(2, 20), 4);
            label17.Text += $" Decoding^ {decoder.ToString()} KB ";

            var fileSize = new System.IO.FileInfo("войнаимир.txt").Length;
            num = Math.Round(fileSize / Math.Pow(2, 20), 4);

            double sieze = Math.Round((1 - (coding / num)) * 100, 4);
            label16.Text = $"Степень: {sieze.ToString()}";

        }

        static Dictionary<string, string> huffmanTable = new Dictionary<string, string>();

        private void Huffman_coding_Click(object sender, EventArgs e)
        {
            Controll control = new Controll();
            DateTime dd = DateTime.Now;
            control.Coding();
            TimeSpan ime2 = DateTime.Now - dd;
            label21.Text += $"Coding^ {ime2.ToString()} ";

            DateTime d = DateTime.Now;
            control.Decoding();
            TimeSpan ime = DateTime.Now - d;
            label21.Text += $"Decoding^ {ime.ToString()}";

            var cod = new System.IO.FileInfo("Huffman_coding.bin").Length;
            double coding = Math.Round(cod / Math.Pow(2, 20), 4);
            label20.Text = $" Coding^ {coding.ToString()} KB ";

            var dec = new System.IO.FileInfo("Huffman_coding_decoding.txt").Length;
            double decoder = Math.Round(dec / Math.Pow(2, 20), 4);
            label20.Text += $" Decoding^ {decoder.ToString()} KB ";

            var fileSize = new System.IO.FileInfo("войнаимир.txt").Length;
            num = Math.Round(fileSize / Math.Pow(2, 20), 4);

            double sieze = Math.Round((1 - (coding / num)) * 100, 4);
            label19.Text = $"Степень: {sieze.ToString()}";


        }


    }

}
