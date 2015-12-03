using Green.Health.DAL;
using Green.Health.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Green.Health.Service
{
    public class CustomerService : ICustomerService
    {
        public Customer GetCustomer(string userName)
        {
            return AuthDAL.GetCustomer(userName);
        }

        public LoginResult CheckCustomer(string username, string passwd)
        {
            Customer cust = null;
            //check username
            cust = GetCustomer(username);
            if (cust == null) return LoginResult.NotExist;
            //check pwd
            cust = AuthDAL.CheckCustomer(username, passwd);
            if (cust == null) return LoginResult.PwdError;
            if (cust.IsActive == 0) return LoginResult.IsNotActive;
            return LoginResult.Success;
        }
    }
}
