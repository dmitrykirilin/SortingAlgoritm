using Algorithms.DataStructures;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms
{
    public class HeapSort<T> : AlgorithmBase<T> where T : IComparable
    {
        public HeapSort(IEnumerable<T> items) : base(items) { }

        public HeapSort(){}

        protected override void MakeSort()
        {
            var newItems = new List<T>();
            newItems.AddRange(Items);
            Items.Clear();

            foreach (var item in newItems)
            {
                this.Push(item);
            }

            var stack = new Stack<T>();

            newItems.Clear();

            while (Count > 0)
            {
                stack.Push(Pop());
            }
            Items.AddRange(stack);
        }

        public int Count => Items.Count;
        
        //public HeapSort(IEnumerable<T> range)
        //{

        //    foreach (var item in range)
        //    {
        //        this.Push(item);
        //    }
        //}

        public T GetMax()
        {
            if (Count > 0)
            {
                return Items[0];
            }
            else
            {
                return default(T);
            }
        }

        public T Peek()
        {
            if (Count > 0)
            {
                return Items[0];
            }
            else
            {
                return default(T);
            }
        }

        public void Push(T item)
        {
            Items.Add(item);

            var i = Count - 1;
            while (i > 0 && Compare(Items[i], Items[(i - 1) / 2]) == -1)
            {
                Swop(i, (i - 1) / 2);
                i = (i - 1) / 2;
            }
        }

        public T Pop()
        {
            var result = Items[0];

            Items[0] = Items[Count - 1];
            Items.RemoveAt(Count - 1);

            int i = 0;

            while (i * 2 + 1 < Count)
            {
                if (i * 2 + 2 < Count)
                {
                    if (Compare(Items[i], Items[2 * i + 1]) == 1 ||
                    Compare(Items[i], Items[2 * i + 2]) == 1)
                    {
                        if (Items[2 * i + 1].CompareTo(Items[2 * i + 2]) == -1)
                        {
                            Swop(i, 2 * i + 1);
                            i = 2 * i + 1;
                        }
                        else
                        {
                            Swop(i, 2 * i + 2);
                            i = 2 * i + 2;
                        }

                    }
                    else
                    {
                        break;
                    }
                }
                else if (Compare(Items[i], Items[2 * i + 1]) == 1)
                {
                    Swop(i, 2 * i + 1);
                    break;
                }
                else
                {
                    break;
                }
            }
            return result;
        }

        public List<T> GetSortedList()
        {
            var SortedList = new List<T>();
            while (Count > 0)
            {
                SortedList.Add(Pop());
            }
            return SortedList;
        }

    }
}
