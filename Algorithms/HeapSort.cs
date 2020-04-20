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
            var heap = new Heap<T>(Items);
            Items = heap.GetSortedList();
        }
    }
}
