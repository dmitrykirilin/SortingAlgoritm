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
            panel3.Controls.Clear();
            items = new List<SortedItem>();
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
            FillTextBox.Clear();
        }

       
        //Обработка события сравнения значений
        private void ListForSort_CompareEvent(object sender, Tuple<SortedItem, SortedItem> e)
        {
            e.Item1.SetColor(Color.Red);
            e.Item2.SetColor(Color.Red);
            if (sender is AlgorithmBase<SortedItem> obj)
            {
                ComparisonLabel.Text = "Количество сравнений: " + obj.ComparisonCount;
            }
            panel4.Refresh();

            Thread.Sleep(60);

            e.Item1.SetColor(Color.Blue);
            e.Item2.SetColor(Color.Blue);
            panel4.Refresh();
        }

        // Обработка события перемены значений местами
        private void ListForSort_SwopEventAsync(object sender, Tuple<SortedItem, SortedItem> e)
        {
            var temp = e.Item1.Number;
            e.Item1.SetPosition(e.Item2.Number);
            e.Item2.SetPosition(temp);
            e.Item1.SetColor(Color.Red);
            e.Item2.SetColor(Color.Red);
            if (sender is AlgorithmBase<SortedItem> obj)
            {
                SwopLabel.Text = "Количество обменов: " + obj.SwopCount;
            }
            panel4.Refresh();

            //Thread.Sleep(30);
            e.Item1.SetColor(Color.Blue);
            e.Item2.SetColor(Color.Blue);
            panel4.Refresh();
        }
        

        // кнопки запуска сортировки

        private void CocktailSort_Click(object sender, EventArgs e)
        {
            panel4.Controls.Clear();
            var listForSort = new CocKtailSort<SortedItem>(items);
            var NewItems = DisplayList(listForSort.Items);
            listForSort = new CocKtailSort<SortedItem>(NewItems);
            StartSorting(listForSort);
        }

        private void BubbleSort_Click(object sender, EventArgs e)
        {
            panel4.Controls.Clear();
            var listForSort = new BubbleSort<SortedItem>(items);
            var NewItems = DisplayList(listForSort.Items);
            listForSort = new BubbleSort<SortedItem>(NewItems);
            StartSorting(listForSort);
        }

        private void InsertSort_Click(object sender, EventArgs e)
        {
            panel4.Controls.Clear();
            var listForSort = new InsertSort<SortedItem>(items);
            var NewItems = DisplayList(listForSort.Items);
            listForSort = new InsertSort<SortedItem>(NewItems);
            StartSorting(listForSort);
        }

        private void ShellSort_Click(object sender, EventArgs e)
        {
            panel4.Controls.Clear();
            
            var listForSort = new ShellSort<SortedItem>(items);
            var NewItems = DisplayList(listForSort.Items);
            listForSort = new ShellSort<SortedItem>(NewItems);
            StartSorting(listForSort);
        }

        private void SelectionSort_Click(object sender, EventArgs e)
        {
            panel4.Controls.Clear();
            var listForSort = new SelectionSort<SortedItem>(items);
            var NewItems = DisplayList(listForSort.Items);
            listForSort = new SelectionSort<SortedItem>(NewItems);
            StartSorting(listForSort);
        }

        private void HeapSort_Click(object sender, EventArgs e)
        {
            panel4.Controls.Clear();
            var listForSort = new HeapSort<SortedItem>(items);
            var NewItems = DisplayList(listForSort.Items);
            listForSort = new HeapSort<SortedItem>(NewItems);
            StartSorting(listForSort);
        }

        public void StartSorting(AlgorithmBase<SortedItem> listForSort)
        {
            panel4.Controls.Add(ComparisonLabel);
            panel4.Controls.Add(SwopLabel);
            TimeLabel.Text = "Время: ";
            panel4.Controls.Add(TimeLabel);

            listForSort.CompareEvent += ListForSort_CompareEvent;
            listForSort.SwopEvent += ListForSort_SwopEventAsync;
            panel4.Refresh();

            var time = listForSort.Sort();
            TimeLabel.Text += $"{time.Seconds}";
            //SwopLabel.Text += listForSort.SwopCount;
            //ComparisonLabel.Text += listForSort.ComparisonCount;
        }

        public List<SortedItem> DisplayList(List<SortedItem> list)
        {
            List<SortedItem> NewList = new List<SortedItem>();
            for (int i = 0; i < list.Count; i++)
            {
                var item = new SortedItem(list[i].Value, i);
                this.panel4.Controls.Add(item.ProgressBar);
                this.panel4.Controls.Add(item.Label);
                NewList.Add(item);
            }
            return NewList;
        }

        
    }
}
