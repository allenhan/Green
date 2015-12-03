using Green.Health.Entity;
using Green.Health.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Green.Health.Web.Framework
{
    public class WorkContext : IWorkContext
    {
        private Customer cachecustomer;

        private ILoginService loginService;

        public WorkContext(ILoginService loginservice)
        {
            this.loginService = loginservice;
        }

        public Customer CurrentCustomer
        {
            get
            {
                if (cachecustomer != null) return this.cachecustomer;
                Customer customer = loginService.GetCustomer();
                this.cachecustomer = customer;
                return customer;
            }
            set
            {
                cachecustomer = value;
            }
        }
    }
}
