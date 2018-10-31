using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AVL;

namespace AUDS2.AVL
{
    class AVLEnumerator<T>: IEnumerator<T>
    {
        public AVLEnumerator(AvlNode<T> root)
        {
            _current = root;
            _stack = new Stack<AvlNode<T>>();
        }

        public AvlNode<T> Root { get; set; }
        public Stack<AvlNode<T>> _stack { get; set; }
        public AvlNode<T> _current { get; set; }
        public T _result { get; set; }
        public void Dispose()
        {
            _current = null;
        }

        public bool MoveNext()
        {
            while (_stack.Count > 0 || _current != null)
            {
                if (_current != null)
                {
                    _stack.Push(_current);
                    _current = _current.Left;
                }
                else
                {
                    _current = _stack.Pop();
                    _result = _current.Data;
                    _current = _current.Right;
                    return true;
                }
            }
            return false;
        }

        public void Reset()
        {
            throw new NotImplementedException();
        }

        public T Current
        {
            get { return _result; }
        }

        object IEnumerator.Current => Current;
    }
}
