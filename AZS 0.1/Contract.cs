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
    public partial class Contract : Form
    {
        public Contract()
        {
            InitializeComponent();

            //Load_data(0);
        }

        SqlConnection connection;
        SqlDataReader reader;

        private void обновитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Load_data(0);
        }

        public void Load_data(int zp)
        {
            List<string[]> data = new List<string[]>();
            string connetionString = null;
            string a = null;
            if (zp == 0)
            {
                a = "Select [Договор].ID_договора, Сотрудники.Фамилия, Поставщик.Название, Топливо.Название, [Договор].[Количество топлива], [Цена за единицу], [Дата поставки], Сумма, [Дата заключения] From Договор join Сотрудники on Договор.ID_сотрудника = Сотрудники.ID_сотрудника join Поставщик on Договор.ID_поставщика = Поставщик.ID_поставщика join Топливо on Договор.ID_топлива = Топливо.ID_топлива";
            }
            if (zp == 1)
            {
                a = "Select * from [Договор] Where [" + toolStripComboBox1.Text + "] = '" + toolStripTextBox2.Text + "'";
            }
            using (connection = new SqlConnection(Znach.connetionString))
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
                            data.Add(new string[10]);
                            for (int i = 0; i < 8; i++)
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

        private void удалитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int str = dataGridView1.CurrentRow.Index;
            Delete_data(str);
            Load_data(0);
        }

        private void Delete_data(int str)
        {
            string connetionString = null;
            string a = "Delete from [Договор] Where ID_договора = '" + dataGridView1[0, str].Value + "'";
            connetionString = @"Data Source=DESKTOP-RELTBSM\SQLEXPRESS;Initial Catalog=Diplom_ru;Integrated Security=True";
            using (connection = new SqlConnection(connetionString))
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
