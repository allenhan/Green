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

        public string ConnectString
        {
            get;
            set;
        }

        public SqlServerProvider(string connectStr)
        {
            this.ConnectString = connectStr;
        }

        public override System.Data.IDbConnection OpenConnect()
        {
            IDbConnection connection = new SqlConnection(this.ConnectString);
            connection.Open();
            return connection;
        }

        public override void CloseConnect(System.Data.IDbConnection connection)
        {
            connection.Close();
        }
    }
}
