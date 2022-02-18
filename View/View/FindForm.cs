using Model;
using System;
using System.ComponentModel;
using System.Windows.Forms;

namespace View
{
    public partial class FindForm : Form
    {
        BindingList<Transport> lst;

        public FindForm(BindingList<Transport> lst)
        {
            InitializeComponent();
            this.lst = lst;
        }

        //выход из поиска
        private void button4_Click(object sender, System.EventArgs e)
        {
            Close();
        }

        //поиск по пройденному пути
        private void button1_Click(object sender, System.EventArgs e)
        {
            listBox1.Items.Clear();
            try
            {
                double s = double.Parse(textBox1.Text.Replace(".", ","));
                for (int i = 0; i < lst.Count; i++)
                {
                    if (Math.Abs(lst[i].S - s) <= 0.001)
                    {
                        listBox1.Items.Add(lst[i].getInfo());
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        //поиск по расходу топлива
        private void button2_Click(object sender, System.EventArgs e)
        {
            listBox1.Items.Clear();
            try
            {
                double q = double.Parse(textBox2.Text.Replace(".", ","));
                for (int i = 0; i < lst.Count; i++)
                {
                    if (Math.Abs(lst[i].Q - q) <= 0.001)
                    {
                        listBox1.Items.Add(lst[i].getInfo());
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        //поиск по всем полям
        private void button3_Click(object sender, System.EventArgs e)
        {
            listBox1.Items.Clear();
            try
            {
                double s = double.Parse(textBox1.Text.Replace(".", ","));
                double q = double.Parse(textBox2.Text.Replace(".", ","));
                for (int i = 0; i < lst.Count; i++)
                {
                    if (Math.Abs(lst[i].S - s) <= 0.001 && Math.Abs(lst[i].Q - q) <= 0.001)
                    {
                        listBox1.Items.Add(lst[i].getInfo());
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}