using System;
using System.Collections.Generic;

namespace Algorithms
{
    public class InsertSort<T> : AlgorithmBase<T> where T : IComparable
    {
        public InsertSort(IEnumerable<T> items) : base(items) { }
        public InsertSort() { }

        protected override void MakeSort()
        {
            int insertIndex = 0;
            int count = Items.Count;
            if(count > 1)
            {
                insertIndex = 1;
            }
            for (int i = 0; i < count - 1; i++)
            {
                insertIndex = i + 1;
                while (insertIndex != 0 && Compare(Items[insertIndex], Items[insertIndex - 1]) == -1)
                {
                    Swop(insertIndex, insertIndex - 1);
                    insertIndex--;
                    SwopCount++;
                }
            }
        }
    }
}
