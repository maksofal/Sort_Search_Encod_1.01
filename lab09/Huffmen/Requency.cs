using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab06_TP.lab09.Huffmen
{
    class Requency //для хранения частоты встречи байта в данных
    {
        private long[] frequency;

        public Requency() //объявление - получение для декодирования
        {
            frequency = new long[256];
        }

        public void Add(byte _value) // количество символов, принимает байт одного символа 
        {
            frequency[_value]++; //value - символ ++
        }

        public long this[int index]
        {
            get
            {
                return frequency[index];
            }
            set
            {
                frequency[index] = value;
            }
        }

        public int Length
        {
            get
            {
                return frequency.Length;
            }
        }
    }
}
