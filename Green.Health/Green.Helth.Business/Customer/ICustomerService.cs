using Green.Health.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Green.Health.Service
{
    public interface ICustomerService
    {
        Customer GetCustomer(string userName);

        LoginResult CheckCustomer(string username, string passwd);
    }
}
