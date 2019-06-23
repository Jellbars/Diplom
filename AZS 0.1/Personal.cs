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
    public partial class Personal : Form
    {
        public Personal()
        {
            InitializeComponent();

            Load_data(0);
        }

        SqlConnection connection;
        SqlDataReader reader;

        private void Personal_del_Load(object sender, EventArgs e)
        {
        /*// TODO: данная строка кода позволяет загрузить данные в таблицу "diplom_ruDataSet.Сотрудники". При необходимости она может быть перемещена или удалена.
        this.сотрудникиTableAdapter.Fill(this.diplom_ruDataSet.Сотрудники);*/
        }

        public void Load_data(int zp)
        {
            List<string[]> data = new List<string[]>();
            string a = null;
            if (zp == 0)
            {
                a = "SELECT [Сотрудники].[ID_сотрудника], [Фамилия] ,[Имя] , [Отчество], [Адрес], [Паспорт], [Email], [Телефон],Должность.Название, Статус.Название FROM [Сотрудники] join Должность on Сотрудники.ID_должности = Должность.ID_должности join Статус on Сотрудники.ID_статуса = Статус.ID_статуса";
            }
            if (zp == 1)
            {
                a = "SELECT [Сотрудники].[ID_сотрудника], [Фамилия] ,[Имя] , [Отчество], [Адрес], [Паспорт], [Email], [Телефон],Должность.Название, Статус.Название FROM [Сотрудники] join Должность on Сотрудники.ID_должности = Должность.ID_должности join Статус on Сотрудники.ID_статуса = Статус.ID_статуса Where " + toolStripComboBox1.Text + " = '" + toolStripTextBox2.Text + "'";
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
                            for (int i = 0; i < 10; i++)
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
            string a = "Delete from [Сотрудники] Where ID_сотрудника = '" + dataGridView1[0, str].Value + "'";
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

        private void поискToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (toolStripComboBox1.Text.Length != 0 & toolStripTextBox2.Text.Length != 0)
                Load_data(1);
            else
                MessageBox.Show("Выберите и заполните оба поля!");
        }

        private void обновитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Load_data(0);
        }

        private void выходToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Hide();
        }
    }
}
