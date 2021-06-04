using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab06_TP.lab09.Huffmen
{
    class BinaryTree
    {
        private List<TreeNode> nodeList;
        private TreeNode decodeNode;
       
        public BinaryTree(Requency frequency) //формируем коллекцию 
        {
            nodeList = new List<TreeNode>();
            for (short i = 0; i < frequency.Length; i++) //проход по количеству 
            {
                if (frequency[i] > 0)
                    nodeList.Add(new TreeNode(frequency[i], (byte)i));  //количетсво , символ 
            }
            nodeList.Sort();
            BuildTree();
        }

        //функция постройки полного древа 
        private int BuildTree()
        {
            while (nodeList.Count > 1)
            {
                TreeNode A = nodeList[0];
                TreeNode B = nodeList[1];
                nodeList.RemoveRange(0, 2);
                nodeList.Add(new TreeNode(A.weight + B.weight, A, B)); //   дерево |  (а) - общая длина(0) - (в) 
                nodeList.Sort();
            }
            return 0;
        }

        //рекурсивный поиск пути к нужной ноде и запись в стек
        private int SearchNode(Stack stack, TreeNode node, short childA, byte value)
        {
            if (node == null)
                return -1;
            if (childA >= 0)
                stack.Push(childA);
            if ((node.value == value && node.hasValue) || SearchNode(stack, node.childA, 1, value) > 0 || SearchNode(stack, node.childB, 0, value) > 0)
                return 1;
            stack.Pop();
            return -1;
        }

        //кодирование знака в биты
        public Dictionary<byte, short[]> GetCodeTable(Requency frequency)
        {
            Stack treePath = new Stack(256);
            
            Dictionary<byte, short[]> codeTable = new Dictionary<byte, short[]>();

            for (short i = 0; i < frequency.Length; i++)
            {
                if (frequency[i] > 0)
                {
                    SearchNode(treePath, nodeList[0], -1, (byte)i); // запись в стек
                    short[] dump = treePath.GetDump(out short length);
                    short[] resizedDump = new short[length];
                    for (short t = 0; t < length; t++)
                    {
                        resizedDump[t] = dump[t];
                    }
                    codeTable.Add((byte)i, resizedDump); //коды символа
                    treePath.Reset();
                }
            }
            //возвращаем таблицу с кодами
            return codeTable;
        }

        //обход всего дерева для составления кода. самая медленная часть распаковки
        //выполняется 1 раз на каждый бит
        //с каждым вызовом идем в дерево дальше, выбирая направление в зависмости от полученного параметра
        //входные параметры 1 и 0
        public short Decode(byte childA) //движение по ветке
        {
            if (decodeNode == null)
            {
                decodeNode = nodeList[0];
            }

            if (childA == 1)
            {
                decodeNode = decodeNode.childA;
            }
            else
            {
                decodeNode = decodeNode.childB;
            }

            if (decodeNode.hasValue)
            {
                short value = decodeNode.value;
                decodeNode = null;
                return value;
            }
            return -1;
        }



    }
}
