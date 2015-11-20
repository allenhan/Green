using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace Green.Health.Data
{
    public class SqlServerProvider:DbProvider
    {

        private DataBaseSet dbset = null;

        public SqlServerProvider(DataBaseSet dbset)
        {
            this.dbset = dbset;
        }

        public override System.Data.IDbConnection OpenConnect(DataBaseRW RWFlag)
        {
            string type = RWFlag == DataBaseRW.Read ? "R" : "W";
            string connectstring = dbset.DBItems.Find(c => c.DataBaseType == type).ConnectString;
            IDbConnection connection = new SqlConnection(connectstring);
            connection.Open();
            return connection;
        }

        public override void CloseConnect(System.Data.IDbConnection connection)
        {
            connection.Close();
        }
    }
}
