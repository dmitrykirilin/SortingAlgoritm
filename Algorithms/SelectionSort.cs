using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms
{
    public class SelectionSort<T> : AlgorithmBase<T> where T : IComparable
    {

        public SelectionSort(IEnumerable<T> items) : base(items)
        {
        }

        public SelectionSort() { }

        protected override void MakeSort()
        {
            var minIndex = 0;

            while (minIndex < Items.Count - 1)
            {
                var comparison = minIndex + 1;
                var swapIndex = minIndex;
                while (comparison < Items.Count)
                {
                    
                    if (Compare(Items[swapIndex], Items[comparison]) == 1)
                    {
                        swapIndex = comparison;
                    }
                    comparison++;
                }
                if (minIndex < swapIndex)
                {
                    Swop(minIndex, swapIndex);
                }
                minIndex++;
            }
        }
    }
}
