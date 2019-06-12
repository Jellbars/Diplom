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
    public partial class Auth_add : Form
    {
        public Auth_add()
        {
            InitializeComponent();

        }

        SqlConnection connection;
        SqlDataReader reader;
        List<string[]> data;

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void Auth_add_Load(object sender, EventArgs e)
        {
            Load_data(0);

        }

        public void Load_data(int zp)
        {
            //dataGridView1.ReadOnly = false;
            dataGridView1.AllowUserToAddRows = true;
            data = new List<string[]>();
            string a = null;

            if (zp == 0)
            {
                a = "SELECT ID_сотрудника, Имя, Фамилия, Отчество, Статус.Название, Должность.Название  FROM Сотрудники join Должность on Сотрудники.ID_должности = Должность.ID_должности join Статус on Сотрудники.ID_статуса = Статус.ID_статуса WHERE Сотрудники.ID_сотрудника NOT IN(( SELECT Авторизация.ID_сотрудника FROM Авторизация)) and Сотрудники.ID_статуса <> 5";
            }
            if (zp == 1)
            {
                //a = "Select Авторизация.ID_login , Сотрудники.Фамилия, Сотрудники.Имя, Сотрудники.Отчество, Аторизация.Login, Авторизация.Password, Должность.Название, Статус.Название from[Авторизация] join Сотрудники on Авторизация.ID_сотрудника = Сотрудники.ID_сотрудника join Должность on Сотрудники.ID_должности = Должность.ID_должности join Статус on Сотрудники.ID_статуса = Статус.ID_статуса Where " + toolStripComboBox1.Text + " = '" + toolStripTextBox2.Text + "'";
                //a = "Select  from [] Where " + dataGridView1[0, 0].Value.ToString() + "'";
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
                            for (int i = 0; i < 6; i++)
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

        private void ходToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Hide();
        }

        private void редактироватьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedCells.Count.ToString() != "null")
            {
                if (dataGridView2[0, 0].Value.ToString().Length > 5 & dataGridView2[1, 0].Value.ToString().Length > 5)
                {
                    string a = dataGridView1[0, Convert.ToInt32(dataGridView1.SelectedCells.Count.ToString()) - 1].Value.ToString();
                    add(0, a);
                    Hide();
                    Show();
                }
                else
                {
                    MessageBox.Show("Не оба поля заполенны, наименьшая длина 5 символов");
                }
            }

        }

        private void add(int str, string id)
        {
            string connetionString = null;
            //connetionString = @"Data Source=DESKTOP-RELTBSM\SQLEXPRESS;Initial Catalog=Diplom_ru;Integrated Security=True";
            string a = "INSERT INTO [Авторизация] ([Login],[Password],[ID_сотрудника]) VALUES ( @Login, @Passw, @ID)";
            using (SqlConnection connection = new SqlConnection(Znach.connetionString))
                try
                {
                    connection.Open();
                    SqlCommand command = new SqlCommand(a, connection);
                    SqlParameter Login = new SqlParameter("@Login", dataGridView2[0, str].Value.ToString());
                    SqlParameter Passw = new SqlParameter("@Passw", dataGridView2[1, str].Value.ToString());
                    SqlParameter ID = new SqlParameter("ID", id);
                    command.Parameters.Add(Login);
                    command.Parameters.Add(Passw);
                    command.Parameters.Add(ID);
                    int number = command.ExecuteNonQuery();
                    Console.WriteLine("Добавлено объектов: {0}", number);
                }
                finally
                {
                    connection.Close();
                    connection.Dispose();
                }
        }
    }
}
