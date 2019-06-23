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
        public int cli_chek;

        Open open = new Open();
        Assay assay = new Assay();
        AZS azs = (AZS)Application.OpenForms["AZS"];

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
                a = "Select ID_топлива, Цена  from [Топливо] Where Название ='" + comboBox1.Text + "'";
            }
            if (zp == 4)
            {
                a = "Select ID_топлива, Цена  from [Топливо] Where Название ='" + comboBox1.Text + "'";
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
                            if (zp == 4)
                            {
                                label5.Text = reader[1].ToString();
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
                            textBox2.ForeColor = Color.Red;
                            //MessageBox.Show("Не найдено");
                        }
                        if (zp == 2)
                        {
                            cli_chek = 1;
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
            Znach.prof = 0;
            if (comboBox2.Text.Length != 0 & textBox2.Text.Length != 0)
            {
                assay.Prov(8, textBox2.Text);
                if (Znach.prof == 1)
                    Load_data(1);
                else
                    MessageBox.Show("Введите цифры");
            }
            else
                MessageBox.Show("Выберите и заполните оба поля!");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int rez = 0;
            cli_chek = 0;
            id_cl = 0;
            int pust = 0;
            Znach.prof = 0;
            assay.Prov(5, textBox1.Text);
            if (textBox2.Text != "" & comboBox1.Text != "")
            {
                assay.Prov(8, textBox2.Text);
                pust = 1;
            }
            if ((pust == 1 & Znach.prof == 2) | (pust == 0 & Znach.prof == 1))
            {
                if (pust == 1)
                {
                    Load_data(2);
                    if (cli_chek == 1)
                    {
                    DialogResult result = MessageBox.Show(
        "Клиент не найден, продолжить?",
        "Сообщение",
        MessageBoxButtons.YesNo,
        MessageBoxIcon.Error,
        MessageBoxDefaultButton.Button1);
                        if (result == DialogResult.No)
                        {
                            rez = 1;
                            goto Vh_sozchek;
                        }
                    }
                }
                Load_data(3);
                add(0);
                Hide();
                open.open_check();
            }
            else
            {
                MessageBox.Show("Проверьте корректность вводимой информации");
            }
        Vh_sozchek:
            if (rez == 1)
            {
                textBox2.Focus();
            }
        }

        private void add(int str)
        {
            SqlParameter Kli = new SqlParameter("@Kli", null); ;
            string a = null;
            if (id_cl != 0)
            {
                a = "INSERT INTO [Чек] (ID_заправки, ID_топлива, [Количество топлива], Сумма, ID_клинета, ID_сотрудника, Дата) VALUES ( @Zapr, @Topl, @Kolvo, @Cum, @Kli, @Sotr, @Date)";
            }
            else
            {
                a = "INSERT INTO [Чек] (ID_заправки, ID_топлива, [Количество топлива], Сумма, ID_сотрудника, Дата) VALUES ( @Zapr, @Topl, @Kolvo, @Cum, @Sotr, @Date)";
            }
                using (SqlConnection connection = new SqlConnection(Znach.connetionString))
                try
                {
                    connection.Open();
                    SqlCommand command = new SqlCommand(a, connection);
                    SqlParameter Zapr = new SqlParameter("@Zapr", Convert.ToInt32(azs.toolStripStatusLabel2.Text));
                    SqlParameter Topl = new SqlParameter("@Topl", id_topl);
                    SqlParameter Kolvo = new SqlParameter("@Kolvo", textBox1.Text);
                    SqlParameter Cum = new SqlParameter("@Cum", Convert.ToDouble(textBox1.Text) * cum_topl);
                    if (id_cl != 0)
                    {
                        Kli = new SqlParameter("@Kli", id_cl);
                    }
                    SqlParameter Sotr = new SqlParameter("@Sotr", Znach.log);
                    SqlParameter Date = new SqlParameter("@Date", DateTime.Now);
                    command.Parameters.Add(Zapr);
                    command.Parameters.Add(Topl);
                    command.Parameters.Add(Kolvo);
                    command.Parameters.Add(Cum);
                    if (id_cl != 0)
                    {
                        command.Parameters.Add(Kli);
                    }
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
            Znach.prof = 0;
            if (textBox2.ForeColor != SystemColors.WindowText)
            {
                textBox2.ForeColor = SystemColors.WindowText;
            }
            if (comboBox2.Text != "")
            {
                    assay.Prov(8, textBox2.Text);
                    if (Znach.prof == 1)
                        Load_data(1);
            }
        }

        private void выходToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Hide();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.Text != "")
            {
                textBox1.Enabled = true;
                Load_data(4);
            }
            if (textBox1.Text != "")
            {
                Znach.prof = 0;
                assay.Prov(9, textBox1.Text);
                if (Znach.prof == 1)
                {
                    label6.Text = Convert.ToString(Convert.ToDouble(textBox1.Text) * Convert.ToDouble(label5.Text));
                }
                else
                {
                    MessageBox.Show("Введите число");
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (textBox1.Text != "")
            {
                Znach.prof = 0;
                assay.Prov(9, textBox1.Text);
                if (Znach.prof == 1)
                {
                    label6.Text = Convert.ToString(Convert.ToDouble(textBox1.Text) * Convert.ToDouble(label5.Text));
                }
                else
                {
                    MessageBox.Show("Введите число");
                }
            }
        }

        private void сформироватьЧекToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Znach.prof = 0;
            assay.Prov(5, textBox1.Text);
            if (textBox2.Text != "")
            {
                assay.Prov(4, textBox2.Text);
            }
            if ((textBox2.Text != "" & Znach.prof == 2) | (textBox2.Text == "" & Znach.prof == 1))
            {
                Load_data(2);
                Load_data(3);
                add(0);
                Hide();
                Show();
            }
            else
            {
                MessageBox.Show("Проверьте корректность вводимой информации");
            }
        }
    }
}
