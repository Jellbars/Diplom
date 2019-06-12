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
    public partial class Contract_add : Form
    {

        SqlConnection connection;
        SqlDataReader reader;
        public int id_post;
        public int id_sotr;
        public int id_topl;
        public string[] strsotr = null;

        public Contract_add()
        {
            InitializeComponent();
            Load_data(3);
            Load_data(4);
            Load_data(5);
        }

        public void Load_data(int zp)
        {

            string a = null;
            if (zp == 0)
            {
                a = "Select ID_поставщика from [Поставщик] Where Название = '" + dataGridView1[1, 0].EditedFormattedValue.ToString() + "'";
            }
            if (zp == 1)
            {
                a = "Select ID_сотрудника from [Сотрудники] Where Фамилия = '" + strsotr[0] + "' and Имя = '" + strsotr[1] + "' and Отчество = '" + strsotr[2] + "'";
            }
            if (zp == 2)
            {
                a = "Select ID_топлива from [Топливо] Where Название = '" + dataGridView1[2, 0].EditedFormattedValue.ToString() + "'";
            }
            if (zp == 3)
            {
                a = "Select Название from [Поставщик]";
            }
            if (zp == 4)
            {
                a = "Select Фамилия, Имя, Отчество from [Сотрудники] Where ID_должности = 2";
            }
            if (zp == 5)
            {
                a = "Select Название from [Топливо]";
            }
            using (connection = new SqlConnection(Znach.connetionString))
                try
                {
                    connection.Open();
                    SqlCommand command = new SqlCommand(a, connection);
                    reader = command.ExecuteReader();
                    if (reader.HasRows) // если есть данные
                    {
                        while (reader.Read()) // построчно считываем данные
                        {
                            if (zp == 0)
                            {
                                id_post = Convert.ToInt32(reader[0]);
                            }
                            if (zp == 1)
                            {
                                id_sotr = Convert.ToInt32(reader[0]);
                            }
                            if (zp == 2)
                            {
                                id_topl = Convert.ToInt32(reader[0]);
                            }
                            if (zp == 3)
                            {
                                Поставщик.Items.Add(reader[0]);
                            }
                            if (zp == 4)
                            {
                                Сотрудник.Items.Add(reader[0] + " " + reader[1] + " " + reader[2]);
                            }
                            if (zp == 5)
                            {
                                Топливо.Items.Add(reader[0]);
                            }
                        }
                    }
                    else
                    {
                        if (zp == 0)
                        {
                            MessageBox.Show("Не найдено");
                        }
                        else
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
                }
        }

        private void обновитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < 8; i++)
            {
                if (i > 2 & i < 5)
                {
                    if (dataGridView1[i, 0].Value == null)
                    {
                        MessageBox.Show("Заполните все ячейки");
                        goto Vh;
                    }
                }
                else
                {
                    if (dataGridView1[i, 0].EditedFormattedValue.ToString() == "" & i != 6)
                    {
                        MessageBox.Show("Выберите значения");
                        goto Vh;
                    }
                }
            }
            char[] splitchar = { ' ' };
            strsotr = dataGridView1[0, 0].EditedFormattedValue.ToString().Split(splitchar);
            Load_data(0);
            Load_data(1);
            Load_data(2);
            add(0);
            Hide();
            Show();
        Vh:
            int stop;
        }

        private void add(int str)
        {
            string a = "INSERT INTO [Договор] ([ID_сотрудника], [ID_поставщика], [ID_топлива], [Количество топлива], [Цена за единицу], [Дата поставки], [Дата заключения]) VALUES ( @Sotr, @Post, @Topl, @Kolvo, @Zen, @Datep, @Datez)";
            using (SqlConnection connection = new SqlConnection(Znach.connetionString))
                try
                {
                    connection.Open();
                    SqlCommand command = new SqlCommand(a, connection);
                    SqlParameter Sotr = new SqlParameter("@Sotr", id_sotr);
                    SqlParameter Post = new SqlParameter("@Post", id_post);
                    SqlParameter Topl = new SqlParameter("@Topl", id_topl);
                    SqlParameter Kolvo = new SqlParameter("@Kolvo", dataGridView1[3, str].Value.ToString());
                    SqlParameter Zen = new SqlParameter("@Zen", dataGridView1[4, str].Value.ToString());
                    SqlParameter Datep = new SqlParameter("@Datep", dataGridView1[5, str].EditedFormattedValue.ToString());
                    SqlParameter Datez = new SqlParameter("@Datep", dataGridView1[7, str].EditedFormattedValue.ToString());
                    command.Parameters.Add(Sotr);
                    command.Parameters.Add(Post);
                    command.Parameters.Add(Topl);
                    command.Parameters.Add(Kolvo);
                    command.Parameters.Add(Zen);
                    command.Parameters.Add(Datep);
                    command.Parameters.Add(Datez);
                    int number = command.ExecuteNonQuery();
                    Console.WriteLine("Добавлено объектов: {0}", number);
                }
                finally
                {
                    connection.Close();
                    connection.Dispose();
                }
        }

        private void выходToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Hide();
        }

        private void Contract_add_Load(object sender, EventArgs e)
        {

        }
    }
}
