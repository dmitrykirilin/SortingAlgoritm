using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms
{
    public class ShellSort<T> : AlgorithmBase<T> where T: IComparable
    {
        public ShellSort(IEnumerable<T> items) : base(items) { }

        public ShellSort() { }

        protected override void MakeSort()
        {
            var step = Items.Count / 2;

            while (step > 0)
            {
                for (int j = step; j < Items.Count; j++)
                {
                        var current = j;

                        while (current >= step && Compare(Items[current], Items[current - step]) == -1)
                        {
                            Swop(current, current - step);
                            current -= step;
                        }
                
                }
                step /= 2;
            }
        }
    }
}
