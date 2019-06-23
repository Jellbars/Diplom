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
    public partial class Login : Form
    {

        SqlDataReader reader;
        SqlConnection connection;
        Open open = new Open();
        int chek;
        AZS azs = (AZS) Application.OpenForms["AZS"];

        public Login()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "")
            {
                MessageBox.Show("Введите логин");
                goto Vh;
            }
            if (textBox2.Text == "")
            {
                MessageBox.Show("Введите пароль");
                goto Vh;
            }
            SqL("SELECT * FROM [Авторизация] Where [Авторизация].[Login] = '" + textBox1.Text + "' and [Авторизация].[Password] = '" + textBox2.Text + "'");

        Vh:
            int j = 1;
        }

        public void SqL(string a)
        {
            chek = 0;
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
                            Znach.log = reader[3].ToString();
                            chek = 1;
                        }
                        Hide();
                }
                else
                {
                        textBox2.Text = "";
                        MessageBox.Show("Неверно введен пароль");
                }
            }
            finally
            {
                reader.Close();
                connection.Close();
                connection.Dispose();
                    if (chek == 1)
                    {
                        SqL_d("SELECT ID_должности, Имя From Сотрудники Where ID_сотрудника = '" + Znach.log + "'");
                    }
             }
        }

        public void SqL_d(string a)
        {
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
                            Znach.log_d = reader[0].ToString();
                            Znach.name = reader[1].ToString();
                            //object ID_log = reader.GetValue(3);
                            //Console.WriteLine("{0}", Znach.log);
                        }
                    }
                }
                finally
                {
                    reader.Close();
                    connection.Close();
                    connection.Dispose();
                    azs.Parametr();
                }
        }

        private void входToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "")
            {
                MessageBox.Show("Введите логин");
                goto Vh;
            }
            if (textBox2.Text == "")
            {
                MessageBox.Show("Введите пароль");
                goto Vh;
            }
            SqL("SELECT * FROM [Авторизация] Where [Авторизация].[Login] = '" + textBox1.Text + "' and [Авторизация].[Password] = '" + textBox2.Text + "'");

        Vh:
            int j = 1;
        }

        private void выходToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Hide();
        }
    }
}
