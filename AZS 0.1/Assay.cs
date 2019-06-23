using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AZS_0._1
{
    class Assay
    {

        //Znach znach;
        public void Prov(int a, string b)
        {

            switch (a.ToString())
            {
                case "1":
                    Simvols(@"^[А-Я]{1}[а-я]{1,30}$", b);//name ru
                    break;

                case "2":
                    //Simvols(@"^(?!.*@.*@.*$)(?!.*@.*\-\-.*\..*$)(?!.*@.*\-\..*$)(?!.*@.*\-$)(.*@.+(\..{1,11})?)$", b);
                    Simvols(@"^[A-Za-z0-9]{1,}[A-Za-z0-9_-]{2,}[@]{1}[a-z]{2,}[.]{1}[a-z]{2,}$", b);//email
                    break;

                case "3":
                    Simvols(@"^[8]{1}[0-9]{10}$", b);//teleph
                    break;

                case "4":
                    Simvols(@"^[1-9]{1}[0-9]{1,10}$", b);//chel
                    break;

                case "5":
                    Simvols(@"(^[1-9]{1})([0-9]{0,})(,{0,}[0-9]{0,}$)", b);//nechel
                    break;

                case "6":
                    Simvols(@"^[А-Я]{1,}[ «»а-яА-я]{2,}$",b);//postavchik
                    break;

                case "7":
                    Simvols(@"^[1-9]{1}[0-9]{1,9}$", b);//chel
                    break;
                case "8":
                    Simvols(@"^[1-9]{1}[0-9]{0,}$", b);//chel
                    break;
                case "9":
                    Simvols(@"^[0-9]{1}[,0-9]{0,}$", b);
                    break;
                case "10":
                    Simvols(@"^[0-9a-zA-Z]{4,}$", b);
                    break;
                default:
                    break;
            }
        }

        private void Simvols(string a, string b)
        {
            Regex regex = new Regex(a);
            MatchCollection matches = regex.Matches(b);
            if (matches.Count != 0)
            { 
                Znach.prof = Znach.prof + 1;
            }
        }

        public bool IsValid(string emailaddress)
        {
            try
            {
                MailAddress m = new MailAddress(emailaddress);

                return true;
            }
            catch (FormatException)
            {
                return false;
            }
        }
    }
}
