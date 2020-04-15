using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SortAlgoritm
{
    public class SortedItem : IComparable
    {
        public VerticalProgressBar.VerticalProgressBar ProgressBar { get; private set; }
        public Label Label { get; private set; }
        public int Value { get; set; }
        public int Number { get; private set; }

        public SortedItem(int value, int number)
        {
            Value = value;
            Number = number;
            ProgressBar = new VerticalProgressBar.VerticalProgressBar();
            Label = new Label();
            // 
            // verticalProgressBar1
            // 
            ProgressBar.BorderStyle = VerticalProgressBar.BorderStyles.Classic;
            ProgressBar.Color = System.Drawing.Color.Blue;
            ProgressBar.Location = new System.Drawing.Point(Number * 22 + 2, 3);
            
            ProgressBar.Maximum = 100;
            ProgressBar.Minimum = 0;
            ProgressBar.Name = "ProgressBar" + number;
            ProgressBar.Size = new System.Drawing.Size(18, 110);
            ProgressBar.Step = 1;
            ProgressBar.Style = VerticalProgressBar.Styles.Solid;
            ProgressBar.TabIndex = 0;
            ProgressBar.Value = Value;
            // 
            // label3
            // 
            Label.AutoSize = true;
            Label.Location = new System.Drawing.Point(Number * 22 + 2, 113);
            Label.Name = "label3";
            Label.Size = new System.Drawing.Size(19, 13);
            Label.TabIndex = 1;
            Label.Text = Value.ToString();
        }

        public int CompareTo(object obj)
        {
            if(obj is SortedItem item)
            {
                return Value.CompareTo(item.Value);
            }
            else
            {
                throw new ArgumentException($"object is not {nameof(SortedItem)}", nameof(obj));
            }
        }

        public void SetColor(Color color)
        {
            this.ProgressBar.Color = color;
        }

        public void SetPosition(int number)
        {
            Number = number;
            var x = number * 22 + 2;
            ProgressBar.Location = new Point(x, 3);
            ProgressBar.Name = "ProgressBar" + number;
            Label.Location = new Point(x, 113);
            Label.Name = "Label" + number;
        }
    }
}
