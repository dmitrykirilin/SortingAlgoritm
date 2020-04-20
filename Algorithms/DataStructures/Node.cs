using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithm.DataStructures
{
    public class Node<T> : IComparable
        where T : IComparable
    {
        public T Data { get; private set; }

        public Node<T> Left { get; set; }

        public Node<T> Right { get; set; }

        public Node(T data)
        {
            Data = data;
        }

        public Node(T data, Node<T> left, Node<T> right)
        {
            Data = data;
            Left = left;
            Right = right;
        }

        public int CompareTo(object obj)
        {
            if (obj is Node<T> item)
            {
                return this.Data.CompareTo(item.Data);
            }
            else
            {
                throw new ArgumentException("obj не является типом Node<T>");
            }
        }
    }
}

