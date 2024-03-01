using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_shop_Wpf_
{
    internal class User
    {
        public User(String name, String vorname, String password) {
            this.Nachname = name;
            this.Vorname = vorname;
            this.password = password;
        }
        public string Nachname { get; set; }
        public String Vorname { get; set; }
        public String password { get; set; }
    }
}
