using lab06_TP.lab09;
using lab6_TP.lab07;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab06_TP
{
    class Start
    {
        public List<string> Items { get; set; } = new List<string>();
        public void File()
        {
            Items.Clear();
            using (StreamReader fs = new StreamReader("file1.txt"))
            {
                while (true)
                {
                    string temp = fs.ReadLine();
                    if (temp == null) break;
                    Items.Add(temp);
                }
            }
        }

        public void File_fin(List<string> Go, string name)
        {
            using (StreamWriter fs = new StreamWriter($"{name}.txt", false, Encoding.GetEncoding(1251)))
            {
                foreach (string file in Go)
                {
                    fs.WriteLine(file);
                }
            }
        }
        public void File_fin(List<char> Go, string name)
        {
            using (StreamWriter fs = new StreamWriter($"{name}.txt", false, Encoding.GetEncoding(1251)))
            {
                foreach (char file in Go)
                {
                    fs.Write(file);
                }
            }
        }

        public void File_fin(List<Pair> Go, string name)
        {
            using (StreamWriter fs = new StreamWriter($"{name}.txt", false, Encoding.GetEncoding(1251)))
            {
                foreach (Pair file in Go)
                {
                  //  if (file.start_index != 0 && file.lenght != 0)
                  //  {
                      //  fs.Write($"{file.start_index} {file.lenght} {file.letter} ");
                  //  }
                  //  else
                   // {
                        fs.Write($"{file.letter}");
                    //}

                }
            }
        }


        public void File_fin(List<int> Go, string name)
        {
            using (StreamWriter fs = new StreamWriter($"{name}.txt", false, Encoding.GetEncoding(1251)))
            {
                foreach (int file in Go)
                {
                    fs.WriteLine(file);
                }
            }
        }


        public List<int> Items_bin { get; set; } = new List<int>();

        public void File_bin()
        {
            Items_bin.Clear();
            using (FileStream stream = new FileStream("file2.bin", FileMode.Open, FileAccess.Read))
            {
                using (BinaryReader fs = new BinaryReader(stream, Encoding.Default))
                {
                    while (fs.PeekChar() > -1)
                    {
                        //var temp = Encoding.Unicode.get(fs.ReadByte());
                        var temp = Convert.ToInt16(fs.ReadByte());
                        Items_bin.Add(temp);

                    }
                }
            }
        }

        public void File_fin_bin(List<int> Go, string name)
        {
            using (FileStream stream = new FileStream($"{name}.bin", FileMode.Create, FileAccess.Write))
            {
                using (BinaryWriter fs = new BinaryWriter(stream, Encoding.Default))
                {

                    foreach (int file in Go)
                    {
                        fs.Write(Convert.ToByte(file));
                    }
                }
            }

        }

        public void File_BinarySort()
        {
            var Items_BinarySort = new Tree<int>();
            using (FileStream stream = new FileStream("file2.bin", FileMode.Open, FileAccess.Read))
            {
                using (BinaryReader fs = new BinaryReader(stream, Encoding.Default))
                {
                    while (fs.PeekChar() > -1)
                    {
                        var temp = Convert.ToInt16(fs.ReadByte());
                        Items_BinarySort.Add(temp);
                    }
                }
            }
            File_fin_bin(Items_BinarySort.Inorder(), "BinarySort");
        }

        public void File_BinarySort_txt()
        {
            var Items_BinarySort_txt = new Tree<string>();
            using (StreamReader fs = new StreamReader("file1.txt", Encoding.GetEncoding(1251)))
            {
                while (true)
                {
                    string temp = fs.ReadLine();
                    if (temp == null) break;
                    Items_BinarySort_txt.Add(temp);
                }
            }

            File_fin(Items_BinarySort_txt.Inorder(), "BinarySort");

        }

        public string g = null;

        public string Voinaimir()
        {
            
            using (StreamReader fs = new StreamReader("войнаимир.txt", Encoding.GetEncoding(1251)))
            {
                string temp = fs.ReadToEnd();
                g += temp;
            }

            return g;
        }

        public List<string> Items_radix { get; set; } = new List<string>();
        public void File_radix()
        {
            Items_radix.Clear();
            using (FileStream stream = new FileStream("file2.bin", FileMode.Open, FileAccess.Read))
            {
                using (BinaryReader fs = new BinaryReader(stream, Encoding.Default))
                {
                    while (fs.PeekChar() > -1)
                    {
                        //var temp = Encoding.Unicode.get(fs.ReadByte());
                        var temp = Convert.ToString(fs.ReadByte(), 2);
                        Items_radix.Add(temp);

                    }
                }
            }
        }

        public void File_fin_bin_radix(List<string> Go, string name)
        {
            Items_radix.Clear();

            using (FileStream stream = new FileStream($"{name}.bin", FileMode.Create, FileAccess.Write))
            {
                using (BinaryWriter fs = new BinaryWriter(stream, Encoding.Default))
                {
                    foreach (string file in Go)
                    {
                        fs.Write(Convert.ToByte(Convert.ToInt16(file, 2)));
                    }
                }
            }
        }

        public byte[] convert = null;
        public void Voinaimi_coder()
        {
            convert = null;
            using (StreamReader fs = new StreamReader("войнаимир.txt", Encoding.GetEncoding("windows-1251")))
            {
                string str = fs.ReadToEnd();
                Encoding srcEncodingFormat = Encoding.GetEncoding("windows-1251");
                byte[] originalByteString = srcEncodingFormat.GetBytes(str);
                convert = originalByteString;

            }
        }
        public void RLE_file_coding_save(byte[] list, string name)
        {
            using (FileStream stream = new FileStream($"{name}.bin", FileMode.Create, FileAccess.Write))
            {
                using (BinaryWriter fs = new BinaryWriter(stream, Encoding.GetEncoding("windows-1251")))
                {
                    fs.Write(list);
                }
            }

        }

        public List<string> LZ77 { get; set; } = new List<string>();
        public void Voinaimir_LZ77()
        {
            using (StreamReader fs = new StreamReader("войнаимир.txt", Encoding.GetEncoding(1251)))
            {
                while (true)
                {
                    string temp = fs.ReadLine();
                    if (temp == null) break;
                    LZ77.Add(temp);
                }

            }            
        }
        

    }
    class FileOperation //для чтения файла и записи результата
    {
        private FileStream fileStream;
        private bool isReadMode;

        public FileOperation(string path, bool readMode)
        {
            isReadMode = readMode;
            if (isReadMode)
            {
                fileStream = new FileStream(@path, FileMode.Open);
            }
            else
            {
                fileStream = new FileStream(@path, FileMode.Create);
            }
        }

        public short EndOfFile()
        {
            if (fileStream.Position == fileStream.Length)
            {
                return 1;
            }
            return 0;
        }

        public int ReadFile(byte[] buffer, int size)
        {
            if (!isReadMode)
                return 0;
            int bytesRead = fileStream.Read(buffer, 0, size); 
            return bytesRead;
        }

        public int WriteFile(byte[] buffer, int size) // считываем блок байтов size  записываем в буффер 
        {
            if (isReadMode)
                return 0;
            fileStream.Write(buffer, 0, size);
            return 1;
        }

        public int Reset()
        {
            fileStream.Position = 0;
            return 1;
        }

        public int CloseFile()
        {
            fileStream.Close();
            return 1;
        }

        public bool IsReadMode()
        {
            return isReadMode;
        }

        public long GetPos()
        {
            return fileStream.Position;
        }
    }
}
