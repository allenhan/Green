using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Green.Health.Data;
using System.Collections.Generic;
using Green.Health.Service;

namespace Green.Health.Tests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            string sql = "select * from city";
            string f = System.AppDomain.CurrentDomain.BaseDirectory;
            var list = DBResponsityFactory.GetInstance("orderdb").QueryAll<City>();
        }

        [TestMethod]
        public void CheckLogin()
        {
            string name = "hanjun";
            string pwd = "1";
            CustomerService ash = new CustomerService();
           // bool flag = ash.CheckCustomer(name, pwd);
        }
    }

    [Table("City")]
    public class City
    {
        public int ID { get; set; }

        public string Name { get; set; }

        public string CountryCode { get; set; }
    }
}
