using lab06_TP;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab6_TP.lab07
{
    class Tree<T>
        where T : IComparable
    {
        public Node<T> Root { get; set; }
        public int Count { get; set; }

        public void Add(T data) 
        {
            if(Root == null)
            {
                Root = new Node<T>(data); 
                Count = 1;
                return;
            }
            Root.Add(data);
            Count++;
        }

        public List<T> Inorder()
        {
            if(Root == null)
            {
                return new List<T>();
            }
            return Inorder(Root);

        }
        public List<string> h = new List<string>();
        private List<T> Inorder(Node<T> node)
        {
            var list = new List<T>();
            
            if(node != null)
            {
                if(node.Left != null)
                {
                    list.AddRange(Inorder(node.Left));
                    h.Add(node.Left.Binar);
                }
                list.Add(node.Data);
                h.Add(node.Binar);
                if (node.Right != null)
                {
                    list.AddRange(Inorder(node.Right));
                    h.Add(node.Right.Binar);
                }
            }
            
            return list;

        }
        
    }
}
