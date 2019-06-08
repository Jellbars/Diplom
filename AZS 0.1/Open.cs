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
            //form.Width = doch.Width;
            form.MdiParent = doch;
            form.Show();
        }
    }
}
