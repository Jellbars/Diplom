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
    public partial class Fuel : Form
    {
        public Fuel()
        {
            InitializeComponent();
            Load_data(0);
        }

        public void Fuel_Load(object sender, EventArgs e)
        {

        }

        SqlConnection connection;
        SqlDataReader reader;
        Assay assay = new Assay();

        public void Load_data(int zp)
        {
            dataGridView1.AllowUserToAddRows = true;
            List<string[]> data = new List<string[]>();
            //string connetionString = null;
            string a = null;
            if (zp == 0)
            {
                a = "SELECT [Топливо].[ID_топлива], [Топливо].[Название], [Единицы измерения].[Название], [Топливо].[Цена] FROM [Топливо] join [Единицы измерения] on Топливо.ID_единицы = [Единицы измерения].ID_единицы";
            }
            if (zp == 1)
            {
                a = "SELECT [Топливо].[ID_топлива], [Топливо].[Название], [Единицы измерения].[Название], [Топливо].[Цена] FROM [Топливо] join [Единицы измерения] on Топливо.ID_единицы = [Единицы измерения].ID_единицы Where Топливо." + toolStripComboBox1.Text + " = '" + toolStripTextBox2.Text + "'";
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

        private void поискToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (toolStripComboBox1.Text.Length != 0 & toolStripTextBox2.Text.Length != 0)
                Load_data(1);
            else
                MessageBox.Show("Выберите и заполните оба поля!");
        }

        private void удалитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int str = dataGridView1.CurrentRow.Index;
            Delete_data(str);
            Load_data(0);
        }

        private void Delete_data(int str)
        {
            //string connetionString = null;
            string a = "Delete from [Топливо] Where ID_топлива = '" + dataGridView1[0, str].Value + "'";
            //connetionString = @"Data Source=DESKTOP-RELTBSM\SQLEXPRESS;Initial Catalog=Diplom_ru;Integrated Security=True";
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

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (Znach.zagr_fuel == 1)
            {
                textBox1.Text = Convert.ToString(Convert.ToDouble(dataGridView1[3, dataGridView1.CurrentRow.Index].Value));
            }
        }

        private void редактироватьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Znach.prof = 0;
            assay.Prov(5, textBox1.Text);
            int str = dataGridView1.CurrentRow.Index;
            Update_data(str);
            Load_data(0);
            textBox1.Text = "";
        }

        private void Update_data(int str)
        {
            //string connetionString = null;
            string a = "Update [Топливо] Set Цена = '" + textBox1.Text + "' Where ID_топлива = '" + dataGridView1[0, str].Value + "'";
            //connetionString = @"Data Source=DESKTOP-RELTBSM\SQLEXPRESS;Initial Catalog=Diplom_ru;Integrated Security=True";
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

        private void выходToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Hide();
        }
    }
}
