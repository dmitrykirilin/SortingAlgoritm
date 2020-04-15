using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms
{
    public class CocKtailSort<T> : AlgorithmBase<T> where T: IComparable
    {
        public CocKtailSort(IEnumerable<T> items) : base(items) { }
        public CocKtailSort() { }

        protected override void MakeSort()
        {
            int left = 0;
            int right = Items.Count - 1;

            while (left < right)
            {
                var sc = SwopCount;
                for (int i = left; i < right; i++)
                {
                    if(Compare(Items[i], Items[i + 1]) == 1)
                    {
                        Swop(i, i + 1);
                    }
                }
                
                if (sc == SwopCount)
                {
                    break;
                }
                right--;

                for (int i = right; i > left; i--)
                {
                    if (Compare(Items[i], Items[i - 1]) == -1)
                    {
                        Swop(i, i - 1);
                    }
                }
                
                if (sc == SwopCount)
                {
                    break;
                }
                left++;
            }
        }
    }
}
