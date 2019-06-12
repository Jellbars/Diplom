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
    public partial class THH_add : Form
    {
        SqlConnection connection;
        SqlDataReader reader;
        public int id_post;
        public int id_zapr;
        public int id_topl;

        public THH_add()
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
                a = "Select ID_поставщика from [Поставщик] Where Название = '" + dataGridView1[0, 0].EditedFormattedValue.ToString() + "'";
            }
            if (zp == 1)
            {
                a = "Select ID_запраки from [Заправка] Where Название = '" + dataGridView1[1, 0].EditedFormattedValue.ToString() + "'";
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
                a = "Select Адрес from [Заправка]";
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
                                id_zapr = Convert.ToInt32(reader[0]);
                            }
                            if (zp == 2)
                            {
                                id_topl = Convert.ToInt32(reader[0]);
                            }
                            if (zp == 3)
                            {
                                Поставщик_тнн.Items.Add(reader[0]);
                            }
                            if (zp == 4)
                            {
                                Заправка_тнн.Items.Add(reader[0]);
                            }
                            if (zp == 5)
                            {
                                Топливо_тнн.Items.Add(reader[0]);
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

        private void THH_add_Load(object sender, EventArgs e)
        {
            // TODO: данная строка кода позволяет загрузить данные в таблицу "diplom_ruDataSet._Товарно_транспортная_накладная". При необходимости она может быть перемещена или удалена.
            //this.товарно_транспортная_накладнаяTableAdapter.Fill(this.diplom_ruDataSet._Товарно_транспортная_накладная);

        }

        private void add(int str)
        {
            string a = "INSERT INTO [Товарно-транспортная накладная] ([ID_поставщика],[ID_заправки],[ID_топлива],[Количество топлива],[Цена за единицу], [Дата получения]) VALUES ( @Post, @Zapr, @Topl, @Kolvo, @Zen, @Date)";
            using (SqlConnection connection = new SqlConnection(Znach.connetionString))
                try
                {
                    connection.Open();
                    SqlCommand command = new SqlCommand(a, connection);
                    SqlParameter Post  = new SqlParameter("@Post", id_post);
                    SqlParameter Zapr = new SqlParameter("@Zapr", id_zapr);
                    SqlParameter Topl = new SqlParameter("@Topl", id_topl);
                    SqlParameter Kolvo = new SqlParameter("@Kolvo", dataGridView1[3, str].Value.ToString());
                    SqlParameter Zen = new SqlParameter("@Zen", dataGridView1[4, str].Value.ToString());
                    SqlParameter Date = new SqlParameter("@Date", dataGridView1[6, str].EditedFormattedValue.ToString());
                    command.Parameters.Add(Post);
                    command.Parameters.Add(Zapr);
                    command.Parameters.Add(Topl);
                    command.Parameters.Add(Kolvo);
                    command.Parameters.Add(Zen);
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

        private void добавитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < 7; i++)
            {
                if (i > 2 & i < 6)
                {
                    if (dataGridView1[i, 0].Value == null & i != 5)
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
            Load_data(2);
            add(0);
            Hide();
            Show();
        Vh:
            int stop;  
        }

        private void выходToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Hide();
        }


        /*private void dataGridView1_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView1.Columns[e.ColumnIndex].Name == "Цена" & dataGridView1[4, 0].Value == null & dataGridView1[3, 0].Value == null)
            {
                dataGridView1[5, 0].Value = Convert.ToString(Convert.ToDouble(dataGridView1[4, 0].Value) * Convert.ToDouble(dataGridView1[3, 0].Value));
            }
            if (dataGridView1.Columns[e.ColumnIndex].Name == "Кол_во" & dataGridView1[4, 0].Value == null & dataGridView1[3, 0].Value == null)
            {
                dataGridView1[5, 0].Value = Convert.ToString(Convert.ToDouble(dataGridView1[4, 0].Value) * Convert.ToDouble(dataGridView1[3, 0].Value));
            }
        }*/

        /*public void Кол_во_CellDataChanged(object sender,  e)
        {
            if (dataGridView1[4, 0].Value == null)
            {
                dataGridView1[5, 0].Value = Convert.ToString(Convert.ToDouble(dataGridView1[4, 0].Value) * Convert.ToDouble(dataGridView1[3, 0].Value));
            }
        }
        public void Цена_CellDataChanged(object sender, DataGridViewCellValidatingEventArgs e)
        {
            if (dataGridView1[3, 0].Value == null)
            {
                dataGridView1[5, 0].Value = Convert.ToString(Convert.ToDouble(dataGridView1[4, 0].Value) * Convert.ToDouble(dataGridView1[3, 0].Value));
            }
        }*/
    }
}
