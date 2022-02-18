using System;
using System.ComponentModel;
using System.Windows.Forms;
using Model;

namespace View
{
    public partial class AddForm : Form
    {

        BindingList<Transport> lst;

        public AddForm(BindingList<Transport> lst)
        {
            InitializeComponent();
            this.lst = lst;
        }

        //добавили объект
        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                double s, q;
                bool result = double.TryParse(textBox1.Text.Replace(".", ","), out s);
                if (!result || s < 0)
                {
                    throw new Exception("Вы ввели некорректное значение для первого поля");
                }
                else
                {
                    result = double.TryParse(textBox2.Text.Replace(".", ","), out q);
                    if (!result || q < 0)
                    {
                        throw new Exception("Вы ввели некорректное значение для второго поля");
                    }
                    else
                    {
                        if (radioButton1.Checked)
                        {
                            lst.Add(new Car(s, q));
                        }
                        else if (radioButton2.Checked)
                        {
                            lst.Add(new Helicopter(s, q));
                        }
                        else
                        {
                            lst.Add(new Hybrid(s, q));
                        }
                        Close();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        //выход из формы
        private void button4_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}