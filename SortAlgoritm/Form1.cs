using Algorithms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SortAlgoritm
{
    public partial class Form1 : Form
    {
        List<SortedItem> items = new List<SortedItem>();

        public Form1()
        {
            InitializeComponent();
        }

        private void AddButton_Click(object sender, EventArgs e)
        {
            if (int.TryParse(AddTextBox.Text, out int value))
            {
                var item = new SortedItem(value, items.Count);
                
                items.Add(item);
                this.panel3.Controls.Add(item.ProgressBar);
                this.panel3.Controls.Add(item.Label);
            }
            AddTextBox.Clear();
        }

        private void FillButton_Click(object sender, EventArgs e)
        {
            if (int.TryParse(FillTextBox.Text, out int value))
            {
                var rnd = new Random();
                for (int i = 0; i < value; i++)
                {
                    var item = new SortedItem(rnd.Next(0, 100), items.Count);
                    items.Add(item);
                    this.panel3.Controls.Add(item.ProgressBar);
                    this.panel3.Controls.Add(item.Label);
                }
            }
            AddTextBox.Clear();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var listForSort = new BubbleSort<SortedItem>(items);
            listForSort.CompareEvent += ListForSort_CompareEvent;
            listForSort.SwopEvent += ListForSort_SwopEvent;
            listForSort.Sort();
            DisplayList(listForSort.Items);
        }

        private void ListForSort_SwopEvent(object sender, Tuple<SortedItem, SortedItem> e)
        {
            var temp = e.Item1.Value;
            e.Item1.SetValue(e.Item2.Value);
            e.Item2.SetValue(temp);

            Refresh();
            
            Thread.Sleep(500);
            e.Item1.SetColor(Color.Blue);
            e.Item2.SetColor(Color.Blue);
        }

        private void ListForSort_CompareEvent(object sender, Tuple<SortedItem, SortedItem> e)
        {
            e.Item1.SetColor(Color.Red);
            e.Item2.SetColor(Color.Green);
            Refresh();
            Thread.Sleep(500);
            e.Item1.SetColor(Color.Blue);
            e.Item2.SetColor(Color.Blue);
        }

        public void Swop(AlgorithmBase<int> listForSort, int indA, int indB)
        {

            var temp = listForSort.Items[indA];

            listForSort.Items[indA] = listForSort.Items[indB];

            listForSort.Items[indB] = temp;
        }

        public void DisplayList(List<SortedItem> list)
        {
            
            for(int i = 0; i < list.Count; i++)
            {
                var item = new SortedItem(list[i].Value, i);
                this.panel4.Controls.Add(item.ProgressBar);
                this.panel4.Controls.Add(item.Label);
            }
        }
    }
}
