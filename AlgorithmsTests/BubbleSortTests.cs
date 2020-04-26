using Microsoft.VisualStudio.TestTools.UnitTesting;
using Algorithms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.Tests
{
    [TestClass()]
    public class BubbleSortTests
    {
        List<int> Items = new List<int>();
        List<int> Sorted = new List<int>();
        Random rnd = new Random();

        [TestInitialize]
        public void Init()
        {
            Sorted.Clear();
            for (int i = 0; i < 1000; i++)
            {
                Items.Add(rnd.Next(1, 1000));
            }
            Sorted.AddRange(Items.OrderBy(x => x).ToArray());
        }

        [TestMethod()]
        public void BubbleTest()
        {
            // arange
            var bubble = new BubbleSort<int>();
            bubble.Items.AddRange(Items);
               
            // act
            bubble.Sort();

            // assert
            for (int i = 0; i < Sorted.Count; i++)
            {
                Assert.AreEqual(Sorted[i], bubble.Items[i]);
            }
        }

        [TestMethod()]
        public void CocKtailSortTest()
        {
            // arange
            var test = new CocKtailSort<int>();
            test.Items.AddRange(Items);

            // act
            test.Sort();

            // assert
            for (int i = 0; i < Sorted.Count; i++)
            {
                Assert.AreEqual(Sorted[i], test.Items[i]);
            }
        }

        [TestMethod()]
        public void InsertSortTest()
        {
            // arange
            var test = new InsertSort<int>();
            test.Items.AddRange(Items);

            // act
            test.Sort();

            // assert
            for (int i = 0; i < Sorted.Count; i++)
            {
                Assert.AreEqual(Sorted[i], test.Items[i]);
            }
        }

        [TestMethod()]
        public void ShellSortTest()
        {
            // arange
            var test = new ShellSort<int>();
            test.Items.AddRange(Items);

            // act
            test.Sort();

            // assert
            for (int i = 0; i < Sorted.Count; i++)
            {
                Assert.AreEqual(Sorted[i], test.Items[i]);
            }
        }

        [TestMethod()]
        public void TreeSortTest()
        {
            // arange
            var test = new TreeSort<int>();
            test.Items.AddRange(Items);

            // act
            test.Sort();

            // assert
            for (int i = 0; i < Sorted.Count; i++)
            {
                Assert.AreEqual(Sorted[i], test.Items[i]);
            }
        }

        [TestMethod()]
        public void HeapSortTest()
        {
            // arange
            var test = new HeapSort<int>();
            test.Items.AddRange(Items);

            // act
            test.Sort();

            // assert
            for (int i = 0; i < Sorted.Count; i++)
            {
                Assert.AreEqual(Sorted[i], test.Items[i]);
            }
        }

        [TestMethod()]
        public void SelectionSort()
        {
            // arange
            var test = new SelectionSort<int>();
            test.Items.AddRange(Items);

            // act
            test.Sort();

            // assert
            for (int i = 0; i < Sorted.Count; i++)
            {
                Assert.AreEqual(Sorted[i], test.Items[i]);
            }
        }
    }
}