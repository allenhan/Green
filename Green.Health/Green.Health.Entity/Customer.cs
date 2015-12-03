using Green.Health.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Green.Health.Entity
{
    [Table("Customer")]
    public class Customer
    {

        public int CustomerID { get; set; }

        public string UserName { get; set; }

        public string Pwd { get; set; }

        public string MobilePhone { get; set; }

        public string Email { get; set; }

        public int IsActive { get; set; }

        public DateTime RegistTime { get; set; }

        public int Level { get; set; }

        public string Remark { get; set; }
    }
}
