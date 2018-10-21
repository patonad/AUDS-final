using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace AVL
{
    public class AvlNode<T>
    {
        public int Vyska { get; set; } = 0;
       
        public AvlNode<T> Left
        {
            get;
            set;
        }
        public AvlNode<T> Right
        {
            get;
            set;
        }
        public AvlNode<T> Parent
        {
            get;
            set;
        }
        public T Data
        {
            get;
            set;
       
    }
        public bool SomPravy()
        {
            return this == Parent.Right;
        }
    }
}
