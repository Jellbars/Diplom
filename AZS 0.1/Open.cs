using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AZS_0._1.Properties;

namespace AZS_0._1
{
    class Open
    {
        Form cash;
        public void open_form(Form form, Form doch)
        {
            if (cash != null)
            {
                cash.Hide();
            }
            cash = form;
            //form.Height = doch.Height;
            form.Width = doch.Width - 20;
            form.MdiParent = doch;
            form.Show();
        }

        public void open_check()
        {
            AZS azs = (AZS)Application.OpenForms["AZS"];
            Check check = new Check();
            check.MdiParent = azs;
            check.Width = azs.Width - 20;
            cash = check;
            check.Show();
            
        }
    }
}
