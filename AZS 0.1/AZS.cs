using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AZS_0._1
{
    public partial class AZS : Form
    {
        Open open = new Open();

        public AZS()
        {
            InitializeComponent();
        }

        private void AZS_Load(object sender, EventArgs e)
        {

            Znach.Mdi_Height = Height;
            Znach.Mdi_Width = Width;
            //Parametr();
        }

        private void входToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Login login = new Login();
            login.MdiParent = this;
            open.open_form(login, this);

        }

        private void выходToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Znach.log_d = "0";
            Parametr();
        }

        private void входToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void добавлениеToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Personal_add pers_add = new Personal_add();
            open.open_form(pers_add, this);
        }

        private void просмотрToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            Personal pers = new Personal();
            pers.удалитьToolStripMenuItem.Visible = false;
            pers.редактироватьToolStripMenuItem.Visible = false;
            pers.dataGridView1.ReadOnly = true;
            open.open_form(pers, this);
        }

        private void удалениеToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Personal pers = new Personal();
            pers.dataGridView1.ReadOnly = true;
            pers.редактироватьToolStripMenuItem.Visible = false;
            open.open_form(pers, this);
        }

        private void добавлениеToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            Client_add cli_add = new Client_add();
            open.open_form(cli_add, this);
        }

        private void просмотрToolStripMenuItem3_Click(object sender, EventArgs e)
        {
            Client cli = new Client();
            cli.удалитьToolStripMenuItem.Visible = false;
            cli.редактироватьToolStripMenuItem.Visible = false;
            cli.dataGridView1.ReadOnly = true;  
            open.open_form(cli, this);
        }

        private void редактированиеToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Personal pers = new Personal();
            pers.удалитьToolStripMenuItem.Visible = false;
            open.open_form(pers, this);
        }

        private void редактированиеToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            Client cli = new Client();
            cli.удалитьToolStripMenuItem.Visible = false;
            open.open_form(cli, this);
        }

        private void удалениеToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            Client cli = new Client();
            cli.dataGridView1.ReadOnly = true;
            cli.редактироватьToolStripMenuItem.Visible = false;
            open.open_form(cli, this);
        }

        private void добавлениеToolStripMenuItem_Click(object sender, EventArgs e)
        {
            THH_add thh_add = new THH_add();
            open.open_form(thh_add, this);
        }

        private void просмотрToolStripMenuItem_Click(object sender, EventArgs e)
        {
            THH thh = new THH();
            thh.удалитьToolStripMenuItem.Visible = false;
            thh.редактироватьToolStripMenuItem.Visible = false;
            thh.dataGridView1.ReadOnly = true;
            open.open_form(thh, this);
        }

        private void удалениеToolStripMenuItem3_Click(object sender, EventArgs e)
        {
            THH thh = new THH();
            thh.dataGridView1.ReadOnly = true;
            thh.редактироватьToolStripMenuItem.Visible = false;
            open.open_form(thh, this);
        }

        private void посмотретьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Contract contr = new Contract();
            contr.удалитьToolStripMenuItem.Visible = false;
            contr.редактироватьToolStripMenuItem.Visible = false;
            contr.dataGridView1.ReadOnly = true;
            open.open_form(contr, this);
        }

        private void добавитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Contract_add contr = new Contract_add();
            open.open_form(contr, this);
        }

        private void удалениеToolStripMenuItem4_Click(object sender, EventArgs e)
        {
            Contract contr = new Contract();
            contr.dataGridView1.ReadOnly = true;
            contr.редактироватьToolStripMenuItem.Visible = false;
            open.open_form(contr, this);
        }

        public void Parametr()
        {
            if (Znach.log_d != "0")
            {
                toolStripStatusLabel1.Text = Znach.name;
            }

            switch (Znach.log_d)
            {
                case "0":
                    учетToolStripMenuItem.Enabled = false;
                    персоналToolStripMenuItem.Enabled = false;
                    клиентToolStripMenuItem.Enabled = false;
                    администрированиеToolStripMenuItem.Enabled = false;
                    созданиеЧекаToolStripMenuItem.Enabled = false;
                    toolStripStatusLabel1.Text = "";
                    break;

                case "1":

                    break;

                case "2":

                    break;
            }
        }

        private void созданиеЧекаToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Check check = new Check();
            open.open_form(check, this);
        }

        private void просмотрToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Supplier supl = new Supplier();
            supl.удалитьToolStripMenuItem.Visible = false;
            supl.редактироватьToolStripMenuItem.Visible = false;
            supl.dataGridView1.ReadOnly = true;
            open.open_form(supl, this);
        }

        private void добавитьToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Supplier_add cli_add = new Supplier_add();
            open.open_form(cli_add, this);
        }

        private void удалитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Supplier supl = new Supplier();
            supl.dataGridView1.ReadOnly = true;
            supl.редактироватьToolStripMenuItem.Visible = false;
            open.open_form(supl, this);
        }
    }
}
