using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab06_TP.lab09.Huffmen
{
    class Controll
    {
        const int size = 32;

        public void Coding()
        {          
            FileOperation InputFile = null;

            if (File.Exists("войнаимир.txt"))
            {
                InputFile = new FileOperation("войнаимир.txt", true);
            }
            
            int bytesRead;
            byte[] buf = new byte[size];


            Requency frequency = new Requency(); //объявление счетчика 

            while ((bytesRead = InputFile.ReadFile(buf, size)) > 0) // считываем с файла  [32] ->> в каждый i - символ, пока не закончится файл
            {
                for (int i = 0; i < bytesRead; i++)
                {
                    frequency.Add(buf[i]);
                }
            }

            BinaryTree tree = new BinaryTree(frequency); // дерево

            Dictionary<byte, short[]> codeTable = tree.GetCodeTable(frequency);

            InputFile.Reset();
            FileOperation outputFile = new FileOperation("Huffman_coding" + ".bin", false);

            outputFile.WriteFile(new byte[] { 0 }, 1); //резерв места под число пустых бит в конце

            for (short i = 0; i < frequency.Length; i++) //записываем таблицу частот
            {
                outputFile.WriteFile(BitConverter.GetBytes(frequency[i]), sizeof(long));
            }

            //упаковываем
            int outPos = 0; //текущий индекс в выходном массиве в _битах_
            byte[] outBuf = new byte[32]; //выходной массив
            bytesRead = InputFile.ReadFile(buf, size); 
            while (bytesRead > 0)
            {
                for (byte i = 0; i < bytesRead; i++)
                {
                    byte value = buf[i]; //берем i символ из файла 
                    for (byte t = 0; t < codeTable[value].Length; t++) //длина массива для каждого символа получаемого из buf
                    {
                        outBuf[outPos / 8] |= (byte)(codeTable[value][t] * Math.Pow(2, 7 - outPos % 8)); //разбиваем число на 2 байта, побитовое или, получаем код [символа]
                        outPos++;
                        if (outPos >= 32 * 8)
                        {
                            outputFile.WriteFile(outBuf, 32);
                            outPos = 0;
                            Array.Clear(outBuf, 0, 32);
                            //запись в файл
                        }
                    }
                }
                bytesRead = InputFile.ReadFile(buf, size); // считываем каждый раз новый буфер по 32
            }
            if (outPos > 0) //запись оставшихся бит
            {
                outputFile.WriteFile(outBuf, outPos / 8 + ((outPos % 8 > 0) ? 1 : 0));
            }
            outputFile.Reset();
            outputFile.WriteFile(new byte[] { (byte)((8 - outPos % 8) % 8) }, 1); //записываем количество пустых бит в конце
            outputFile.CloseFile();
            InputFile.CloseFile();

        }

        public  int Decoding()
        {
            FileOperation inputFile;
            if (File.Exists("Huffman_coding.bin"))
            {
                inputFile = new FileOperation("Huffman_coding.bin", true);
            }
            else
            {
                return -1;
            }

            int bytesRead;
            byte[] endBytes = new byte[1]; //получаем число байт в конце

            bytesRead = inputFile.ReadFile(endBytes, 1);

            Requency frequency = new Requency(); //получаем таблицу частот - пустую

            byte[] buf = new byte[2048]; // buf[символ] - количество  //считаный файл

            if ((bytesRead = inputFile.ReadFile(buf, 2048)) < 2048)
                return -1;
            for (short i = 0; i < 256; i++)
            {
                frequency[i] = BitConverter.ToInt64(buf, i * sizeof(long)); //конвертируем из  buf[i*8] - тем самым сново получает [символ] - колличество 
            }

            //создаем дерево
            BinaryTree tree = new BinaryTree(frequency);

            //распаковываем
            FileOperation outputFile = new FileOperation("Huffman_coding_decoding.txt", false); 

            int outPos = 0, outVal;
            buf = new byte[size];
            byte[] outBuf = new byte[size];
           

            bytesRead = inputFile.ReadFile(buf, size); //считывание данных с файла 
            while (bytesRead > 0)
            {
                int emptyBits = endBytes[0] * inputFile.EndOfFile(); //проверка
                for (short i = 0; i < bytesRead * 8 - emptyBits; i++) //нумеруем _биты_
                {
                    byte value = buf[i >> 3]; // свигаем биты числа i-ого
                    byte bit = (byte)(((buf[i >> 3] & 1 << (7 - i % 8)) >= 1) ? 1 : 0); //получаем значение бита под номером i
                    outVal = tree.Decode(bit); //поочередно отправляем биты расшифровщику - сравнение значений с деревом и возврат , если 1-А если 0-В из bit и присваивает код символа 
                    if (outVal >= 0)
                    {
                        outBuf[outPos] = (byte)outVal;
                        outPos++;
                        if (outPos >= size)
                        {
                            outPos = 0;
                            outputFile.WriteFile(outBuf, size);
                        }
                    }
                }
                bytesRead = inputFile.ReadFile(buf, size);
            }
            //записываем оставшиеся байты, закрываем файлы
            if (outPos > 0)
            {
                outputFile.WriteFile(outBuf, outPos);
            }

            
            outputFile.CloseFile();
            inputFile.CloseFile();
            return 1;
        }

    }
}
