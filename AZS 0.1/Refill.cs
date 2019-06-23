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
    public partial class Refill : Form
    {
        public Refill()
        {
            InitializeComponent();
            Load_data(0);
        }

        SqlConnection connection;
        SqlDataReader reader;
        AZS azs = (AZS)Application.OpenForms["AZS"];

        private void входToolStripMenuItem_Click(object sender, EventArgs e)
        {
            azs.toolStripStatusLabel2.Text = dataGridView1[0, dataGridView1.CurrentRow.Index].Value.ToString();
            Hide();
        }

        private void выходToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Hide();
        }

        private void Refill_Load(object sender, EventArgs e)
        {

        }

        public void Load_data(int zp)
        {
            dataGridView1.AllowUserToAddRows = true;
            List<string[]> data = new List<string[]>();
            //string connetionString = null;
            string a = null;
            if (zp == 0)
            {
                a = "SELECT * FROM [Заправка]";
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
                        dataGridView1.Rows.Clear();
                        while (reader.Read()) // построчно считываем данные
                        {
                            data.Add(new string[10]);
                            for (int i = 0; i < 4; i++)
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
                    dataGridView1.AllowUserToAddRows = false;
                }
        }

        private void обновитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Load_data(0);
        }
    }
}
