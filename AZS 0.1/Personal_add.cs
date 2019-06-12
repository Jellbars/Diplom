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
    public partial class Personal_add : Form
    {

        SqlConnection connection;
        SqlDataReader reader;
        public int id_st;
        public int id_dol;
        int stop;

        public Personal_add()
        {
            InitializeComponent();
            Load_data(2);
            Load_data(3);
        }

        public void Load_data(int zp)
        {
            
            string a = null;
            if (zp == 0)
            {
                a = "Select ID_статуса from [Статус] Where Название = '" + dataGridView1[8, 0].EditedFormattedValue.ToString() + "'";
            }
            if (zp == 1)
            {
                a = "Select ID_должности from [Должность] Where Название = '" + dataGridView1[7, 0].EditedFormattedValue.ToString() + "'";
            }
            if (zp == 2)
            {
                a = "Select Название from [Статус]";
            }
            if (zp == 3)
            {
                a = "Select Название from [Должность]";
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
                                id_st = Convert.ToInt32(reader[0]);
                            }
                            if (zp == 1)
                            {
                                id_dol = Convert.ToInt32(reader[0]);
                            }
                            if (zp == 2)
                            {
                                Status.Items.Add(reader[0]);
                                
                            }
                            if (zp == 3)
                            {
                                Dolnost.Items.Add(reader[0]);
                            }
                        }
                    }
                    else
                    {
                        if (zp == 0)
                        {
                            MessageBox.Show("Не найдено");
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
                }
        }

        private void добавитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //string del = dataGridView1[8, 0].EditedFormattedValue.ToString();
            for (int i = 0; i < 9; i++)
            {
                if (i < 7)
                {
                    if (dataGridView1[i, 0].Value == null)
                    {
                        MessageBox.Show("Заполните все ячейки");
                        goto Vh;
                    }
                }
                else
                {
                    if (dataGridView1[i, 0].EditedFormattedValue.ToString() == "")
                    {
                        MessageBox.Show("Выберите значения");
                        goto Vh;
                    }
                }
            }
                Load_data(0);
                Load_data(1);
                reg(0);
                int n;
                n = dataGridView1.Rows.Count;
                Hide();
                Show();
        Vh:
            stop = 0;

            //while (dataGridView1.Rows.Count > 1)
                //dataGridView1.Rows.Remove(dataGridView1.Rows[0]);
            
        }

        public void reg(int str)
        {
            string connetionString = null;
            connetionString = @"Data Source=DESKTOP-RELTBSM\SQLEXPRESS;Initial Catalog=Diplom_ru;Integrated Security=True";
            string a = "INSERT INTO [Сотрудники] ([Фамилия],[Имя],[Отчество],[Адрес],[Паспорт],[Email],[Телефон], [ID_должности], [ID_статуса]) VALUES (@LastName, @Name, @PastName, @Adress, @Pasport, @Email, @Teleph, @Dol, @Stat)";
            using (SqlConnection connection = new SqlConnection(connetionString))
                try
                {
                    connection.Open();
                    SqlCommand command = new SqlCommand(a, connection);
                    SqlParameter LastNPar = new SqlParameter("@LastName", dataGridView1[0, str].Value.ToString());
                    SqlParameter NamPar = new SqlParameter("@Name", dataGridView1[1, str].Value.ToString());
                    SqlParameter PastNPar = new SqlParameter("@PastName", dataGridView1[2, str].Value.ToString());
                    SqlParameter AdrPar = new SqlParameter("@Adress", dataGridView1[3, str].Value.ToString());
                    SqlParameter PasPar = new SqlParameter("@Pasport", dataGridView1[4, str].Value.ToString());
                    SqlParameter EmaPar = new SqlParameter("@Email", dataGridView1[5, str].Value.ToString());
                    SqlParameter TelPar = new SqlParameter("@Teleph", dataGridView1[6, str].Value.ToString());
                    SqlParameter DolPar = new SqlParameter("@Dol", id_dol);
                    SqlParameter StatPar = new SqlParameter("@Stat", id_st);
                    command.Parameters.Add(LastNPar);
                    command.Parameters.Add(NamPar);
                    command.Parameters.Add(PastNPar);
                    command.Parameters.Add(AdrPar);
                    command.Parameters.Add(PasPar);
                    command.Parameters.Add(EmaPar);
                    command.Parameters.Add(TelPar);
                    command.Parameters.Add(DolPar);
                    command.Parameters.Add(StatPar);
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
    }

}
