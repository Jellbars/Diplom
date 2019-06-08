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
    public partial class Client_add : Form
    {
        public Client_add()
        {
            InitializeComponent();
        }

        private void добавитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            add(0);
            Hide();
            Show();

        }

        private void add(int str)
        {
            string connetionString = null;
            connetionString = @"Data Source=DESKTOP-RELTBSM\SQLEXPRESS;Initial Catalog=Diplom_ru;Integrated Security=True";
            string a = "INSERT INTO [Клиент] ([Имя],[Фамилия],[Email],[Телефон],[Код_карты]) VALUES ( @Name, @LastName, @Email, @Teleph, @Code)";
            using (SqlConnection connection = new SqlConnection(connetionString))
                try
                {
                    connection.Open();
                    SqlCommand command = new SqlCommand(a, connection);
                    SqlParameter LastNPar = new SqlParameter("@LastName", dataGridView1[1, str].Value.ToString());
                    SqlParameter NamPar = new SqlParameter("@Name", dataGridView1[0, str].Value.ToString());
                    SqlParameter EmaPar = new SqlParameter("@Email", dataGridView1[2, str].Value.ToString());
                    SqlParameter TelPar = new SqlParameter("@Teleph", dataGridView1[3, str].Value.ToString());
                    SqlParameter CodePar = new SqlParameter("@Code", dataGridView1[4, str].Value.ToString());
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
    }
}
