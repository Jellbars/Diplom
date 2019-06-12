using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AZS_0._1
{
    public partial class Supplier : Form
    {
        SqlConnection connection;
        SqlDataReader reader;

        public Supplier()
        {
            InitializeComponent();
            Load_data(0);
        }

        public void Load_data(int zp)
        {
            List<string[]> data = new List<string[]>();
            string connetionString = null;
            string a = null;
            if (zp == 0)
            {
                a = "Select * from [Поставщик]";
            }
            if (zp == 1)
            {
                a = "Select * from [Поставщик] Where " + toolStripComboBox1.Text + " = '" + toolStripTextBox2.Text + "'";
            }
            connetionString = @"Data Source=DESKTOP-RELTBSM\SQLEXPRESS;Initial Catalog=Diplom_ru;Integrated Security=True";
            using (connection = new SqlConnection(connetionString))
                try
                {
                    connection.Open();
                    SqlCommand command = new SqlCommand(a, connection);
                    reader = command.ExecuteReader();
                    if (reader.HasRows) // если есть данные
                    {
                        dataGridView1.Rows.Clear();
                        while (reader.Read()) // построчно считываем данные
                        {
                            data.Add(new string[8]);
                            for (int i = 0; i < 5; i++)
                            {
                                data[data.Count - 1][i] = reader[i].ToString();
                            }
                        }
                    }
                    else
                    {
                        if (zp == 0)
                        {
                            MessageBox.Show("Ошибка...");
                        }
                        if (zp == 1)
                        {
                            MessageBox.Show("Не найдено");
                        }
                    }
                }
                finally
                {
                    reader.Close();
                    connection.Close();
                    connection.Dispose();
                    foreach (string[] s in data)
                        dataGridView1.Rows.Add(s);
                }
        }

        private void обновитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Load_data(0);
        }

        private void удалитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int str = dataGridView1.CurrentRow.Index;
            Delete_data(str);
            Load_data(0);
        }

        private void Delete_data(int str)
        {
            string a = "Delete from [Поставщик] Where ID_клиента = '" + dataGridView1[0, str].Value + "'";
            using (connection = new SqlConnection(Znach.connetionString))
                try
                {
                    connection.Open();
                    SqlCommand command = new SqlCommand(a, connection);
                    command.ExecuteNonQuery();
                }
                finally
                {
                    connection.Close();
                    connection.Dispose();
                }
        }

        private void редактироватьToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void поискToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (toolStripComboBox1.Text.Length != 0 & toolStripTextBox2.Text.Length != 0)
                Load_data(1);
            else
                MessageBox.Show("Выберите и заполните оба поля!");
        }

        private void выходToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Hide();
        }
    }
}
