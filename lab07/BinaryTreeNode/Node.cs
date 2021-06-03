using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab6_TP.lab07
{
     class Node<T> : IComparable
        where T: IComparable
     {
        public T Data { get; set; }
        public Node<T> Left { get; set; }
        public Node<T> Right { get; set; }

        public string Binar { get; set; }

        public Node(T data)
        {
            Data = data;
        }

        public Node(T data, Node<T> left, Node<T> right, string binar)
        {
            Data = data;
            Left = left;
            Right = right;
            Binar = binar;
        }

        public void Add(T data)
        {
            var node = new Node<T>(data);
            if(node.Data.CompareTo(Data) == -1)
            {
                if(Left == null)
                {                                     
                    Left = node;                    
                }
                else
                {
                    Left.Add(data);
                    
                }
            }
            else
            {
                if (Right == null)
                {
                    Right = node;
                }
                else
                {
                    Right.Add(data);                   
                }
            }
        }

        public int CompareTo(object obj)
        {
            if (obj is Node<T> item)
            {
                return Data.CompareTo(item);
            }
            else
            {
                throw new Exception("Не совпадение типов");
            }
        }
    }      

}
