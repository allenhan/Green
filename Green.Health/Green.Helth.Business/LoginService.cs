using Green.Health.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Green.Helth.Business
{
    public class LoginService
    {
        public static int CheckLogin(string loging, string pwd)
        {
            return DBResponsity.ExcecuteCmd(" select * from city ");
        }
    }
}
