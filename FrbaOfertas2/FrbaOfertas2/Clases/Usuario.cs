using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FrbaOfertas2.Clases
{
    public class Usuario
    {
        public String password { get; set; }
        public String username { get; set; }

        public Usuario(String password_param, String username_param)
        {
            this.password = password_param;
            this.username = username_param;

        }


    }
}
