using Green.Health.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Green.Health.Web.Framework
{
    public interface IWorkContext
    {
        Customer CurrentCustomer { get; set; }
    }
}
