using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.DataStructures
{
    public class Heap<T>
           where T : IComparable
    {
        public List<T> items = new List<T>();

        public int Count => items.Count;

        public Heap() { }

        public Heap(List<T> range)
        {

            foreach (var item in range)
            {
                this.Push(item);
            }
        }

        public T GetMax()
        {
            if (Count > 0)
            {
                return items[0];
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
                return items[0];
            }
            else
            {
                return default(T);
            }
        }

        public void Push(T item)
        {
            items.Add(item);

            var i = Count - 1;
            while (items[i].CompareTo(items[(i - 1) / 2]) == -1 && i > 0)
            {
                var temp = items[i];
                items[i] = items[(i - 1) / 2];
                items[(i - 1) / 2] = temp;
                i = (i - 1) / 2;
            }
        }

        public T Pop()
        {
            var result = items[0];

            items[0] = items[Count - 1];
            items.RemoveAt(Count - 1);

            int i = 0;

            while (i * 2 + 1 < Count)
            {
                if (i * 2 + 2 < Count)
                {
                    if (items[i].CompareTo(items[2 * i + 1]) == 1 ||
                    items[i].CompareTo(items[2 * i + 2]) == 1)
                    {
                        if (items[2 * i + 1].CompareTo(items[2 * i + 2]) == -1)
                        {
                            Swap(i, 2 * i + 1);
                            i = 2 * i + 1;
                        }
                        else
                        {
                            Swap(i, 2 * i + 2);
                            i = 2 * i + 2;
                        }

                    }
                    else
                    {
                        break;
                    }
                }
                else if (items[i].CompareTo(items[2 * i + 1]) == 1)
                {
                    Swap(i, 2 * i + 1);
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

        private void Swap(int a, int b)
        {
            var temp = items[a];
            items[a] = items[b];
            items[b] = temp;
        }
    }
}
