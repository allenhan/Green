using Green.Health.Data;
using Green.Health.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Green.Health.DAL
{
    public class AuthDAL
    {
        private static DBResponsity responsity = DBResponsityFactory.GetInstance("authdb");

        public static Customer CheckCustomer(string username, string passwd)
        {
            string sql = "select * from customer where userName=@name and pwd=@pwd ";
            DBParameterCollection collection = new DBParameterCollection();
            DBParameter paramer = new DBParameter();
            paramer.DbType = System.Data.DbType.String;
            paramer.DbValue = username;
            paramer.Name = "@name";
            paramer.Size = 40;
            paramer.Direction = System.Data.ParameterDirection.Input;
            collection.AddDbParameter(paramer);

            paramer = new DBParameter();
            paramer.DbType = System.Data.DbType.String;
            paramer.DbValue = passwd;
            paramer.Name = "@pwd";
            paramer.Size = 40;
            paramer.Direction = System.Data.ParameterDirection.Input;
            collection.AddDbParameter(paramer);

            var list= responsity.QuerySql<Customer>(sql, collection).ToList();
            if (list != null && list.Count > 0)
                return list[0];
            return null;
        }

        public static Customer GetCustomer(string userName)
        {
            string sql = "select * from customer where userName=@name ";
            DBParameterCollection collection = new DBParameterCollection();
            DBParameter paramer = new DBParameter();
            paramer.DbType = System.Data.DbType.String;
            paramer.DbValue = userName;
            paramer.Name = "@name";
            paramer.Size = 40;
            paramer.Direction = System.Data.ParameterDirection.Input;
            collection.AddDbParameter(paramer);
            var rtn = responsity.QuerySql<Customer>(sql, collection);
            if (rtn != null && rtn.Count() > 0)
                return rtn.ToList<Customer>()[0];
            return null;
        }
    }
}
