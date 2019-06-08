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
    public partial class Check : Form
    {

        SqlConnection connection;
        SqlDataReader reader;
        public int chek_cl;
        public int id_cl;
        public int id_topl;
        public double cum_topl;
        

        public Check()
        {
            InitializeComponent();
        }

        private void Check_Load(object sender, EventArgs e)
        {
            Load_data(0);
            comboBox2.Items.Add("");
            comboBox2.Items.Add("Код_карты");
            comboBox2.Items.Add("Телефон");
        }

        public void Load_data(int zp)
        {
            chek_cl = 0;
            List<string[]> data = new List<string[]>();
            //string connetionString = null;
            string a = null;
            if (zp == 0)
            {
                a = "Select Название from [Топливо]";
            }
            if (zp == 1)
            {
                a = "Select * from [Клиент] Where " + comboBox2.Text + " = '" + textBox2.Text + "'";
            }
            if (zp == 2)
            {
                a = "Select ID_клиента from [Клиент] Where " + comboBox2.Text + " = '" + textBox2.Text + "'";
            }
            if (zp == 3)
            {
                a = "Select ID_топлива, Цена  from [Топливо] Where " + comboBox1.Text + "'";
            }
            //connetionString = @"Data Source=DESKTOP-RELTBSM\SQLEXPRESS;Initial Catalog=Diplom_ru;Integrated Security=True";
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
                                comboBox1.Items.Add(reader[0]);
                                //comboBox1.Items.Insert(Convert.ToInt32((reader[0].ToString())), reader[1].ToString());
                            }
                            if (zp == 1)
                            {
                                textBox2.ForeColor = Color.FromArgb(0, 192, 0);
                            }
                            else
                            {
                                textBox2.ForeColor = Color.Red;
                            }
                            if (zp == 2)
                            {
                                id_cl = Convert.ToInt32(reader[0].ToString());
                            }
                            if (zp == 3)
                            {
                                id_topl = Convert.ToInt32(reader[0].ToString());
                                cum_topl = Convert.ToDouble(reader[1].ToString());
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

                }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (comboBox2.Text.Length != 0 & textBox2.Text.Length != 0)
                Load_data(1);
            else
                MessageBox.Show("Выберите и заполните оба поля!");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Load_data(2);
            Load_data(3);
            add(0);
            Hide();
            Show();
        }

        private void add(int str)
        {
            //string connetionString = null;
            //connetionString = @"Data Source=DESKTOP-RELTBSM\SQLEXPRESS;Initial Catalog=Diplom_ru;Integrated Security=True";
            string a = "INSERT INTO [Чек] (ID_заправки, ID_топлива, [Количество топлива], Сумма, ID_клинета, ID_сотрудника, Дата) VALUES ( @Zapr, @Topl, @Kolvo, @Cum, @Kli, @Sotr, @Date)";
            using (SqlConnection connection = new SqlConnection(Znach.connetionString))
                try
                {
                    connection.Open();
                    SqlCommand command = new SqlCommand(a, connection);
                    SqlParameter Zapr = new SqlParameter("@Zapr", Znach.id_zapr);
                    SqlParameter Topl = new SqlParameter("@Topl", id_topl);
                    SqlParameter Kolvo = new SqlParameter("@Kolvo", textBox2.Text);
                    SqlParameter Cum = new SqlParameter("@Cum", Convert.ToDouble(textBox2.Text) * cum_topl);
                    SqlParameter Kli = new SqlParameter("@Kli", id_cl);
                    SqlParameter Sotr = new SqlParameter("@Sotr", Znach.log);
                    SqlParameter Date = new SqlParameter("@Date", DateTime.Now);
                    command.Parameters.Add(Zapr);
                    command.Parameters.Add(Topl);
                    command.Parameters.Add(Kolvo);
                    command.Parameters.Add(Cum);
                    command.Parameters.Add(Kli);
                    command.Parameters.Add(Sotr);
                    command.Parameters.Add(Date);
                    int number = command.ExecuteNonQuery();
                    Console.WriteLine("Добавлено объектов: {0}", number);
                }
                finally
                {
                    connection.Close();
                    connection.Dispose();
                }
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            if (textBox2.ForeColor != SystemColors.WindowText)
            {
                textBox2.ForeColor = SystemColors.WindowText;
            }
        }
    }
}
