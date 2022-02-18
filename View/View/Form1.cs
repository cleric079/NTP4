using System;
using System.ComponentModel;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Windows.Forms;
using Model;

namespace View
{
    public partial class TransportForm : Form
    {
        public BindingList<Transport> lst;

        public TransportForm()
        {
            InitializeComponent();
            lst = new BindingList<Transport>();
            dgv.DataSource = lst;
            dgv.Columns[0].HeaderText = "Путь";
            dgv.Columns[1].HeaderText = "Расход";
            dgv.Columns[2].HeaderText = "Потрачено топлива";
        }

        //добавление нового объекта
        private void button1_Click(object sender, EventArgs e)
        {
            AddForm f = new AddForm(lst);
            f.ShowDialog();
        }

        //удаление объекта
        private void button2_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in dgv.SelectedRows)
            {
                dgv.Rows.RemoveAt(row.Index);
            }
        }

        //поиск объектов
        private void button3_Click(object sender, EventArgs e)
        {
            FindForm f = new FindForm(lst);
            f.ShowDialog();
        }

        //выход из приложения
        private void button4_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        //сериализация и сохранение всех объектов в бинарный файл
        private void button6_Click(object sender, EventArgs e)
        {
            Stream myStream;
            SaveFileDialog saveFileDialog1 = new SaveFileDialog();
            BinaryFormatter formatter = new BinaryFormatter();

            saveFileDialog1.Filter = "txt files(*.txt)| *.txt | All files(*.*) | *.*";
            saveFileDialog1.FilterIndex = 2;
            saveFileDialog1.RestoreDirectory = true;

            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                if ((myStream = saveFileDialog1.OpenFile()) != null)
                {
                    formatter.Serialize(myStream, lst);
                    MessageBox.Show("Данные были успешно cохранены в файл " +
                        Path.GetFileName(saveFileDialog1.FileName));
                    myStream.Close();
                }
            }
        }

        //загрузка и десериализация всех данных из бинарного файла
        private void button5_Click(object sender, EventArgs e)
        {
            BinaryFormatter formatter = new BinaryFormatter();

            var fileContent = string.Empty;
            var filePath = string.Empty;

            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.InitialDirectory = "С:\\";
                openFileDialog.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";
                openFileDialog.FilterIndex = 2;
                openFileDialog.RestoreDirectory = true;

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    filePath = openFileDialog.FileName;
                    var fileStream = openFileDialog.OpenFile();
                    lst = (BindingList<Transport>)formatter.Deserialize(fileStream);
                    MessageBox.Show("Данные были успешно загружены из файла " +
                        Path.GetFileName(filePath));
                }
            }
            dgv.DataSource = lst;
        }
    }
}