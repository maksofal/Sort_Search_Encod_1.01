using lab06_TP;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab6_TP.lab09
{
    class RLE
    {
        private void Add(List<byte> array, ref int key)
        {
            array.Add(0);
            key = array.Count - 1;
        }

        public List<byte> packedArray = new List<byte>();

        public void RLE_Coder(byte[] list)
        {            
            int i = 0;
            byte count = 0;
            int key = 0;
            Add(packedArray, ref key);
            while (i < list.Length)
            {
                count = 1;
                while (true)
                {
                    if (i + count > list.Length -1 || count > 0x80) // придел
                    {
                        break;
                    }

                    if (list[i] == list[i + count])
                    {
                        count++;
                    }
                    else
                        break;
                }
                if (count > 1)
                {
                    if (packedArray[key] > 0x80)
                    {
                        Add(packedArray, ref key);
                    }
                    packedArray.Add(list[i]);
                    packedArray[key] = count;
                    if (i + count < list.Length - 1)
                    {
                        Add(packedArray, ref key);
                    }
                }
                else
                {
                    count = 1;
                    if (((packedArray[key] + count) & 0x7F) > 0x7E) // провека что последовательность неодинаковых байт не привышает границу листа
                    {
                        Add(packedArray, ref key);
                    }
                    packedArray.Add(list[i]);
                    packedArray[key] = packedArray[key] > 0x80 ? (byte)(packedArray[key] + count) : (byte)(0x80 + count); 
                                                                                                                          
                }
                i+=count;
            }
            packedArray.Add(0x0FF);

            Start start = new Start();
            start.RLE_file_coding_save(packedArray.ToArray(), "RLE_cod");           
        }

        public void RLE_decoding(string name)
        {
            var decod = new List<byte>();
            using (FileStream stream = new FileStream($"{name}.bin", FileMode.Open, FileAccess.Read))
            {
                using (BinaryReader fs = new BinaryReader(stream, Encoding.GetEncoding("windows-1251")))
                {
                    int count_pack = 0;
                    byte count = 0;
                    byte valye = 0;

                    while (count != 0xFF)
                    {
                        count = fs.ReadByte();
                        if (count != 0xFF)
                        {
                            if (count > 0x80)
                            {
                                count -= 0x80;
                                for (int j = 0; j < count; j++)
                                {
                                    decod.Add(fs.ReadByte());
                                }
                                count_pack += count + 1;
                            }
                            else // если одинаковые
                            {
                                valye = fs.ReadByte();
                                for (int j = 0; j < count; j++)
                                {
                                    decod.Add(valye); // запись одинаковых
                                }
                                count_pack += 2;
                            }

                        }

                    }
                }
            }

            using (StreamWriter fs = new StreamWriter($"{name}_decoder.txt", false, Encoding.GetEncoding("windows-1251")))
            {
                Encoding srcEncodingFormat = Encoding.GetEncoding("windows-1251");
                Encoding dstEncodingFormat = Encoding.GetEncoding("windows-1251");
                byte[] convertedByteString = Encoding.Convert(srcEncodingFormat,
                dstEncodingFormat, decod.ToArray());
                string finalString = dstEncodingFormat.GetString(convertedByteString);
                fs.Write(finalString);

            }
        }

    }
}
