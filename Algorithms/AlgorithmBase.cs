using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms
{
    public class AlgorithmBase<T> where T: IComparable
    {
        public int SwopCount { get; protected set; } = 0;
        public int ComparisonCount { get; protected set; } = 0;


        public List<T> Items { get; set; } = new List<T>();

        protected void Swop(int positionA, int positiomB)
        {
            if (positionA < Items.Count && positiomB < Items.Count)
            {
                var temp = Items[positionA];
                Items[positionA] = Items[positiomB];
                Items[positiomB] = temp;

                SwopCount++;
            }
        }

        public TimeSpan Sort()
        {
            SwopCount = 0;
            var timer = new Stopwatch();
            timer.Start();
            MakeSort();
            timer.Stop();
            return timer.Elapsed;
        }

        protected virtual void MakeSort()
        {
            Items.Sort();
        }
        
    }
}
