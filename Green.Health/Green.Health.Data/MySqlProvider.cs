using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Green.Health.Data
{
    public class MySqlProvider : DbProvider
    {
        public string ConnectString
        {
            get;
            set;
        }

        public MySqlProvider(string conString)
        {
            this.ConnectString = conString;
        }

        public override IDbConnection OpenConnect()
        {
            IDbConnection connection = new MySql.Data.MySqlClient.MySqlConnection(ConnectString);
            connection.Open();
            return connection;
        }
        public override void CloseConnect(IDbConnection connection)
        {
            if (connection.State != ConnectionState.Closed)
                connection.Close();
        }
    }
}
