using Algorithms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SortAlgoritm
{
    public partial class Form1 : Form
    {
        List<SortedItem> items = new List<SortedItem>();
        AlgorithmBase<int> listForSort = new InsertSort<int>();

        public Form1()
        {
            InitializeComponent();
        }

        private void AddButton_Click(object sender, EventArgs e)
        {
            if (int.TryParse(AddTextBox.Text, out int value))
            {
                var item = new SortedItem(value);
                item.ProgressBar.Location = new System.Drawing.Point(items.Count * 25 + 2, 3);
                item.Label.Location = new System.Drawing.Point(items.Count * 25 + 2, 113);
                items.Add(item);
                this.panel3.Controls.Add(item.ProgressBar);
                this.panel3.Controls.Add(item.Label);

                listForSort.Items.Add(value);
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
                    var item = new SortedItem(rnd.Next(0, 100));
                    item.ProgressBar.Location = new System.Drawing.Point(i * 25 + 2, 3);
                    item.Label.Location = new System.Drawing.Point(i * 25 + 2, 113);
                    items.Add(item);
                    this.panel3.Controls.Add(item.ProgressBar);
                    this.panel3.Controls.Add(item.Label);

                    listForSort.Items.Add(item.Value);
                }
            }
            AddTextBox.Clear();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (listForSort.Items.Count > 1)
            {
                listForSort.Sort();
                for (int i = 0; i < listForSort.Items.Count; i++)
                {
                    var item = new SortedItem(listForSort.Items[i]);
                    item.ProgressBar.Location = new System.Drawing.Point(i * 25 + 2, 3);
                    item.Label.Location = new System.Drawing.Point(i * 25 + 2, 113);
                    this.panel4.Controls.Add(item.ProgressBar);
                    this.panel4.Controls.Add(item.Label);
                }
            }
        }
    }
}
