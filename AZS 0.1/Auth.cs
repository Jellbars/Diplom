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
    public partial class Auth : Form
    {
        public Auth()
        {
            InitializeComponent();
        }

        SqlConnection connection;
        SqlDataReader reader;

        public void Load_data(int zp)
        {
            //dataGridView1.ReadOnly = false;
            dataGridView1.AllowUserToAddRows = true;
            List<string[]> data = new List<string[]>();
            string a = null;
            
            if (zp == 0)
            {
                a = "Select Авторизация.ID_login, Сотрудники.Фамилия, Сотрудники.Имя, Сотрудники.Отчество, Авторизация.Login, Авторизация.Password, Должность.Название, Статус.Название from [Сотрудники] join Авторизация on Сотрудники.ID_сотрудника = Авторизация.ID_сотрудника join Должность on Сотрудники.ID_должности = Должность.ID_должности join Статус on Сотрудники.ID_статуса = Статус.ID_статуса";
            }
            if (zp == 1)
            {
                //a = "Select Авторизация.ID_login , Сотрудники.Фамилия, Сотрудники.Имя, Сотрудники.Отчество, Аторизация.Login, Авторизация.Password, Должность.Название, Статус.Название from[Авторизация] join Сотрудники on Авторизация.ID_сотрудника = Сотрудники.ID_сотрудника join Должность on Сотрудники.ID_должности = Должность.ID_должности join Статус on Сотрудники.ID_статуса = Статус.ID_статуса Where " + toolStripComboBox1.Text + " = '" + toolStripTextBox2.Text + "'";
                //a = "Select * from [] Where " + toolStripComboBox1.Text + " = '" + toolStripTextBox2.Text + "'";
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
                            data.Add(new string[100]);
                            string FIO = null;
                            for (int i = 0; i < 8; i++)
                            {
                                if (i == 0 | i < 3)
                                {
                                    data[data.Count - 1][i] = reader[i].ToString();
                                }
                                if (i != 0 & i < 4)
                                {
                                    if (i == 1)
                                    {
                                        FIO = FIO + reader[i].ToString();
                                    }
                                    else
                                    {
                                        FIO = FIO + " " + reader[i].ToString();
                                    }
                                    if (i == 3)
                                    {
                                        data[data.Count - 1][i - 2] = FIO;
                                    }
                                }
                                if (i > 3)
                                {
                                    data[data.Count - 1][i - 2] = reader[i].ToString();
                                }
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
                    //dataGridView1.ReadOnly = true;
                    dataGridView1.AllowUserToAddRows = false;
                }
        }

        private void обновитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Load_data(0);
        }

        private void Auth_Load(object sender, EventArgs e)
        {
            Load_data(0);
        }

        private void ходToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Hide();
        }
    }
}
