using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Algorithms
{
    public class AlgorithmBase<T> where T: IComparable
    {
        public int SwopCount { get; protected set; } = 0;

        public int ComparisonCount { get; protected set; } = 0;

        public List<T> Items { get; set; } = new List<T>();

        public virtual event EventHandler<Tuple<T, T>> CompareEvent;
        public virtual event EventHandler<Tuple<T, T>> SwopEvent;

        public AlgorithmBase() { }

        public AlgorithmBase(IEnumerable<T> items)
        {
            Items.AddRange(items);
        }

        protected void Swop(int positionA, int positionB)
        {
            if (positionA < Items.Count && positionB < Items.Count)
            {
                var temp = Items[positionA];
                Items[positionA] = Items[positionB];
                Items[positionB] = temp;
                SwopCount++;
                
                SwopEvent?.Invoke(this, new Tuple<T, T>(Items[positionA], Items[positionB]));
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
        
        protected virtual int Compare(T a, T b)
        {
            CompareEvent?.Invoke(this, new Tuple<T, T>(a, b));
            ComparisonCount++;
            return a.CompareTo(b);
        }
    }
}
