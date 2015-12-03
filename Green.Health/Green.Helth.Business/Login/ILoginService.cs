using Green.Health.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Green.Health.Service
{
    public interface ILoginService
    {
        LoginResult CheckLogin(string loging, string pwd);

        bool SingIn(Customer cusomer);

        void SingOut();

        Customer GetCustomer();
    }
}
