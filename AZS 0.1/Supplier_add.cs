﻿using System;
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
    public partial class Supplier_add : Form
    {
        public Supplier_add()
        {
            InitializeComponent();
        }

        Assay assay = new Assay();

        private void добавитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Znach.prof = 0;
            for (int i = 0; i < 4; i++)
            {
                if (dataGridView1[i, 0].Value == null)
                {
                    MessageBox.Show("Заполните все ячейки");
                    goto Vh;
                }
            }
            assay.Prov(6, dataGridView1[0, 0].Value.ToString());
            assay.Prov(3, dataGridView1[2, 0].Value.ToString());
            assay.Prov(2, dataGridView1[3, 0].Value.ToString());
            if (Znach.prof == 3)
            {
                add(0);
                Hide();
                Show();
            }
            else
            {
                MessageBox.Show("Проверьте поля на корректность");
            }
        Vh:
            int stop;

        }

        private void add(int str)
        {
            string a = "INSERT INTO [Поставщик] ([Название], [Адрес], [Телефон], [Email])  VALUES ( @Nam, @Addres, @Email, @Teleph)";
            using (SqlConnection connection = new SqlConnection(Znach.connetionString))
                try
                {
                    connection.Open();
                    SqlCommand command = new SqlCommand(a, connection);
                    SqlParameter NamPar = new SqlParameter("@Name", dataGridView1[0, str].Value.ToString());
                    SqlParameter AddPar = new SqlParameter("@Addres", dataGridView1[1, str].Value.ToString());
                    SqlParameter EmaPar = new SqlParameter("@Email", dataGridView1[2, str].Value.ToString());
                    SqlParameter TelPar = new SqlParameter("@Teleph", dataGridView1[3, str].Value.ToString());
                    command.Parameters.Add(NamPar);
                    command.Parameters.Add(AddPar);
                    command.Parameters.Add(TelPar);
                    command.Parameters.Add(EmaPar);
                    int number = command.ExecuteNonQuery();
                    Console.WriteLine("Добавлено объектов: {0}", number);
                }
                finally
                {
                    connection.Close();
                    connection.Dispose();
                }
        }

        private void Supplier_add_Load(object sender, EventArgs e)
        {
            // TODO: данная строка кода позволяет загрузить данные в таблицу "diplom_ruDataSet.Клиент". При необходимости она может быть перемещена или удалена.
            //this.клиентTableAdapter.Fill(this.diplom_ruDataSet.Клиент);

        }

        private void выходToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Hide();
        }
    }
}
