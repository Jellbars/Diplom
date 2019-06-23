using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AZS_0._1
{
    public partial class Client_add : Form
    {
        public Client_add()
        {
            InitializeComponent();
        }

        SqlConnection connection;
        SqlCommand command;
        SqlDataReader reader;
        Assay assay = new Assay();
        string kk;

        private void добавитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Prov();
            if (Znach.prof == 4)
            {
                Load_data();
                add(0);
                Hide();
                Show();
            }
            else
            {
                MessageBox.Show("Неправильный ввод");
            }

        }

        private void add(int str)
        {
            string a = "INSERT INTO [Клиент] ([Имя],[Фамилия],[Email],[Телефон],[Код_карты]) VALUES ( @Name, @LastName, @Email, @Teleph, @Code)";
            using (connection = new SqlConnection(Znach.connetionString))
                try
                {
                    connection.Open();
                    command = new SqlCommand(a, connection);
                    SqlParameter LastNPar = new SqlParameter("@LastName", dataGridView1[1, str].Value.ToString());
                    SqlParameter NamPar = new SqlParameter("@Name", dataGridView1[0, str].Value.ToString());
                    SqlParameter EmaPar = new SqlParameter("@Email", dataGridView1[2, str].Value.ToString());
                    SqlParameter TelPar = new SqlParameter("@Teleph", dataGridView1[3, str].Value.ToString());
                    SqlParameter CodePar = new SqlParameter("@Code", Convert.ToInt32(kk) + 1);
                    command.Parameters.Add(NamPar);
                    command.Parameters.Add(LastNPar);
                    command.Parameters.Add(EmaPar);
                    command.Parameters.Add(TelPar);
                    command.Parameters.Add(CodePar);
                    int number = command.ExecuteNonQuery();
                    Console.WriteLine("Добавлено объектов: {0}", number);
                }
                finally
                {
                    connection.Close();
                    connection.Dispose();
                }
        }

        private void Client_add_Load(object sender, EventArgs e)
        {
            // TODO: данная строка кода позволяет загрузить данные в таблицу "diplom_ruDataSet.Клиент". При необходимости она может быть перемещена или удалена.
            //this.клиентTableAdapter.Fill(this.diplom_ruDataSet.Клиент);

        }

        private void выходToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Hide();
        }

        public void Prov()
        {
            Znach.prof = 0;
            for (int i = 0; i < 4; i++)
            {
                if (dataGridView1[i, 0].Value == null)
                {
                    goto Vh_p;
                }
            }
            assay.Prov(1, dataGridView1[0, 0].Value.ToString());
            assay.Prov(1, dataGridView1[1, 0].Value.ToString());
            assay.Prov(2, dataGridView1[2, 0].Value.ToString());
            assay.Prov(3, dataGridView1[3, 0].Value.ToString());
        Vh_p:
            int har;
        }


        public void Load_data()
        {
            string a = null;
                a = "select max(Код_карты) from Клиент";
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
                            kk = reader[0].ToString();
                        }
                    }
                    else
                    {
                        MessageBox.Show("Ошибка...");
                    }
                }
                finally
                {
                    reader.Close();
                    connection.Close();
                    connection.Dispose();
                }
        }
    }
}
