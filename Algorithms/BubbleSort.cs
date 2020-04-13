using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms
{
    public class BubbleSort<T> : AlgorithmBase<T> where T : IComparable
    {
        protected override void MakeSort()
        {
            var count = Items.Count;

            for (int j = 0; j < count-1; j++)
            {
                int sc = SwopCount;
                for (int i = 0; i < count - 1 - j; i++)
                {
                    var a = Items[i];
                    var b = Items[i + 1];
                    if(a.CompareTo(b) == 1)
                    {
                         Swop(i, i + 1);
                    }
                }
                
                if (sc == SwopCount)
                {
                    break;
                }
            }
        }
       
    }
}
