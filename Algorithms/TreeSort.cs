using Algorithm.DataStructures;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms
{
    public class TreeSort<T> : AlgorithmBase<T> where T: IComparable
    {
        public Tree<T> tree { get; set; }

        public TreeSort(IEnumerable<T> items) : base(items)
        {
        }

        public TreeSort() { }

        protected override void MakeSort()
        {
            tree = new Tree<T>(Items);
            Items = tree.InOrder();
        }
    }
}
